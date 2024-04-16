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
    public partial class SelectTimeRangeForm : BaseForm
    {
        public DateTime StartTime { get => dateTimePicker1.Value; set { if (value <= dateTimePicker1.MaxDate && value >= dateTimePicker1.MinDate) { dateTimePicker1.Value = value; } } }
        public DateTime EndTime { get => dateTimePicker2.Value; set { if (value <= dateTimePicker2.MaxDate && value >= dateTimePicker2.MinDate) { dateTimePicker2.Value = value; } } }

        public SelectTimeRangeForm()
        {
            InitializeComponent();
        }
    }
}
