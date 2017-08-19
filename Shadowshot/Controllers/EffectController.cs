using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace Shadowshot.Controllers
{
    internal static class EffectsController
    {
        private static readonly List<ShadowProperties> DefaultShadow = new List<ShadowProperties>
        {
            new ShadowProperties(0.57, 0, 23, 38),
            new ShadowProperties(0.9, 0, 25, 65)
        };

        internal static Image Shadow(Image image)
        {
            var shadows = DefaultShadow.ToDictionary(x => x, x => CreateShadow(image.Width, image.Height, x));

            Image result = new Bitmap(
                shadows.Select(x => x.Value.Width).Max(),
                shadows.Select(x => x.Value.Height).Max(),
                PixelFormat.Format32bppArgb);
            using (var graphics = Graphics.FromImage(result))
            {
                graphics.Clear(Color.Transparent);

                using (var sizes = shadows.Select(x => x.Key.Size).OrderByDescending(x => x).GetEnumerator())
                {
                    sizes.MoveNext();
                    var offset = sizes.Current;
                    graphics.DrawImage(image, offset, offset);
                    foreach (var shadow in shadows.OrderBy(x => x.Key.Size))
                    {
                        if (sizes.MoveNext())
                            offset -= sizes.Current;
                        else
                            offset = 0;
                        graphics.DrawImage(shadow.Value, offset, offset);
                    }
                }
            }

            foreach (var shadow in shadows)
                shadow.Value.Dispose();

            return result;
        }

        private static Image CreateShadow(int screenShotWidth, int screenShotHeight, ShadowProperties shadowProperties)
        {
            var width = screenShotWidth + Math.Abs(shadowProperties.DistanceX) + 2 * shadowProperties.Size;
            var height = screenShotHeight + Math.Abs(shadowProperties.DistanceY) + 2 * shadowProperties.Size;
            var grayScale = new byte[width * height];

            FillRectangle(grayScale, screenShotWidth, screenShotHeight, shadowProperties);
            GaussianBlur(grayScale, screenShotWidth, screenShotHeight, shadowProperties);
            return ToImage(grayScale, screenShotWidth, screenShotHeight, shadowProperties);
        }

        private static void FillRectangle(IList<byte> grayScale, int screenShotWidth, int screenShotHeight,
            ShadowProperties shadowProperties)
        {
            var width = screenShotWidth + Math.Abs(shadowProperties.DistanceX) + 2 * shadowProperties.Size;
            var height = screenShotHeight + Math.Abs(shadowProperties.DistanceY) + 2 * shadowProperties.Size;
            var dropShadowRectangle = Rectangle.FromLTRB(
                shadowProperties.DistanceX > 0
                    ? shadowProperties.Size + shadowProperties.DistanceX
                    : shadowProperties.Size,
                shadowProperties.DistanceY > 0
                    ? shadowProperties.Size + shadowProperties.DistanceY
                    : shadowProperties.Size,
                screenShotWidth + (shadowProperties.DistanceX > 0
                    ? shadowProperties.Size + shadowProperties.DistanceX
                    : shadowProperties.Size),
                screenShotHeight + (shadowProperties.DistanceY > 0
                    ? shadowProperties.Size + shadowProperties.DistanceY
                    : shadowProperties.Size));
            var unusedRectangle = Rectangle.FromLTRB(2 * shadowProperties.Size, 2 * shadowProperties.Size,
                screenShotWidth, screenShotHeight);

            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
            {
                if (unusedRectangle.Contains(x, y))
                    continue;
                if (dropShadowRectangle.Contains(x, y))
                    grayScale[x + y * width] = (byte) (255 * shadowProperties.Opacity);
                else
                    grayScale[x + y * width] = 255;
            }
        }

        private static void GaussianBlur(IList<byte> grayScale, int screenShotWidth, int screenShotHeight,
            ShadowProperties shadowProperties)
        {
            var width = screenShotWidth + Math.Abs(shadowProperties.DistanceX) + 2 * shadowProperties.Size;
            var height = screenShotHeight + Math.Abs(shadowProperties.DistanceY) + 2 * shadowProperties.Size;
            var unusedRectangle = Rectangle.FromLTRB(2 * shadowProperties.Size, 2 * shadowProperties.Size,
                screenShotWidth, screenShotHeight);
            var kernel = GetGaussianKernel(shadowProperties.Size);

            var row = new byte[width];
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                    row[x] = grayScale[y * width + x];
                for (var x = 0; x < width; x++)
                {
                    if (unusedRectangle.Contains(x, y))
                        continue;
                    double sum = 0;
                    for (var i = -shadowProperties.Size; i <= shadowProperties.Size; i++)
                        if (0 <= x + i && x + i < width)
                            sum += row[x + i] * kernel[i + shadowProperties.Size];
                        else
                            sum += 255 * kernel[i + shadowProperties.Size];
                    grayScale[x + y * width] = (byte) sum;
                }
            }

            var column = new byte[height];
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                    column[y] = grayScale[y * width + x];
                for (var y = 0; y < height; y++)
                {
                    if (unusedRectangle.Contains(x, y))
                        continue;
                    double sum = 0;
                    for (var i = -shadowProperties.Size; i <= shadowProperties.Size; i++)
                        if (0 <= y + i && y + i < height)
                            sum += column[y + i] * kernel[i + shadowProperties.Size];
                        else
                            sum += 255 * kernel[i + shadowProperties.Size];
                    grayScale[x + y * width] = (byte) sum;
                }
            }
        }

        private static Image ToImage(IList<byte> grayScale, int screenShotWidth, int screenShotHeight,
            ShadowProperties shadowProperties)
        {
            var width = screenShotWidth + Math.Abs(shadowProperties.DistanceX) + 2 * shadowProperties.Size;
            var height = screenShotHeight + Math.Abs(shadowProperties.DistanceY) + 2 * shadowProperties.Size;
            var screenShotRectangle = Rectangle.FromLTRB(shadowProperties.Size, shadowProperties.Size,
                screenShotWidth + shadowProperties.Size, screenShotHeight + shadowProperties.Size);

            var bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            var bitmapData = bitmap.LockBits(Rectangle.FromLTRB(0, 0, width, height),
                ImageLockMode.WriteOnly, bitmap.PixelFormat);
            var bitmapBytes = new byte[bitmapData.Stride * bitmapData.Height];
            Marshal.Copy(bitmapData.Scan0, bitmapBytes, 0, bitmapBytes.Length);

            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
            {
                if (screenShotRectangle.Contains(x, y))
                    continue;
                SetPixel(bitmapBytes, x, y, bitmapData.Stride, 255 - grayScale[x + y * width], 0, 0, 0);
            }

            Marshal.Copy(bitmapBytes, 0, bitmapData.Scan0, bitmapBytes.Length);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        private static double[] GetGaussianKernel(int size)
        {
            var sigma = (size - 1) * 0.3 + 0.8;

            var kernel = new double[2 * size + 1];
            for (var i = 0; i < kernel.Length; i++)
            {
                var x = i - (kernel.Length - 1) * 0.5;
                kernel[i] = Math.Exp(Math.Pow(x, 2) / (-2 * Math.Pow(sigma, 2)));
            }

            var sum = 1 / kernel.Sum();
            for (var i = 0; i < kernel.Length; i++)
                kernel[i] *= sum;

            return kernel;
        }

        private static void SetPixel(IList<byte> bitmap, int x, int y, int stride,
            int alpha, int red, int green, int blue)
        {
            bitmap[y * stride + x * 4 + 3] = (byte) alpha;
            bitmap[y * stride + x * 4 + 2] = (byte) red;
            bitmap[y * stride + x * 4 + 1] = (byte) green;
            bitmap[y * stride + x * 4 + 0] = (byte) blue;
        }

        private struct ShadowProperties
        {
            internal readonly double Opacity;
            internal readonly int DistanceX;
            internal readonly int DistanceY;
            internal readonly int Size;

            internal ShadowProperties(double opacity, int distanceX, int distanceY, int size)
            {
                Opacity = opacity;
                DistanceX = distanceX;
                DistanceY = distanceY;
                Size = size;
            }
        }
    }
}
