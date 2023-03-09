using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WF_ICS_ClassLibrary.EventHandling;
using WF_ICS_ClassLibrary.Models;

namespace Wildfire_ICS_Assist
{
    public partial class CheckedInResourcesForm : Form
    {
        public CheckedInResourcesForm()
        {
            InitializeComponent(); this.Icon = Program.programIcon; this.BackColor = Program.FormBackground;
        }

        private void CheckedInResourcesForm_Load(object sender, EventArgs e)
        {
            dgvResources.AutoGenerateColumns = false;
            cboResourceVariety.SelectedIndex = 0;
            LoadResourcesList();

            Program.wfIncidentService.MemberSignInChanged += Program_CheckInChanged;

        }

        private void Program_CheckInChanged(MemberEventArgs e)
        {
            if((e.signInRecord != null && e.signInRecord.OpPeriod == Program.CurrentOpPeriod))
            {
                LoadResourcesList();
            }
        }


        private bool StartCheckIn(bool autoStart, CheckInRecord existingRecord = null)
        {
            bool autoStartNextCheckin = false;
            using (CheckInForm signInForm = new CheckInForm())
            {
                if(existingRecord != null) { signInForm.SetCheckIn(existingRecord); }

                signInForm.AutoStartNextCheckin = autoStart;
                DialogResult dr = signInForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //get the resource and add it to the appropriate place
                    CheckInRecord record = signInForm.checkInRecord;
                    IncidentResource resource = signInForm.selectedResource;
                    switch (record.ResourceType)
                    {
                        case "Personnel":
                            Personnel p = resource as Personnel;
                            if (string.IsNullOrEmpty(p.LeaderName)) { p.LeaderName = p.Name; }
                            Program.wfIncidentService.UpsertPersonnel(p);
                            break;
                        case "Visitor":
                            Personnel vis = resource as Personnel;
                            Program.wfIncidentService.UpsertPersonnel(vis);
                            break;
                        case "Vehicle/Equipment":
                            Vehicle v = resource as Vehicle;
                            Program.wfIncidentService.UpsertVehicle(v);
                            break;
                        case "Crew":
                            OperationalSubGroup group = resource as OperationalSubGroup;
                            group.Kind = "Crew";
                            if (group.ActiveResourceListing.Any(o => o.IsLeader)) { group.LeaderID = group.ActiveResourceListing.First(o => o.IsLeader).ResourceID; group.LeaderName = group.ActiveResourceListing.First(o => o.IsLeader).ResourceName; }
                            List<OperationalGroupResourceListing> toRemoveFromCrew = signInForm.resourcesToRemoveFromCrew;
                            foreach (OperationalGroupResourceListing l in toRemoveFromCrew)
                            {
                                if (Program.CurrentIncident.AllOperationalSubGroups.Any(o => o.ResourceListing.Any(r => r.ResourceID == l.ResourceID) && o.OpPeriod == Program.CurrentOpPeriod))
                                {
                                    OperationalSubGroup sub = Program.CurrentIncident.AllOperationalSubGroups.First(o => o.ResourceListing.Any(r => r.ResourceID == l.ResourceID) && o.OpPeriod == Program.CurrentOpPeriod);
                                    sub.ResourceListing = sub.ResourceListing.Where(o => o.ResourceID != l.ResourceID).ToList();
                                    Program.wfIncidentService.UpsertOperationalSubGroup(sub);
                                }

                                if (Program.CurrentIncident.AllCheckInRecords.Any(o => o.ResourceID == l.ResourceID && o.OpPeriod == Program.CurrentOpPeriod))
                                {
                                    Program.CurrentIncident.AllCheckInRecords.First(o => o.ResourceID == l.ResourceID && o.OpPeriod == Program.CurrentOpPeriod).ParentRecordID = Guid.Empty;
                                    Program.wfIncidentService.UpsertCheckInRecord(Program.CurrentIncident.AllCheckInRecords.First(o => o.ResourceID == l.ResourceID && o.OpPeriod == Program.CurrentOpPeriod));
                                }


                            }


                            Program.wfIncidentService.UpsertOperationalSubGroup(group);
                            foreach (IncidentResource subres in signInForm.SubResources)
                            {
                                if (subres.GetType().Name.Equals("Personnel"))
                                {
                                    subres.OpPeriod = Program.CurrentOpPeriod;
                                    Program.wfIncidentService.UpsertPersonnel(subres as Personnel);
                                    CheckInRecord prec = signInForm.checkInRecord.Clone();
                                    prec.ResourceID = subres.ID;
                                    prec.SignInRecordID = Guid.NewGuid();
                                    prec.ParentRecordID = record.SignInRecordID;
                                    prec.ResourceType = "Personnel";
                                    Program.wfIncidentService.UpsertCheckInRecord(prec);
                                }
                                else if (subres.GetType().Name.Equals("Vehicle"))
                                {
                                    Vehicle vh = subres as Vehicle;
                                    vh.OperatorName = group.ResourceName;
                                    Program.wfIncidentService.UpsertVehicle(vh);
                                    CheckInRecord vrec = signInForm.checkInRecord.Clone();
                                    vrec.ResourceID = subres.ID;
                                    vrec.SignInRecordID = Guid.NewGuid();
                                    vrec.ParentRecordID = record.SignInRecordID;
                                    vrec.ResourceType = "Vehicle/Equipment";
                                    Program.wfIncidentService.UpsertCheckInRecord(vrec);
                                }
                            }
                            break;
                    }


                    Program.wfIncidentService.UpsertCheckInRecord(record);

                    autoStartNextCheckin = signInForm.AutoStartNextCheckin;
                }
            }
            return autoStartNextCheckin;
        }


