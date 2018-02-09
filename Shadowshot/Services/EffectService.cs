// Copyright 2017-2018 Kagami Studio
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using StackBlur.Extensions;

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
                graphics.Clear(Color.White);

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
            
            shadow.StackBlur(cfg.Radius);

            return shadow;
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
