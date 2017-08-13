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
        internal static Image DropShadow(Image image)
        {
            Image result;
            using (var dropShadow1 = CreateDropShadow(image.Width, image.Height, 0.47, 0, 26, 43))
            using (var dropShadow2 = CreateDropShadow(image.Width, image.Height, 0.44, 0, 0, 3))
            {
                result = new Bitmap(
                    Math.Max(dropShadow1.Width, dropShadow2.Width),
                    Math.Max(dropShadow1.Height, dropShadow2.Height), PixelFormat.Format32bppArgb);

                using (var graphics = Graphics.FromImage(result))
                {
                    graphics.Clear(Color.Transparent);
                    graphics.DrawImage(dropShadow1, 0, 0);
                    graphics.DrawImage(dropShadow2, 40, 40);
                    graphics.DrawImage(image, 43, 43);
                }
            }
            return result;
        }

        private static Image CreateDropShadow(int screenShotWidth, int screenShotHeight,
            double opacity, int distanceX, int distanceY, int size)
        {
            var width = screenShotWidth + Math.Abs(distanceX) + 2 * size;
            var height = screenShotHeight + Math.Abs(distanceY) + 2 * size;
            var grayScale = new byte[width * height];

            FillRectangle(grayScale, screenShotWidth, screenShotHeight, opacity, distanceX, distanceY, size);
            GaussianBlur(grayScale, screenShotWidth, screenShotHeight, distanceX, distanceY, size);
            return ToImage(grayScale, screenShotWidth, screenShotHeight, distanceX, distanceY, size);
        }

        private static void FillRectangle(IList<byte> grayScale, int screenShotWidth, int screenShotHeight,
            double opacity, int distanceX, int distanceY, int size)
        {
            var width = screenShotWidth + Math.Abs(distanceX) + 2 * size;
            var height = screenShotHeight + Math.Abs(distanceY) + 2 * size;
            var dropShadowRectangle = Rectangle.FromLTRB(
                distanceX > 0 ? size + distanceX : size,
                distanceY > 0 ? size + distanceY : size,
                screenShotWidth + (distanceX > 0 ? size + distanceX : size),
                screenShotHeight + (distanceY > 0 ? size + distanceY : size));
            var unusedRectangle = Rectangle.FromLTRB(2 * size, 2 * size, screenShotWidth, screenShotHeight);

            for (var x = 0; x < width; x++)
            for (var y = 0; y < height; y++)
            {
                if (unusedRectangle.Contains(x, y))
                    continue;
                if (dropShadowRectangle.Contains(x, y))
                    grayScale[x + y * width] = (byte) (255 * opacity);
                else
                    grayScale[x + y * width] = 255;
            }
        }

        private static void GaussianBlur(IList<byte> grayScale, int screenShotWidth, int screenShotHeight,
            int distanceX, int distanceY, int size)
        {
            var width = screenShotWidth + Math.Abs(distanceX) + 2 * size;
            var height = screenShotHeight + Math.Abs(distanceY) + 2 * size;
            var unusedRectangle = Rectangle.FromLTRB(2 * size, 2 * size, screenShotWidth, screenShotHeight);

            var kernel = GetGaussianKernel(size);

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
                    for (var i = -size; i <= size; i++)
                        if (0 <= x + i && x + i < width)
                            sum += row[x + i] * kernel[i + size];
                        else
                            sum += 255 * kernel[i + size];
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
                    for (var i = -size; i <= size; i++)
                        if (0 <= y + i && y + i < height)
                            sum += column[y + i] * kernel[i + size];
                        else
                            sum += 255 * kernel[i + size];
                    grayScale[x + y * width] = (byte) sum;
                }
            }
        }

        private static Image ToImage(IList<byte> grayScale, int screenShotWidth, int screenShotHeight,
            int distanceX, int distanceY, int size)
        {
            var width = screenShotWidth + Math.Abs(distanceX) + 2 * size;
            var height = screenShotHeight + Math.Abs(distanceY) + 2 * size;
            var screenShotRectangle = Rectangle.FromLTRB(size, size, screenShotWidth + size, screenShotHeight + size);

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
    }
}