        private void LoadResourcesList()
        {
            List<CheckInRecordWithResource> checkInRecords = new List<CheckInRecordWithResource>();
            foreach (CheckInRecord rec in Program.CurrentIncident.AllCheckInRecords.Where(o => o.OpPeriod == Program.CurrentOpPeriod && o.Active && o.ParentRecordID == Guid.Empty))
            {
                IncidentResource resource = new IncidentResource();

                if (rec.IsPerson || rec.IsVisitor)
                {
                    if (Program.CurrentIncident.IncidentPersonnel.Any(o => o.ID == rec.ResourceID))
                    {
                        resource = Program.CurrentIncident.IncidentPersonnel.First(o => o.ID == rec.ResourceID);
                    }
                }
                else if (rec.IsVehicle)
                {
                    if (Program.CurrentIncident.allVehicles.Any(o => o.ID == rec.ResourceID && o.Active))
                    {
                        resource = Program.CurrentIncident.allVehicles.First(o => o.ID == rec.ResourceID && o.Active);
                    }
                }
                else if (rec.IsCrew)
                {
                    if (Program.CurrentIncident.ActiveOperationalSubGroups.Any(o => o.ID == rec.ResourceID))
                    {
                        resource = Program.CurrentIncident.ActiveOperationalSubGroups.First(o => o.ID == rec.ResourceID);
                    }
                }
                if (resource != null)
                {
                    checkInRecords.Add(new CheckInRecordWithResource(rec, resource));
                }
            }
            checkInRecords = checkInRecords.OrderBy(o=>o.ResourceName).ToList();

            if(cboResourceVariety.SelectedIndex > 0)
            {
                string variety = cboResourceVariety.Text;
                checkInRecords = checkInRecords.Where(o => o.ResourceType.Equals(variety)).ToList(); ;
            }

            dgvResources.DataSource = checkInRecords;
        }

        private void btnLogisticsSignIn_Click(object sender, EventArgs e)
        {
            bool autoStartCheckin = false;
            do
            {
                autoStartCheckin = StartCheckIn(autoStartCheckin);
            }while (autoStartCheckin);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dgvResources.SelectedRows.Count == 1)
            {
                CheckInRecordWithResource rec = (CheckInRecordWithResource)dgvResources.SelectedRows[0].DataBoundItem;
                StartCheckIn(false, rec.Record);
            }
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            cpFilters.Width = splitContainer2.Panel2.Width - 10;
            cpFilters.ExpandedWidth = cpFilters.Width;
            cpFilters.CollapsedWidth = cpFilters.Width;

        }

        private void splitContainer2_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {
        }

        private void cboResourceVariety_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadResourcesList();

        }
    }
}
