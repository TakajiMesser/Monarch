using SpiceEngine.Core.Utilities;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Maths
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Color4 : IEquatable<Color4>
    {
        public Color4(byte r, byte g, byte b, byte a) : this(r / (float)byte.MaxValue, g / (float)byte.MaxValue, b / (float)byte.MaxValue, a / (float)byte.MaxValue) { }
        public Color4(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        [FieldOffset(0)]
        public float R;
        //public float R { get; set; }

        [FieldOffset(4)]
        public float G;
        //public float G { get; set; }

        [FieldOffset(8)]
        public float B;
        //public float B { get; set; }

        [FieldOffset(12)]
        public float A;
        //public float A { get; set; }

        public bool IsReal => R.IsReal() && G.IsReal() && B.IsReal() && A.IsReal();

        public int ToArgb()
        {
            var value = ((uint)(A * byte.MaxValue) << 24)
                | ((uint)(R * byte.MaxValue) << 16)
                | ((uint)(G * byte.MaxValue) << 8)
                | (uint)(B * byte.MaxValue);

            return unchecked((int)value);
        }

        public static Color4 Zero => new(0, 0, 0, 0);
        public static Color4 Transparent => new(255, 255, 255, 0);
        public static Color4 AliceBlue => new(240, 248, 255, 255);
        public static Color4 AntiqueWhite => new(250, 235, 215, 255);
        public static Color4 Aqua => new(0, 255, 255, 255);
        public static Color4 Aquamarine => new(127, 255, 212, 255);
        public static Color4 Azure => new(240, 255, 255, 255);
        public static Color4 Beige => new(245, 245, 220, 255);
        public static Color4 Bisque => new(255, 228, 196, 255);
        public static Color4 Black => new(0, 0, 0, 255);
        public static Color4 BlanchedAlmond => new(255, 235, 205, 255);
        public static Color4 Blue => new(0, 0, 255, 255);
        public static Color4 BlueViolet => new(138, 43, 226, 255);
        public static Color4 Brown => new(165, 42, 42, 255);
        public static Color4 BurlyWood => new(222, 184, 135, 255);
        public static Color4 CadetBlue => new(95, 158, 160, 255);
        public static Color4 Chartreuse => new(127, 255, 0, 255);
        public static Color4 Chocolate => new(210, 105, 30, 255);
        public static Color4 Coral => new(255, 127, 80, 255);
        public static Color4 CornflowerBlue => new(100, 149, 237, 255);
        public static Color4 Cornsilk => new(255, 248, 220, 255);
        public static Color4 Crimson => new(220, 20, 60, 255);
        public static Color4 Cyan => new(0, 255, 255, 255);
        public static Color4 DarkBlue => new(0, 0, 139, 255);
        public static Color4 DarkCyan => new(0, 139, 139, 255);
        public static Color4 DarkGoldenrod => new(184, 134, 11, 255);
        public static Color4 DarkGray => new(169, 169, 169, 255);
        public static Color4 DarkGreen => new(0, 100, 0, 255);
        public static Color4 DarkKhaki => new(189, 183, 107, 255);
        public static Color4 DarkMagenta => new(139, 0, 139, 255);
        public static Color4 DarkOliveGreen => new(85, 107, 47, 255);
        public static Color4 DarkOrange => new(255, 140, 0, 255);
        public static Color4 DarkOrchid => new(153, 50, 204, 255);
        public static Color4 DarkRed => new(139, 0, 0, 255);
        public static Color4 DarkSalmon => new(233, 150, 122, 255);
        public static Color4 DarkSeaGreen => new(143, 188, 139, 255);
        public static Color4 DarkSlateBlue => new(72, 61, 139, 255);
        public static Color4 DarkSlateGray => new(47, 79, 79, 255);
        public static Color4 DarkTurquoise => new(0, 206, 209, 255);
        public static Color4 DarkViolet => new(148, 0, 211, 255);
        public static Color4 DeepPink => new(255, 20, 147, 255);
        public static Color4 DeepSkyBlue => new(0, 191, 255, 255);
        public static Color4 DimGray => new(105, 105, 105, 255);
        public static Color4 DodgerBlue => new(30, 144, 255, 255);
        public static Color4 Firebrick => new(178, 34, 34, 255);
        public static Color4 FloralWhite => new(255, 250, 240, 255);
        public static Color4 ForestGreen => new(34, 139, 34, 255);
        public static Color4 Fuchsia => new(255, 0, 255, 255);
        public static Color4 Gainsboro => new(220, 220, 220, 255);
        public static Color4 GhostWhite => new(248, 248, 255, 255);
        public static Color4 Gold => new(255, 215, 0, 255);
        public static Color4 Goldenrod => new(218, 165, 32, 255);
        public static Color4 Gray => new(128, 128, 128, 255);
        public static Color4 Green => new(0, 128, 0, 255);
        public static Color4 GreenYellow => new(173, 255, 47, 255);
        public static Color4 Honeydew => new(240, 255, 240, 255);
        public static Color4 HotPink => new(255, 105, 180, 255);
        public static Color4 IndianRed => new(205, 92, 92, 255);
        public static Color4 Indigo => new(75, 0, 130, 255);
        public static Color4 Ivory => new(255, 255, 240, 255);
        public static Color4 Khaki => new(240, 230, 140, 255);
        public static Color4 Lavender => new(230, 230, 250, 255);
        public static Color4 LavenderBlush => new(255, 240, 245, 255);
        public static Color4 LawnGreen => new(124, 252, 0, 255);
        public static Color4 LemonChiffon => new(255, 250, 205, 255);
        public static Color4 LightBlue => new(173, 216, 230, 255);
        public static Color4 LightCoral => new(240, 128, 128, 255);
        public static Color4 LightCyan => new(224, 255, 255, 255);
        public static Color4 LightGoldenrodYellow => new(250, 250, 210, 255);
        public static Color4 LightGreen => new(144, 238, 144, 255);
        public static Color4 LightGray => new(211, 211, 211, 255);
        public static Color4 LightPink => new(255, 182, 193, 255);
        public static Color4 LightSalmon => new(255, 160, 122, 255);
        public static Color4 LightSeaGreen => new(32, 178, 170, 255);
        public static Color4 LightSkyBlue => new(135, 206, 250, 255);
        public static Color4 LightSlateGray => new(119, 136, 153, 255);
        public static Color4 LightSteelBlue => new(176, 196, 222, 255);
        public static Color4 LightYellow => new(255, 255, 224, 255);
        public static Color4 Lime => new(0, 255, 0, 255);
        public static Color4 LimeGreen => new(50, 205, 50, 255);
        public static Color4 Linen => new(250, 240, 230, 255);
        public static Color4 Magenta => new(255, 0, 255, 255);
        public static Color4 Maroon => new(128, 0, 0, 255);
        public static Color4 MediumAquamarine => new(102, 205, 170, 255);
        public static Color4 MediumBlue => new(0, 0, 205, 255);
        public static Color4 MediumOrchid => new(186, 85, 211, 255);
        public static Color4 MediumPurple => new(147, 112, 219, 255);
        public static Color4 MediumSeaGreen => new(60, 179, 113, 255);
        public static Color4 MediumSlateBlue => new(123, 104, 238, 255);
        public static Color4 MediumSpringGreen => new(0, 250, 154, 255);
        public static Color4 MediumTurquoise => new(72, 209, 204, 255);
        public static Color4 MediumVioletRed => new(199, 21, 133, 255);
        public static Color4 MidnightBlue => new(25, 25, 112, 255);
        public static Color4 MintCream => new(245, 255, 250, 255);
        public static Color4 MistyRose => new(255, 228, 225, 255);
        public static Color4 Moccasin => new(255, 228, 181, 255);
        public static Color4 NavajoWhite => new(255, 222, 173, 255);
        public static Color4 Navy => new(0, 0, 128, 255);
        public static Color4 OldLace => new(253, 245, 230, 255);
        public static Color4 Olive => new(128, 128, 0, 255);
        public static Color4 OliveDrab => new(107, 142, 35, 255);
        public static Color4 Orange => new(255, 165, 0, 255);
        public static Color4 OrangeRed => new(255, 69, 0, 255);
        public static Color4 Orchid => new(218, 112, 214, 255);
        public static Color4 PaleGoldenrod => new(238, 232, 170, 255);
        public static Color4 PaleGreen => new(152, 251, 152, 255);
        public static Color4 PaleTurquoise => new(175, 238, 238, 255);
        public static Color4 PaleVioletRed => new(219, 112, 147, 255);
        public static Color4 PapayaWhip => new(255, 239, 213, 255);
        public static Color4 PeachPuff => new(255, 218, 185, 255);
        public static Color4 Peru => new(205, 133, 63, 255);
        public static Color4 Pink => new(255, 192, 203, 255);
        public static Color4 Plum => new(221, 160, 221, 255);
        public static Color4 PowderBlue => new(176, 224, 230, 255);
        public static Color4 Purple => new(128, 0, 128, 255);
        public static Color4 Red => new(255, 0, 0, 255);
        public static Color4 RosyBrown => new(188, 143, 143, 255);
        public static Color4 RoyalBlue => new(65, 105, 225, 255);
        public static Color4 SaddleBrown => new(139, 69, 19, 255);
        public static Color4 Salmon => new(250, 128, 114, 255);
        public static Color4 SandyBrown => new(244, 164, 96, 255);
        public static Color4 SeaGreen => new(46, 139, 87, 255);
        public static Color4 SeaShell => new(255, 245, 238, 255);
        public static Color4 Sienna => new(160, 82, 45, 255);
        public static Color4 Silver => new(192, 192, 192, 255);
        public static Color4 SkyBlue => new(135, 206, 235, 255);
        public static Color4 SlateBlue => new(106, 90, 205, 255);
        public static Color4 SlateGray => new(112, 128, 144, 255);
        public static Color4 Snow => new(255, 250, 250, 255);
        public static Color4 SpringGreen => new(0, 255, 127, 255);
        public static Color4 SteelBlue => new(70, 130, 180, 255);
        public static Color4 Tan => new(210, 180, 140, 255);
        public static Color4 Teal => new(0, 128, 128, 255);
        public static Color4 Thistle => new(216, 191, 216, 255);
        public static Color4 Tomato => new(255, 99, 71, 255);
        public static Color4 Turquoise => new(64, 224, 208, 255);
        public static Color4 Violet => new(238, 130, 238, 255);
        public static Color4 Wheat => new(245, 222, 179, 255);
        public static Color4 White => new(255, 255, 255, 255);
        public static Color4 WhiteSmoke => new(245, 245, 245, 255);
        public static Color4 Yellow => new(255, 255, 0, 255);
        public static Color4 YellowGreen => new(154, 205, 50, 255);

        public static Color4 FromSrgb(Color4 srgb)
        {
            float r, g, b;

            if (srgb.R <= 0.04045f)
            {
                r = srgb.R / 12.92f;
            }
            else
            {
                r = (float)Math.Pow((srgb.R + 0.055f) / (1.0f + 0.055f), 2.4f);
            }

            if (srgb.G <= 0.04045f)
            {
                g = srgb.G / 12.92f;
            }
            else
            {
                g = (float)Math.Pow((srgb.G + 0.055f) / (1.0f + 0.055f), 2.4f);
            }

            if (srgb.B <= 0.04045f)
            {
                b = srgb.B / 12.92f;
            }
            else
            {
                b = (float)Math.Pow((srgb.B + 0.055f) / (1.0f + 0.055f), 2.4f);
            }

            return new(r, g, b, srgb.A);
        }

        public static Color4 ToSrgb(Color4 rgb)
        {
            float r, g, b;

            if (rgb.R <= 0.0031308)
            {
                r = 12.92f * rgb.R;
            }
            else
            {
                r = ((1.0f + 0.055f) * (float)Math.Pow(rgb.R, 1.0f / 2.4f)) - 0.055f;
            }

            if (rgb.G <= 0.0031308)
            {
                g = 12.92f * rgb.G;
            }
            else
            {
                g = ((1.0f + 0.055f) * (float)Math.Pow(rgb.G, 1.0f / 2.4f)) - 0.055f;
            }

            if (rgb.B <= 0.0031308)
            {
                b = 12.92f * rgb.B;
            }
            else
            {
                b = ((1.0f + 0.055f) * (float)Math.Pow(rgb.B, 1.0f / 2.4f)) - 0.055f;
            }

            return new(r, g, b, rgb.A);
        }

        /// <summary>
        /// Converts HSL color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="hsl">
        /// Color value to convert in hue, saturation, lightness (HSL).
        /// The X element is Hue (H), the Y element is Saturation (S), the Z element is Lightness (L), and the W element is
        /// Alpha (which is copied to the output's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </param>
        
        public static Color4 FromHsl(Vector4f hsl)
        {
            var hue = hsl.X * 360.0f;
            var saturation = hsl.Y;
            var lightness = hsl.Z;

            var c = (1.0f - Math.Abs((2.0f * lightness) - 1.0f)) * saturation;

            var h = hue / 60.0f;
            var x = c * (1.0f - Math.Abs((h % 2.0f) - 1.0f));

            float r, g, b;
            if (h >= 0.0f && h < 1.0f)
            {
                r = c;
                g = x;
                b = 0.0f;
            }
            else if (h >= 1.0f && h < 2.0f)
            {
                r = x;
                g = c;
                b = 0.0f;
            }
            else if (h >= 2.0f && h < 3.0f)
            {
                r = 0.0f;
                g = c;
                b = x;
            }
            else if (h >= 3.0f && h < 4.0f)
            {
                r = 0.0f;
                g = x;
                b = c;
            }
            else if (h >= 4.0f && h < 5.0f)
            {
                r = x;
                g = 0.0f;
                b = c;
            }
            else if (h >= 5.0f && h < 6.0f)
            {
                r = c;
                g = 0.0f;
                b = x;
            }
            else
            {
                r = 0.0f;
                g = 0.0f;
                b = 0.0f;
            }

            var m = lightness - (c / 2.0f);
            if (m < 0)
            {
                m = 0;
            }
            return new(r + m, g + m, b + m, hsl.W);
        }

        /// <summary>
        /// Converts RGB color values to HSL color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// The X element is Hue (H), the Y element is Saturation (S), the Z element is Lightness (L), and the W element is
        /// Alpha (a copy of the input's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        public static Vector4f ToHsl(Color4 rgb)
        {
            var max = Math.Max(rgb.R, Math.Max(rgb.G, rgb.B));
            var min = Math.Min(rgb.R, Math.Min(rgb.G, rgb.B));
            var diff = max - min;

            var h = 0.0f;
            if (diff == 0)
            {
                h = 0.0f;
            }
            else if (max == rgb.R)
            {
                h = ((rgb.G - rgb.B) / diff) % 6;
                if (h < 0)
                {
                    h += 6;
                }
            }
            else if (max == rgb.G)
            {
                h = ((rgb.B - rgb.R) / diff) + 2.0f;
            }
            else if (max == rgb.B)
            {
                h = ((rgb.R - rgb.G) / diff) + 4.0f;
            }

            var hue = h / 6.0f;
            if (hue < 0.0f)
            {
                hue += 1.0f;
            }

            var lightness = (max + min) / 2.0f;

            var saturation = 0.0f;
            if ((1.0f - Math.Abs((2.0f * lightness) - 1.0f)) != 0)
            {
                saturation = diff / (1.0f - Math.Abs((2.0f * lightness) - 1.0f));
            }

            return new(hue, saturation, lightness, rgb.A);
        }

        /// <summary>
        /// Converts HSV color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="hsv">
        /// Color value to convert in hue, saturation, value (HSV).
        /// The X element is Hue (H), the Y element is Saturation (S), the Z element is Value (V), and the W element is Alpha
        /// (which is copied to the output's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </param>
        public static Color4 FromHsv(Vector4f hsv)
        {
            var hue = hsv.X * 360.0f;
            var saturation = hsv.Y;
            var value = hsv.Z;

            var c = value * saturation;

            var h = hue / 60.0f;
            var x = c * (1.0f - Math.Abs((h % 2.0f) - 1.0f));

            float r, g, b;
            if (h >= 0.0f && h < 1.0f)
            {
                r = c;
                g = x;
                b = 0.0f;
            }
            else if (h >= 1.0f && h < 2.0f)
            {
                r = x;
                g = c;
                b = 0.0f;
            }
            else if (h >= 2.0f && h < 3.0f)
            {
                r = 0.0f;
                g = c;
                b = x;
            }
            else if (h >= 3.0f && h < 4.0f)
            {
                r = 0.0f;
                g = x;
                b = c;
            }
            else if (h >= 4.0f && h < 5.0f)
            {
                r = x;
                g = 0.0f;
                b = c;
            }
            else if (h >= 5.0f && h < 6.0f)
            {
                r = c;
                g = 0.0f;
                b = x;
            }
            else
            {
                r = 0.0f;
                g = 0.0f;
                b = 0.0f;
            }

            var m = value - c;
            return new(r + m, g + m, b + m, hsv.W);
        }

        /// <summary>
        /// Converts RGB color values to HSV color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// The X element is Hue (H), the Y element is Saturation (S), the Z element is Value (V), and the W element is Alpha
        /// (a copy of the input's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        public static Vector4f ToHsv(Color4 rgb)
        {
            var max = Math.Max(rgb.R, Math.Max(rgb.G, rgb.B));
            var min = Math.Min(rgb.R, Math.Min(rgb.G, rgb.B));
            var diff = max - min;

            var h = 0.0f;
            if (diff == 0)
            {
                h = 0.0f;
            }
            else if (max == rgb.R)
            {
                h = ((rgb.G - rgb.B) / diff) % 6.0f;
                if (h < 0)
                {
                    h += 6f;
                }
            }
            else if (max == rgb.G)
            {
                h = ((rgb.B - rgb.R) / diff) + 2.0f;
            }
            else if (max == rgb.B)
            {
                h = ((rgb.R - rgb.G) / diff) + 4.0f;
            }

            var hue = h * 60.0f / 360.0f;

            var saturation = 0.0f;
            if (max != 0.0f)
            {
                saturation = diff / max;
            }

            return new(hue, saturation, max, rgb.A);
        }

        /// <summary>
        /// Converts XYZ color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="xyz">
        /// Color value to convert with the trisimulus values of X, Y, and Z in the corresponding element, and the W element
        /// with Alpha (which is copied to the output's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </param>
        /// <remarks>Uses the CIE XYZ colorspace.</remarks>
        public static Color4 FromXyz(Vector4f xyz)
        {
            var r = (0.41847f * xyz.X) + (-0.15866f * xyz.Y) + (-0.082835f * xyz.Z);
            var g = (-0.091169f * xyz.X) + (0.25243f * xyz.Y) + (0.015708f * xyz.Z);
            var b = (0.00092090f * xyz.X) + (-0.0025498f * xyz.Y) + (0.17860f * xyz.Z);
            return new(r, g, b, xyz.W);
        }

        /// <summary>
        /// Converts RGB color values to XYZ color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value with the trisimulus values of X, Y, and Z in the corresponding element, and the W
        /// element with Alpha (a copy of the input's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        /// <remarks>Uses the CIE XYZ colorspace.</remarks>
        public static Vector4f ToXyz(Color4 rgb)
        {
            var x = ((0.49f * rgb.R) + (0.31f * rgb.G) + (0.20f * rgb.B)) / 0.17697f;
            var y = ((0.17697f * rgb.R) + (0.81240f * rgb.G) + (0.01063f * rgb.B)) / 0.17697f;
            var z = ((0.00f * rgb.R) + (0.01f * rgb.G) + (0.99f * rgb.B)) / 0.17697f;
            return new(x, y, z, rgb.A);
        }

        /// <summary>
        /// Converts YCbCr color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="ycbcr">
        /// Color value to convert in Luma-Chrominance (YCbCr) aka YUV.
        /// The X element contains Luma (Y, 0.0 to 1.0), the Y element contains Blue-difference chroma (U, -0.5 to 0.5), the Z
        /// element contains the Red-difference chroma (V, -0.5 to 0.5), and the W element contains the Alpha (which is copied
        /// to the output's Alpha value).
        /// </param>
        /// <remarks>Converts using ITU-R BT.601/CCIR 601 W(r) = 0.299 W(b) = 0.114 U(max) = 0.436 V(max) = 0.615.</remarks>
        public static Color4 FromYcbcr(Vector4f ycbcr)
        {
            var r = (1.0f * ycbcr.X) + (0.0f * ycbcr.Y) + (1.402f * ycbcr.Z);
            var g = (1.0f * ycbcr.X) + (-0.344136f * ycbcr.Y) + (-0.714136f * ycbcr.Z);
            var b = (1.0f * ycbcr.X) + (1.772f * ycbcr.Y) + (0.0f * ycbcr.Z);
            return new(r, g, b, ycbcr.W);
        }

        /// <summary>
        /// Converts RGB color values to YUV color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value in Luma-Chrominance (YCbCr) aka YUV.
        /// The X element contains Luma (Y, 0.0 to 1.0), the Y element contains Blue-difference chroma (U, -0.5 to 0.5), the Z
        /// element contains the Red-difference chroma (V, -0.5 to 0.5), and the W element contains the Alpha (a copy of the
        /// input's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        /// <remarks>Converts using ITU-R BT.601/CCIR 601 W(r) = 0.299 W(b) = 0.114 U(max) = 0.436 V(max) = 0.615.</remarks>
        public static Vector4f ToYcbcr(Color4 rgb)
        {
            var y = (0.299f * rgb.R) + (0.587f * rgb.G) + (0.114f * rgb.B);
            var u = (-0.168736f * rgb.R) + (-0.331264f * rgb.G) + (0.5f * rgb.B);
            var v = (0.5f * rgb.R) + (-0.418688f * rgb.G) + (-0.081312f * rgb.B);
            return new(y, u, v, rgb.A);
        }

        /// <summary>
        /// Converts HCY color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="hcy">
        /// Color value to convert in hue, chroma, luminance (HCY).
        /// The X element is Hue (H), the Y element is Chroma (C), the Z element is luminance (Y), and the W element is Alpha
        /// (which is copied to the output's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </param>
        public static Color4 FromHcy(Vector4f hcy)
        {
            var hue = hcy.X * 360.0f;
            var y = hcy.Y;
            var luminance = hcy.Z;

            var h = hue / 60.0f;
            var x = y * (1.0f - Math.Abs((h % 2.0f) - 1.0f));

            float r, g, b;
            if (h >= 0.0f && h < 1.0f)
            {
                r = y;
                g = x;
                b = 0.0f;
            }
            else if (h >= 1.0f && h < 2.0f)
            {
                r = x;
                g = y;
                b = 0.0f;
            }
            else if (h >= 2.0f && h < 3.0f)
            {
                r = 0.0f;
                g = y;
                b = x;
            }
            else if (h >= 3.0f && h < 4.0f)
            {
                r = 0.0f;
                g = x;
                b = y;
            }
            else if (h >= 4.0f && h < 5.0f)
            {
                r = x;
                g = 0.0f;
                b = y;
            }
            else if (h >= 5.0f && h < 6.0f)
            {
                r = y;
                g = 0.0f;
                b = x;
            }
            else
            {
                r = 0.0f;
                g = 0.0f;
                b = 0.0f;
            }

            var m = luminance - (0.30f * r) + (0.59f * g) + (0.11f * b);
            return new(r + m, g + m, b + m, hcy.W);
        }

        /// <summary>
        /// Converts RGB color values to HCY color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// The X element is Hue (H), the Y element is Chroma (C), the Z element is luminance (Y), and the W element is Alpha
        /// (a copy of the input's Alpha value).
        /// Each has a range of 0.0 to 1.0.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        public static Vector4f ToHcy(Color4 rgb)
        {
            var max = Math.Max(rgb.R, Math.Max(rgb.G, rgb.B));
            var min = Math.Min(rgb.R, Math.Min(rgb.G, rgb.B));
            var diff = max - min;

            var h = 0.0f;
            if (max == rgb.R)
            {
                h = ((rgb.G - rgb.B) / diff) % 6.0f;
            }
            else if (max == rgb.G)
            {
                h = ((rgb.B - rgb.R) / diff) + 2.0f;
            }
            else if (max == rgb.B)
            {
                h = ((rgb.R - rgb.G) / diff) + 4.0f;
            }

            var hue = h * 60.0f / 360.0f;

            var luminance = (0.30f * rgb.R) + (0.59f * rgb.G) + (0.11f * rgb.B);

            return new(hue, diff, luminance, rgb.A);
        }

        public override bool Equals(object obj) => obj is Color4 color && Equals(color);

        public bool Equals(Color4 other) => R == other.R
            && G == other.G
            && B == other.B
            && A == other.A;

        public override int GetHashCode() => HashCode.Combine(R, G, B, A);

        public static bool operator ==(Color4 left, Color4 right) => left.Equals(right);

        public static bool operator !=(Color4 left, Color4 right) => !(left == right);
    }
}
