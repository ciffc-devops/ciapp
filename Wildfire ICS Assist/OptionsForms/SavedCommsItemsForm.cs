using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist.OptionsForms
{
    public partial class SavedCommsItemsForm : Form
    {
        public SavedCommsItemsForm()
        {
            this.Icon = Program.programIcon;
            InitializeComponent();
        }

        private void SavedCommsItems_Load(object sender, EventArgs e)
        {
            dgvCommsItems.AutoGenerateColumns = false;
            buildCommsItemList();

        }

        private void buildCommsItemList()
        {
            dgvCommsItems.DataSource = null;
            List<CommsPlanItem> items = (List<CommsPlanItem>) Program.generalOptionsService.GetOptionsValue("CommsItems");
            items = items.Where(o=>o.Active).OrderBy(o=>o.ChannelID).ToList();
            dgvCommsItems.DataSource = items;

        }

        private void openItemForEdit(CommsPlanItem item)
        {
            using(EditCommsItemForm editCommsItem = new EditCommsItemForm())
            {
                editCommsItem.commsPlanItem = item.Clone();
                DialogResult dr = editCommsItem.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    Program.generalOptionsService.UpserOptionValue(editCommsItem.commsPlanItem, "CommsItem");
                    buildCommsItemList();


                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            CommsPlanItem item = new CommsPlanItem();
            item.Active = true;
            openItemForEdit(item);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           if(dgvCommsItems.SelectedRows.Count == 1)
            {
                CommsPlanItem item = (CommsPlanItem)dgvCommsItems.SelectedRows[0].DataBoundItem;
                openItemForEdit(item);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCommsItems.SelectedRows.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete the selected comms item(s)?", "Delete?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvCommsItems.SelectedRows)
                    {
                        CommsPlanItem h = (CommsPlanItem)((DataGridViewRow)row).DataBoundItem;
                        h.Active = false;
                        Program.generalOptionsService.UpserOptionValue(h, "CommsItem");
                    }
                    buildCommsItemList();
                }
            }

        }

        private void dgvCommsItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CommsPlanItem item = (CommsPlanItem)dgvCommsItems.Rows[e.RowIndex].DataBoundItem;
                openItemForEdit(item);
            }

        }

        private void dgvCommsItems_SelectionChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = (dgvCommsItems.SelectedRows.Count > 0);
            btnEdit.Enabled = (dgvCommsItems.SelectedRows.Count == 1);

        }
    }
}
