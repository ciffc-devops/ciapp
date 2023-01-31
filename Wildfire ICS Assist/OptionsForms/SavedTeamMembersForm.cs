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
    public partial class SavedTeamMembersForm : Form
    {
        public SavedTeamMembersForm()
        {
            InitializeComponent(); this.BackColor = Program.FormBackground; this.Icon = Program.programIcon;
        }

        private void SavedTeamMembersForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }



        private void LoadData()
        {
            dgvTeamMembers.AutoGenerateColumns = false;
            dgvTeamMembers.DataSource = null;
            List<TeamMember> members = (List<TeamMember>)Program.generalOptionsService.GetOptionsValue("TeamMembers");
            members = members.Where(o=>o.MemberActive).OrderBy(o=>o.ProvinceName).ThenBy(o=>o.Agency).ThenBy(o=>o.Name).ToList();
            dgvTeamMembers.DataSource = members;
        }

        private void OpenForEdit(TeamMember member)
        {
            using (EditSavedTeamMemberForm editForm = new EditSavedTeamMemberForm())
            {
                editForm.selectedMember = member.Clone();
                DialogResult dr = editForm.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    Program.generalOptionsService.UpserOptionValue(editForm.selectedMember, "TeamMember");
                    LoadData();
                }

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            TeamMember member = new TeamMember();
            member.MemberActive = true;
            OpenForEdit(member);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvTeamMembers.SelectedRows.Count == 1)
            {
                TeamMember member = dgvTeamMembers.SelectedRows[0].DataBoundItem as TeamMember;
                OpenForEdit(member);
            }
        }

        private void dgvTeamMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                TeamMember member = dgvTeamMembers.Rows[e.RowIndex].DataBoundItem as TeamMember;
                OpenForEdit(member);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.SureDelete, Properties.Resources.SureDeleteTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvTeamMembers.SelectedRows.Count > 0)
                {
                    List<TeamMember> toDelete = new List<TeamMember>();
                    foreach (DataGridViewRow row in dgvTeamMembers.SelectedRows)
                    {
                        toDelete.Add(row.DataBoundItem as TeamMember);
                    }
                    foreach (TeamMember mem in toDelete)
                    {
                        mem.MemberActive = false;
                        Program.generalOptionsService.UpserOptionValue(mem, "TeamMember");

                    }
                    LoadData();

                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (ImportSavedTeamMembersForm importForm = new ImportSavedTeamMembersForm())
            {
                DialogResult dr = importForm.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            svdExport.FileName = "Personnel-" + string.Format("{0:yyyy-MMM-dd}",DateTime.Now) +".csv";
            DialogResult result = svdExport.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(svdExport.FileName))
            {
                string exportPath = svdExport.FileName;
                string delimiter = ",";




                List<TeamMember> members = (List<TeamMember>)Program.generalOptionsService.GetOptionsValue("TeamMembers");
                members = members.Where(o => o.MemberActive).OrderBy(o => o.Agency).ThenBy(o => o.Name).ToList();

                string csv = members.ToCSV(delimiter);
                if (!string.IsNullOrEmpty(csv))
                {
                    try
                    {
                        System.IO.File.WriteAllText(exportPath, csv);

                        DialogResult openNow = MessageBox.Show("The file was saved successfully. Would you like to open it now?", "Save successful!", MessageBoxButtons.YesNo);
                        if (openNow == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(exportPath);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sorry, there was a problem writing to the file.  Please report this error: " + ex.ToString());
                    }
                }
            }
        }
    }
}
