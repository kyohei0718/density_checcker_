using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace density_checcker2
{
    class HSVtoRGB
    {
        public int[] Convert_RGB(double d_hue, double d_saturation, double d_value)
        {
            int[] RGB = { 0, 0, 0 };

            int R = 0;
            int G = 0;
            int B = 0;

            if (d_saturation == 0.0)
            {
                RGB[0] = (int)(d_value * 255);
                RGB[1] = (int)(d_value * 255);
                RGB[2] = (int)(d_value * 255);
            }
            else
            {
                double d_c = d_value * d_saturation;
                double Hd = d_hue / 60;
                double d_x = d_c * (1 - Math.Abs(Hd % 2 - 1));

                double R1, G1, B1;
                if (0 <= Hd && Hd < 1)
                {
                    R1 = d_c;
                    G1 = d_x;
                    B1 = 0;
                }
                else if (1 <= Hd && Hd < 2)
                {
                    R1 = d_x;
                    G1 = d_c;
                    B1 = 0;
                }
                else if (2 <= Hd && Hd < 3)
                {
                    R1 = 0;
                    G1 = d_c;
                    B1 = d_x;
                }
                else if (3 <= Hd && Hd < 4)
                {
                    R1 = 0;
                    G1 = d_x;
                    B1 = d_c;
                }
                else if (4 <= Hd && Hd < 5)
                {
                    R1 = d_x;
                    G1 = 0;
                    B1 = d_c;
                }
                else if (5 <= Hd && Hd < 6)
                {
                    R1 = d_c;
                    G1 = 0;
                    B1 = d_x;
                }
                else
                {
                    R1 = 0;
                    G1 = 0;
                    B1 = 0;
                }

                double m = d_value - d_c;
                RGB[0] = (int)((R1 + m) * 255);
                RGB[1] = (int)((G1 + m) * 255);
                RGB[2] = (int)((B1 + m) * 255);
            }

            return RGB;
        }
    }
}
