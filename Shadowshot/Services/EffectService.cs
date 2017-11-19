using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace Shadowshot.Services
{
    internal class EffectService
    {
        private static readonly List<ShadowConfig> DefaultShadow = new List<ShadowConfig>
        {
            new ShadowConfig
            {
                DistanceX = 0,
                DistanceY = 23,
                Color = Color.FromArgb((int) (0.43 * 255), 0, 0, 0),
                Radius = 38
            },
            new ShadowConfig
            {
                DistanceX = 0,
                DistanceY = 25,
                Color = Color.FromArgb((int) (0.1 * 255), 0, 0, 0),
                Radius = 65
            }
        };

        internal Bitmap DropShadow(Bitmap bitmap)
        {
            var shadows = DefaultShadow.ToDictionary(x => x, x => CreateShadow(bitmap, x));

            var result = new Bitmap(
                shadows.Select(x => x.Value.Width).Max(),
                shadows.Select(x => x.Value.Height).Max());
            using (var graphics = Graphics.FromImage(result))
            {
                graphics.Clear(Color.Transparent);

                var offsetList = shadows.Select(x => x.Key.Radius).OrderByDescending(x => x).ToList();
                using (var enumerator = offsetList.GetEnumerator())
                {
                    enumerator.MoveNext();
                    var offset = enumerator.Current;
                    foreach (var shadow in shadows.OrderBy(x => x.Key.Radius))
                    {
                        if (enumerator.MoveNext())
                            offset -= enumerator.Current;
                        else
                            offset = 0;
                        graphics.DrawImage(shadow.Value, (int) (1.5 * offset), offset);
                    }
                }
                graphics.DrawImage(bitmap, (int) (1.5 * offsetList.First()), offsetList.First());
            }

            foreach (var shadow in shadows)
                shadow.Value.Dispose();

            return result;
        }

        private static Bitmap CreateShadow(Bitmap bitmap, ShadowConfig cfg)
        {
            var shadow = new Bitmap(
                bitmap.Width + Math.Abs(cfg.DistanceX) + 3 * cfg.Radius,
                bitmap.Height + Math.Abs(cfg.DistanceY) + 3 * cfg.Radius);
            using (var graphics = Graphics.FromImage(shadow))
            {
                graphics.Clear(Color.Transparent);
                graphics.FillRectangle(new SolidBrush(cfg.Color),
                    new Rectangle(
                        cfg.DistanceX > 0 ? (int) (1.5 * cfg.Radius) + cfg.DistanceX : (int) (1.5 * cfg.Radius),
                        cfg.DistanceY > 0 ? cfg.Radius + cfg.DistanceY : cfg.Radius,
                        bitmap.Width, bitmap.Height));
            }

            GaussianBlur(shadow, cfg.Radius);

            return shadow;
        }

        private static void GaussianBlur(Bitmap bitmap, int radius)
        {
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadWrite, bitmap.PixelFormat);
            var bytes = new int[Math.Abs(data.Stride) * data.Height / 4];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);

            var alpha = new int[data.Width * data.Height];
            var red = new int[data.Width * data.Height];
            var green = new int[data.Width * data.Height];
            var blue = new int[data.Width * data.Height];
            for (var i = 0; i < data.Width; i++)
            for (var j = 0; j < data.Height; j++)
            {
                alpha[i + j * data.Width] = (int) ((bytes[i + j * Math.Abs(data.Stride) / 4] & 0xff000000) >> 24);
                red[i + j * data.Width] = (bytes[i + j * Math.Abs(data.Stride) / 4] & 0x00ff0000) >> 16;
                green[i + j * data.Width] = (bytes[i + j * Math.Abs(data.Stride) / 4] & 0x0000ff00) >> 8;
                blue[i + j * data.Width] = bytes[i + j * Math.Abs(data.Stride) / 4] & 0x000000ff;
            }

            alpha = GaussianBlurChannel(alpha, data.Width, data.Height, radius);
            red = GaussianBlurChannel(red, data.Width, data.Height, radius);
            green = GaussianBlurChannel(green, data.Width, data.Height, radius);
            blue = GaussianBlurChannel(blue, data.Width, data.Height, radius);

            for (var i = 0; i < data.Width; i++)
            for (var j = 0; j < data.Height; j++)
            {
                if (alpha[i + j * data.Width] < 0)
                    alpha[i + j * data.Width] = 0;
                else if (alpha[i + j * data.Width] > 255)
                    alpha[i + j * data.Width] = 255;

                if (red[i + j * data.Width] < 0)
                    red[i + j * data.Width] = 0;
                else if (red[i + j * data.Width] > 255)
                    red[i + j * data.Width] = 255;

                if (green[i + j * data.Width] < 0)
                    green[i + j * data.Width] = 0;
                else if (green[i + j * data.Width] > 255)
                    green[i + j * data.Width] = 255;

                if (blue[i + j * data.Width] < 0)
                    blue[i + j * data.Width] = 0;
                else if (blue[i + j * data.Width] > 255)
                    blue[i + j * data.Width] = 255;

                bytes[i + j * Math.Abs(data.Stride) / 4] =
                    alpha[i + j * data.Width] << 24 |
                    red[i + j * data.Width] << 16 |
                    green[i + j * data.Width] << 8 |
                    blue[i + j * data.Width];
            }

            Marshal.Copy(bytes, 0, data.Scan0, bytes.Length);
            bitmap.UnlockBits(data);
        }

        private static int[] GaussianBlurChannel(IReadOnlyList<int> channel, int width, int height, int radius)
        {
            const int passes = 3;
            var widthList = BoxesForGauss(radius, passes);
            var result = BoxBlurChannel(channel, width, height, (widthList[0] - 1) / 2);
            for (var i = 1; i < passes; i++)
                result = BoxBlurChannel(result, width, height, (widthList[i] - 1) / 2);
            return result;
        }

        private static int[] BoxesForGauss(int radius, int n)
        {
            var sigma = (radius - 1) * 0.3 + 0.8;
            var widthIdeal = Math.Sqrt(12 * sigma * sigma / n + 1);
            var widthLess = (int) widthIdeal % 2 != 0 ? (int) widthIdeal - 1 : (int) widthIdeal;
            var widthGreater = widthLess + 2;
            var m = (12 * sigma * sigma - n * widthLess * widthLess - 4 * n * widthLess - 3 * n) / (-4 * widthLess - 4);

            var widthList = new int[n];
            for (var i = 0; i < n; i++)
                widthList[i] = i < m ? widthLess : widthGreater;

            return widthList;
        }

        private static int[] BoxBlurChannel(IReadOnlyList<int> channel, int width, int height, int radius)
        {
            var result = BoxBlurChannelH(channel, width, height, radius);
            result = BoxBlurChannelT(result, width, height, radius);
            return result;
        }

        private static int[] BoxBlurChannelH(IReadOnlyList<int> channel, int width, int height, int radius)
        {
            var result = new int[channel.Count];
            var iarr = 1.0 / (radius + radius + 1);

            for (var i = 0; i < height; i++)
            {
                var ti = i * width;
                var li = ti;
                var ri = ti + radius;
                var fv = channel[ti];
                var lv = channel[ti + width - 1];
                var val = (radius + 1) * fv;

                for (var j = 0; j < radius; j++)
                    val += channel[ti + j];
                for (var j = 0; j <= radius; j++)
                {
                    val += channel[ri++] - fv;
                    result[ti++] = (int) Math.Round(val * iarr);
                }
                for (var j = radius + 1; j < width - radius; j++)
                {
                    val += channel[ri++] - result[li++];
                    result[ti++] = (int) Math.Round(val * iarr);
                }
                for (var j = width - radius; j < width; j++)
                {
                    val += lv - channel[li++];
                    result[ti++] = (int) Math.Round(val * iarr);
                }
            }

            return result;
        }

        private static int[] BoxBlurChannelT(IReadOnlyList<int> channel, int width, int height, int radius)
        {
            var result = new int[channel.Count];
            var iarr = 1.0 / (radius + radius + 1);

            for (var i = 0; i < width; i++)
            {
                var ti = i;
                var li = ti;
                var ri = ti + radius * width;
                var fv = channel[ti];
                var lv = channel[ti + width * (height - 1)];
                var val = (radius + 1) * fv;

                for (var j = 0; j < radius; j++)
                    val += channel[ti + j * width];
                for (var j = 0; j <= radius; j++)
                {
                    val += channel[ri] - fv;
                    result[ti] = (int) Math.Round(val * iarr);
                    ri += width;
                    ti += width;
                }
                for (var j = radius + 1; j < height - radius; j++)
                {
                    val += channel[ri] - channel[li];
                    result[ti] = (int) Math.Round(val * iarr);
                    li += width;
                    ri += width;
                    ti += width;
                }
                for (var j = height - radius; j < height; j++)
                {
                    val += lv - channel[li];
                    result[ti] = (int) Math.Round(val * iarr);
                    li += width;
                    ti += width;
                }
            }

            return result;
        }

        private struct ShadowConfig
        {
            internal int DistanceX;
            internal int DistanceY;
            internal Color Color;
            internal int Radius;
        }
    }
}
