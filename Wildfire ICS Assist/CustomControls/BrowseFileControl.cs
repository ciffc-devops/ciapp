using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wildfire_ICS_Assist.CustomControls
{
    public partial class BrowseFileControl : UserControl
    {
        private string _FileName;
        public string FileName { get => _FileName; set { _FileName = value; txtFilePath.Text = _FileName; } }
        public string FileTitle { get; set; }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("The file filters to display in the dialog box")]
        public string Filter { get => openFileDialog1.Filter; set => openFileDialog1.Filter = value; }

        [Browsable(true)]
        [Category("Appearance")]
        [Description("The file filters to display in the dialog box")]
        public bool ShowFileTitle { get => !splitContainer1.Panel1Collapsed; set => splitContainer1.Panel1Collapsed = !value; }


        public BrowseFileControl()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(openFileDialog1.FileName) && File.Exists(openFileDialog1.FileName))
                {
                    FileName = openFileDialog1.FileName;
                    txtFilePath.Text = FileName;
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            FileName = string.Empty;
        }
    }
}
