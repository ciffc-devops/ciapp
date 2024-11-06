using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class NetworkSelectIPForm : BaseForm
    {
        public NetworkSelectIPForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
        }

        public List<string> ipAddresses { get; set; } = new List<string>();
        public string SelectedAddress { get { if (cboIPs.SelectedItem != null) { return cboIPs.SelectedItem.ToString(); } else { return null; } } }

        private void NetworkSelectIPForm_Load(object sender, EventArgs e)
        {
            ipAddresses = ipAddresses.OrderBy(o => o).ToList();
            cboIPs.DataSource = ipAddresses;
            try
            {
                object objLastIpUsedWhenMachineIsServer = Program.generalOptionsService.GetOptionsValue("LastIpUsedWhenMachineIsServer");
                if (objLastIpUsedWhenMachineIsServer != null)
                {
                    string LastIpUsedWhenMachineIsServer = objLastIpUsedWhenMachineIsServer.ToString();

                    if (!string.IsNullOrEmpty(LastIpUsedWhenMachineIsServer))
                    {

                        for (int x = 0; x < ipAddresses.Count; x++)
                        {
                            if (ipAddresses[x].Equals(LastIpUsedWhenMachineIsServer))
                            {
                                cboIPs.SelectedIndex = x;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }


}
