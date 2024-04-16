using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Utilities
{
    public static class ColourUtilities
    {

        public static bool ContrastReadableIs(Color color_1, Color color_2)
        {
            // Maximum contrast would be a value of "1.0f" which is the brightness
            // difference between "Color.Black" and "Color.White"
            float minContrast = 0.5f;

            float brightness_1 = color_1.GetBrightness();
            float brightness_2 = color_2.GetBrightness();

            // Contrast readable?
            return (Math.Abs(brightness_1 - brightness_2) >= minContrast);
        }

        public static Color GetGoodTextColor(this Color background_color)
        {
            //try blackish
            Color textColor = Color.FromArgb(25, 25, 25);
            if (ContrastReadableIs(background_color, textColor)) { return textColor; }

            textColor = Color.FromArgb(240, 240, 240);
            return textColor;
        }
    }
}
