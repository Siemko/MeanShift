using MeanShift.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeanShift.Helpers
{
    public static class RGB2LUV
    {
        public static ColorLUV ConvertRGB2LUV(int R, int G, int B)
        {
            var temp_R = Convert.ToDouble(R) / 255;
            var temp_G = Convert.ToDouble(G) / 255;
            var temp_B = Convert.ToDouble(B) / 255;

            if (temp_R > 0.04045)
                temp_R = Math.Pow(((temp_R + 0.055) / 1.055), 2.4);
            else
                temp_R = temp_R / 12.92;

            if (temp_G > 0.04045)
                temp_G = Math.Pow(((temp_G + 0.055) / 1.055), 2.4);
            else
                temp_G = temp_G / 12.92;

            if (temp_B > 0.04045)
                temp_B = Math.Pow(((temp_B + 0.055) / 1.055), 2.4);

            else
                temp_B = temp_B / 12.92;

            temp_R = temp_R * 100;
            temp_G = temp_G * 100;
            temp_B = temp_B * 100;

            var X = temp_R * 0.4124 + temp_G * 0.3576 + temp_B * 0.1805;
            var Y = temp_R * 0.2126 + temp_G * 0.7152 + temp_B * 0.0722;
            var Z = temp_R * 0.0193 + temp_G * 0.1192 + temp_B * 0.9505;

            //XYZ to LUV
            var temp_U = (4 * X) / (X + (15 * Y) + (3 * Z));
            var temp_V = (9 * Y) / (X + (15 * Y) + (3 * Z));

            var temp_Y = Y / 100;
            if (temp_Y > 0.008856)
                temp_Y = Math.Pow(temp_Y, (1 / 3));
            else
                temp_Y = (7.787 * temp_Y) + (16 / 116);

            var ref_X = 95.047;
            var ref_Y = 100.000;
            var ref_Z = 108.883;

            var ref_U = (4 * ref_X) / (ref_X + (15 * ref_Y) + (3 * ref_Z));
            var ref_V = (9 * ref_Y) / (ref_X + (15 * ref_Y) + (3 * ref_Z));

            var L1 = (116 * temp_Y) - 16;
            var U1 = 13 * L1 * (temp_U - ref_U);
            var V1 = 13 * L1 * (temp_V - ref_V);

            ColorLUV colorObject = new ColorLUV();
            colorObject.L = L1;
            colorObject.U = U1;
            colorObject.V = V1;

            return colorObject;
        }
    }
}
