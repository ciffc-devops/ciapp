using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Utilities
{
    public static class ImageTools
    {

        public static Bitmap ResizeImage(this System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighSpeed;
                graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public static string BytesStringFromImage(this System.Drawing.Image img)
        {
            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(System.Drawing.Image));

                return Convert.ToBase64String((Byte[])converter.ConvertTo(img, typeof(Byte[])));
            }
            catch (Exception) { return null; }
        }
        public static byte[] BytesFromImage(this System.Drawing.Image img)
        {
            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(System.Drawing.Image));

                return (Byte[])converter.ConvertTo(img, typeof(Byte[]));
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

        public static System.Drawing.Image getImageFromBytes(this byte[] TheImageAsBytes)
        {
            if (TheImageAsBytes != null)
            {
                MemoryStream MemStr = new MemoryStream(TheImageAsBytes);

                System.Drawing.Image I = System.Drawing.Image.FromStream(MemStr);
                return I;
            } return null;
        }

    }
}
