using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist.UtilityForms
{
    public partial class TaskUpdateDetailsForm : BaseForm
    {
        public TaskUpdateDetailsForm()
        {
            InitializeComponent(); SetControlColors(this.Controls);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


        }

        private TaskUpdate updateToView = null;
        public void SetTaskUpdate(TaskUpdate update)
        {
            updateToView = update;
            DisplayUpdate();
        }
        private void DisplayUpdate()
        {
            List<Tuple<string, string>> data = new List<Tuple<string, string>>();
            data.Add(new Tuple<string, string>("Update ID", updateToView.UpdateID.ToString()));
            data.Add(new Tuple<string, string>("TaskID", updateToView.TaskID.ToString()));
            data.Add(new Tuple<string, string>("LastUpdatedUTC", updateToView.LastUpdatedUTC.ToString()));
            data.Add(new Tuple<string, string>("LastUpdateLocal", updateToView.LastUpdateLocal.ToString()));
            data.Add(new Tuple<string, string>("SoftwareVersionText", updateToView.SoftwareVersionText));
            data.Add(new Tuple<string, string>("CommandName", updateToView.CommandName));
            data.Add(new Tuple<string, string>("ObjectType", updateToView.ObjectType));
            data.Add(new Tuple<string, string>("Source", updateToView.Source));
            data.Add(new Tuple<string, string>("CreatedByRoleName", updateToView.CreatedByRoleName));
            data.Add(new Tuple<string, string>("ItemID", updateToView.ItemID.ToString()));
            data.Add(new Tuple<string, string>("ProcessedLocally", updateToView.ProcessedLocally.ToString()));
            data.Add(new Tuple<string, string>("UploadedSuccessfully", updateToView.UploadedSuccessfully.ToString()));
            data.Add(new Tuple<string, string>("MachineID", updateToView.MachineID.ToString()));
            data.Add(new Tuple<string, string>("Data", JsonSerializer.Serialize(updateToView.Data)));
            dataGridView1.DataSource = data;
        }
    }
}
