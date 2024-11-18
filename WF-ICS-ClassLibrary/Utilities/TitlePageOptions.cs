using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Utilities
{
    public class TitlePageOptions
    {
        public bool IncludeOrganizationLogo { get => LogoImage != null && LogoImage.Length > 0; }
        public bool IncludeMessage { get => !string.IsNullOrEmpty(Message); }
        public bool IncludeQRCode { get => !string.IsNullOrEmpty(QRText) || !string.IsNullOrEmpty(QRInstructions); }
        public bool IncludeTitleImage { get => TitleImage != null && TitleImage.Length > 0; }
        public int NumberOfItemsIncluded
        {
            get
            {
                int count = 0;
                if (IncludeOrganizationLogo) count++;
                if (IncludeMessage) count++;
                if (IncludeQRCode) count++;
                if (IncludeTitleImage) count++;
                return count;
            }
        }

        public string Message { get; set; }
        public byte[] TitleImage { get; set; }
        public byte[] LogoImage { get; set; }

        public string QRText { get; set; }
        public string QRInstructions { get; set; }
    }
}
