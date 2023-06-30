using SpiceEngine.Core.Utilities;
using System.Runtime.InteropServices;

namespace Monarch.Engine.Maths
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Color3 : IEquatable<Color3>
    {
        public Color3(byte r, byte g, byte b) : this(r / (float)byte.MaxValue, g / (float)byte.MaxValue, b / (float)byte.MaxValue) { }
        public Color3(float r, float g, float b)
        {
            R = r;
            G = g;
            B = b;
        }

        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }

        public bool IsReal => R.IsReal() && G.IsReal() && B.IsReal();

        public static Color3 AliceBlue => new(240, 248, 255);
        public static Color3 AntiqueWhite => new(250, 235, 215);
        public static Color3 Aqua => new(0, 255, 255);
        public static Color3 Aquamarine => new(127, 255, 212);
        public static Color3 Azure => new(240, 255, 255);
        public static Color3 Beige => new(245, 245, 220);
        public static Color3 Bisque => new(255, 228, 196);
        public static Color3 Black => new(0, 0, 0);
        public static Color3 BlanchedAlmond => new(255, 235, 205);
        public static Color3 Blue => new(0, 0, 255);
        public static Color3 BlueViolet => new(138, 43, 226);
        public static Color3 Brown => new(165, 42, 42);
        public static Color3 BurlyWood => new(222, 184, 135);
        public static Color3 CadetBlue => new(95, 158, 160);
        public static Color3 Chartreuse => new(127, 255, 0);
        public static Color3 Chocolate => new(210, 105, 30);
        public static Color3 Coral => new(255, 127, 80);
        public static Color3 CornflowerBlue => new(100, 149, 237);
        public static Color3 Cornsilk => new(255, 248, 220);
        public static Color3 Crimson => new(220, 20, 60);
        public static Color3 Cyan => new(0, 255, 255);
        public static Color3 DarkBlue => new(0, 0, 139);
        public static Color3 DarkCyan => new(0, 139, 139);
        public static Color3 DarkGoldenrod => new(184, 134, 11);
        public static Color3 DarkGray => new(169, 169, 169);
        public static Color3 DarkGreen => new(0, 100, 0);
        public static Color3 DarkKhaki => new(189, 183, 107);
        public static Color3 DarkMagenta => new(139, 0, 139);
        public static Color3 DarkOliveGreen => new(85, 107, 47);
        public static Color3 DarkOrange => new(255, 140, 0);
        public static Color3 DarkOrchid => new(153, 50, 204);
        public static Color3 DarkRed => new(139, 0, 0);
        public static Color3 DarkSalmon => new(233, 150, 122);
        public static Color3 DarkSeaGreen => new(143, 188, 139);
        public static Color3 DarkSlateBlue => new(72, 61, 139);
        public static Color3 DarkSlateGray => new(47, 79, 79);
        public static Color3 DarkTurquoise => new(0, 206, 209);
        public static Color3 DarkViolet => new(148, 0, 211);
        public static Color3 DeepPink => new(255, 20, 147);
        public static Color3 DeepSkyBlue => new(0, 191, 255);
        public static Color3 DimGray => new(105, 105, 105);
        public static Color3 DodgerBlue => new(30, 144, 255);
        public static Color3 Firebrick => new(178, 34, 34);
        public static Color3 FloralWhite => new(255, 250, 240);
        public static Color3 ForestGreen => new(34, 139, 34);
        public static Color3 Fuchsia => new(255, 0, 255);
        public static Color3 Gainsboro => new(220, 220, 220);
        public static Color3 GhostWhite => new(248, 248, 255);
        public static Color3 Gold => new(255, 215, 0);
        public static Color3 Goldenrod => new(218, 165, 32);
        public static Color3 Gray => new(128, 128, 128);
        public static Color3 Green => new(0, 128, 0);
        public static Color3 GreenYellow => new(173, 255, 47);
        public static Color3 Honeydew => new(240, 255, 240);
        public static Color3 HotPink => new(255, 105, 180);
        public static Color3 IndianRed => new(205, 92, 92);
        public static Color3 Indigo => new(75, 0, 130);
        public static Color3 Ivory => new(255, 255, 240);
        public static Color3 Khaki => new(240, 230, 140);
        public static Color3 Lavender => new(230, 230, 250);
        public static Color3 LavenderBlush => new(255, 240, 245);
        public static Color3 LawnGreen => new(124, 252, 0);
        public static Color3 LemonChiffon => new(255, 250, 205);
        public static Color3 LightBlue => new(173, 216, 230);
        public static Color3 LightCoral => new(240, 128, 128);
        public static Color3 LightCyan => new(224, 255, 255);
        public static Color3 LightGoldenrodYellow => new(250, 250, 210);
        public static Color3 LightGreen => new(144, 238, 144);
        public static Color3 LightGray => new(211, 211, 211);
        public static Color3 LightPink => new(255, 182, 193);
        public static Color3 LightSalmon => new(255, 160, 122);
        public static Color3 LightSeaGreen => new(32, 178, 170);
        public static Color3 LightSkyBlue => new(135, 206, 250);
        public static Color3 LightSlateGray => new(119, 136, 153);
        public static Color3 LightSteelBlue => new(176, 196, 222);
        public static Color3 LightYellow => new(255, 255, 224);
        public static Color3 Lime => new(0, 255, 0);
        public static Color3 LimeGreen => new(50, 205, 50);
        public static Color3 Linen => new(250, 240, 230);
        public static Color3 Magenta => new(255, 0, 255);
        public static Color3 Maroon => new(128, 0, 0);
        public static Color3 MediumAquamarine => new(102, 205, 170);
        public static Color3 MediumBlue => new(0, 0, 205);
        public static Color3 MediumOrchid => new(186, 85, 211);
        public static Color3 MediumPurple => new(147, 112, 219);
        public static Color3 MediumSeaGreen => new(60, 179, 113);
        public static Color3 MediumSlateBlue => new(123, 104, 238);
        public static Color3 MediumSpringGreen => new(0, 250, 154);
        public static Color3 MediumTurquoise => new(72, 209, 204);
        public static Color3 MediumVioletRed => new(199, 21, 133);
        public static Color3 MidnightBlue => new(25, 25, 112);
        public static Color3 MintCream => new(245, 255, 250);
        public static Color3 MistyRose => new(255, 228, 225);
        public static Color3 Moccasin => new(255, 228, 181);
        public static Color3 NavajoWhite => new(255, 222, 173);
        public static Color3 Navy => new(0, 0, 128);
        public static Color3 OldLace => new(253, 245, 230);
        public static Color3 Olive => new(128, 128, 0);
        public static Color3 OliveDrab => new(107, 142, 35);
        public static Color3 Orange => new(255, 165, 0);
        public static Color3 OrangeRed => new(255, 69, 0);
        public static Color3 Orchid => new(218, 112, 214);
        public static Color3 PaleGoldenrod => new(238, 232, 170);
        public static Color3 PaleGreen => new(152, 251, 152);
        public static Color3 PaleTurquoise => new(175, 238, 238);
        public static Color3 PaleVioletRed => new(219, 112, 147);
        public static Color3 PapayaWhip => new(255, 239, 213);
        public static Color3 PeachPuff => new(255, 218, 185);
        public static Color3 Peru => new(205, 133, 63);
        public static Color3 Pink => new(255, 192, 203);
        public static Color3 Plum => new(221, 160, 221);
        public static Color3 PowderBlue => new(176, 224, 230);
        public static Color3 Purple => new(128, 0, 128);
        public static Color3 Red => new(255, 0, 0);
        public static Color3 RosyBrown => new(188, 143, 143);
        public static Color3 RoyalBlue => new(65, 105, 225);
        public static Color3 SaddleBrown => new(139, 69, 19);
        public static Color3 Salmon => new(250, 128, 114);
        public static Color3 SandyBrown => new(244, 164, 96);
        public static Color3 SeaGreen => new(46, 139, 87);
        public static Color3 SeaShell => new(255, 245, 238);
        public static Color3 Sienna => new(160, 82, 45);
        public static Color3 Silver => new(192, 192, 192);
        public static Color3 SkyBlue => new(135, 206, 235);
        public static Color3 SlateBlue => new(106, 90, 205);
        public static Color3 SlateGray => new(112, 128, 144);
        public static Color3 Snow => new(255, 250, 250);
        public static Color3 SpringGreen => new(0, 255, 127);
        public static Color3 SteelBlue => new(70, 130, 180);
        public static Color3 Tan => new(210, 180, 140);
        public static Color3 Teal => new(0, 128, 128);
        public static Color3 Thistle => new(216, 191, 216);
        public static Color3 Tomato => new(255, 99, 71);
        public static Color3 Turquoise => new(64, 224, 208);
        public static Color3 Violet => new(238, 130, 238);
        public static Color3 Wheat => new(245, 222, 179);
        public static Color3 White => new(255, 255, 255);
        public static Color3 WhiteSmoke => new(245, 245, 245);
        public static Color3 Yellow => new(255, 255, 0);
        public static Color3 YellowGreen => new(154, 205, 50);

        /// <summary>
        /// Converts XYZ color values to RGB color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value.
        /// </returns>
        /// <param name="xyz">
        /// Color value to convert with the trisimulus values of X, Y, and Z in the corresponding element.
        /// Each has a range of 0.0 to 1.0.
        /// </param>
        /// <remarks>Uses the CIE XYZ colorspace.</remarks>
        public static Color3 FromXyz(Vector3f xyz)
        {
            var r = (0.41847f * xyz.X) + (-0.15866f * xyz.Y) + (-0.082835f * xyz.Z);
            var g = (-0.091169f * xyz.X) + (0.25243f * xyz.Y) + (0.015708f * xyz.Z);
            var b = (0.00092090f * xyz.X) + (-0.0025498f * xyz.Y) + (0.17860f * xyz.Z);
            return new(r, g, b);
        }

        /// <summary>
        /// Converts RGB color values to XYZ color values.
        /// </summary>
        /// <returns>
        /// Returns the converted color value with the trisimulus values of X, Y, and Z in the corresponding element.
        /// Each has a range of 0.0 to 1.0.
        /// </returns>
        /// <param name="rgb">Color value to convert.</param>
        /// <remarks>Uses the CIE XYZ colorspace.</remarks>
        public static Vector3f ToXyz(Color3 rgb)
        {
            var x = ((0.49f * rgb.R) + (0.31f * rgb.G) + (0.20f * rgb.B)) / 0.17697f;
            var y = ((0.17697f * rgb.R) + (0.81240f * rgb.G) + (0.01063f * rgb.B)) / 0.17697f;
            var z = ((0.00f * rgb.R) + (0.01f * rgb.G) + (0.99f * rgb.B)) / 0.17697f;
            return new(x, y, z);
        }

        public override bool Equals(object obj) => obj is Color3 color && Equals(color);

        public bool Equals(Color3 other) => R == other.R
            && G == other.G
            && B == other.B;

        public override int GetHashCode() => HashCode.Combine(R, G, B);

        public static bool operator ==(Color3 left, Color3 right) => left.Equals(right);

        public static bool operator !=(Color3 left, Color3 right) => !(left == right);
    }
}
