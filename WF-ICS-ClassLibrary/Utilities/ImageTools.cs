using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Utilities
{
    public static class ImageTools
    {
        public static string BytesStringFromImage(this System.Drawing.Image img)
        {
            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(System.Drawing.Image));

                return Convert.ToBase64String((Byte[])converter.ConvertTo(img, typeof(Byte[])));
            }
            catch (Exception) { return null; }
        }
        public static System.Drawing.Image getImageFromBytes(this string ImageBytes)
        {
            Byte[] TheImageAsBytes = Convert.FromBase64String(ImageBytes);

            MemoryStream MemStr = new MemoryStream(TheImageAsBytes);

            System.Drawing.Image I = System.Drawing.Image.FromStream(MemStr);
            return I;
        }
    }
}
