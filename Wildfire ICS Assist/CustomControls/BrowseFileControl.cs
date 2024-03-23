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
        public string FileName { get => _FileName; set { _FileName = value; textBox1.Text = _FileName; } }

        [Browsable(true)]
        [Category("Behavior")]
        [Description("The file filters to display in the dialog box")]
        public string Filter { get => openFileDialog1.Filter; set => openFileDialog1.Filter = value; }
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
                    textBox1.Text = FileName;
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            FileName = string.Empty;
        }
    }
}
