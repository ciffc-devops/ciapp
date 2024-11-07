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

        public static List<ProgramColor> GetColourSetById(int id)
        {
            List<ProgramColor> colors = new List<ProgramColor>();
            colors.Add(new ProgramColor { Name = "GoodInput", Color = Color.LightSkyBlue });
            colors.Add(new ProgramColor { Name = "BadInput", Color = Color.LightCoral });


            switch (id) {
                case 1:
                    colors.Add(new ProgramColor { Name = "Background", Color = Color.FromArgb(255, 248, 222) });
                    colors.Add(new ProgramColor { Name = "Accent", Color = Color.FromArgb(219, 218, 204) });
                    colors.Add(new ProgramColor { Name = "Primary", Color = Color.FromArgb(168, 118, 62) });
                    colors.Add(new ProgramColor { Name = "Help", Color = Color.FromArgb(122, 139, 153) });
                    colors.Add(new ProgramColor { Name = "DarkAccent", Color = Color.FromArgb(219, 218, 204) });
                    break;
                case 2:
                    colors.Add(new ProgramColor { Name = "Background", Color = Color.FromArgb(245, 245, 245) });
                    colors.Add(new ProgramColor { Name = "Accent", Color = Color.FromArgb(193, 193, 193) });
                    colors.Add(new ProgramColor { Name = "Primary", Color = Color.FromArgb(239, 64, 53) });
                    colors.Add(new ProgramColor { Name = "Help", Color = Color.FromArgb(252, 222, 112) });
                    colors.Add(new ProgramColor { Name = "DarkAccent", Color = Color.FromArgb(85, 94, 89) });
                    break;
                case 3:
                    colors.Add(new ProgramColor { Name = "Background", Color = Color.FromArgb(245, 231, 178) });
                    colors.Add(new ProgramColor { Name = "Accent", Color = Color.FromArgb(249, 214, 137) });
                    colors.Add(new ProgramColor { Name = "Primary", Color = Color.FromArgb(224, 167, 94) });
                    colors.Add(new ProgramColor { Name = "Help", Color = Color.FromArgb(165, 186, 234) });
                    colors.Add(new ProgramColor { Name = "DarkAccent", Color = Color.FromArgb(151, 49, 49) });
                    break;
                case 4:
                    colors.Add(new ProgramColor { Name = "Background", Color = Color.FromArgb(248, 237, 227) });
                    colors.Add(new ProgramColor { Name = "Accent", Color = Color.FromArgb(223, 211, 195) });
                    colors.Add(new ProgramColor { Name = "Primary", Color = Color.FromArgb(197, 112, 93) });
                    colors.Add(new ProgramColor { Name = "Help", Color = Color.FromArgb(157, 151, 174) });
                    colors.Add(new ProgramColor { Name = "DarkAccent", Color = Color.FromArgb(120, 59, 45) });
                    break;

            }


            return colors;
        }
    }
}
