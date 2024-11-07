using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wildfire_ICS_Assist.CustomControls
{
    public static class TabControlExt
    {
        public static void tabControlCustomColor_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            TabControl tcStatus = (TabControl)sender;
            
            TabPage CurrentTab = tcStatus.TabPages[e.Index];
            CurrentTab.BackColor = Program.FormBackgroundColor;
            Rectangle ItemRect = tcStatus.GetTabRect(e.Index);
            SolidBrush FillBrush = new SolidBrush(Program.AccentColor);
            SolidBrush TextBrush = new SolidBrush(Program.DarkAccentColor);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //If we are currently painting the Selected TabItem we'll
            //change the brush colors and inflate the rectangle.
            if (System.Convert.ToBoolean(e.State & DrawItemState.Selected))
            {
                FillBrush.Color = Color.White;
                TextBrush.Color = Color.Black;
                ItemRect.Inflate(2, 2);
            }

            //Set up rotation for left and right aligned tabs
            if (tcStatus.Alignment == TabAlignment.Left || tcStatus.Alignment == TabAlignment.Right)
            {
                float RotateAngle = 90;
                if (tcStatus.Alignment == TabAlignment.Left)
                    RotateAngle = 270;
                PointF cp = new PointF(ItemRect.Left + (ItemRect.Width / 2), ItemRect.Top + (ItemRect.Height / 2));
                e.Graphics.TranslateTransform(cp.X, cp.Y);
                e.Graphics.RotateTransform(RotateAngle);
                ItemRect = new Rectangle(-(ItemRect.Height / 2), -(ItemRect.Width / 2), ItemRect.Height, ItemRect.Width);
            }

            //Next we'll paint the TabItem with our Fill Brush
            e.Graphics.FillRectangle(FillBrush, ItemRect);

            //Now draw the text.
             e.Graphics.DrawString(CurrentTab.Text, e.Font, TextBrush, (RectangleF)ItemRect, sf); 

            //Reset any Graphics rotation
            e.Graphics.ResetTransform();

            //Finally, we should Dispose of our brushes.
            FillBrush.Dispose();
            TextBrush.Dispose();
        }

    }
}
