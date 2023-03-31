namespace Wildfire_ICS_Assist
{
    partial class VehicleEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            WF_ICS_ClassLibrary.Models.Vehicle vehicle1 = new WF_ICS_ClassLibrary.Models.Vehicle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnUseSaved = new System.Windows.Forms.Button();
            this.cboSavedVehicles = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkSaveForLater = new System.Windows.Forms.CheckBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.vehicleEquipmentEditControl1 = new Wildfire_ICS_Assist.CustomControls.VehicleEquipmentEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.AutoScrollMinSize = new System.Drawing.Size(10, 400);
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(824, 683);
            this.splitContainer1.SplitterDistance = 613;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.btnUseSaved);
            this.splitContainer2.Panel1.Controls.Add(this.cboSavedVehicles);
            this.splitContainer2.Panel1.Controls.Add(this.label14);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.vehicleEquipmentEditControl1);
            this.splitContainer2.Panel2.Controls.Add(this.chkSaveForLater);
            this.splitContainer2.Panel2.Controls.Add(this.btnAddNew);
            this.splitContainer2.Size = new System.Drawing.Size(824, 613);
            this.splitContainer2.SplitterDistance = 67;
            this.splitContainer2.TabIndex = 105;
            // 
            // btnUseSaved
            // 
            this.btnUseSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUseSaved.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnUseSaved.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUseSaved.Location = new System.Drawing.Point(621, 11);
            this.btnUseSaved.Name = "btnUseSaved";
            this.btnUseSaved.Size = new System.Drawing.Size(189, 45);
            this.btnUseSaved.TabIndex = 2;
            this.btnUseSaved.Text = "Add to Incident";
            this.btnUseSaved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUseSaved.UseVisualStyleBackColor = true;
            this.btnUseSaved.Click += new System.EventHandler(this.btnUseSaved_Click);
            // 
            // cboSavedVehicles
            // 
            this.cboSavedVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedVehicles.DisplayMember = "IDWithMakeOwner";
            this.cboSavedVehicles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSavedVehicles.FormattingEnabled = true;
            this.cboSavedVehicles.Location = new System.Drawing.Point(158, 17);
            this.cboSavedVehicles.Name = "cboSavedVehicles";
            this.cboSavedVehicles.Size = new System.Drawing.Size(449, 32);
            this.cboSavedVehicles.TabIndex = 1;
            this.cboSavedVehicles.ValueMember = "VehicleID";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(11, 8);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(141, 50);
            this.label14.TabIndex = 0;
            this.label14.Text = "Saved Vehicles and Equipment";
            // 
            // chkSaveForLater
            // 
            this.chkSaveForLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveForLater.AutoSize = true;
            this.chkSaveForLater.Location = new System.Drawing.Point(374, 497);
            this.chkSaveForLater.Name = "chkSaveForLater";
            this.chkSaveForLater.Size = new System.Drawing.Size(229, 28);
            this.chkSaveForLater.TabIndex = 16;
            this.chkSaveForLater.Text = "Save for future incidents";
            this.chkSaveForLater.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnAddNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNew.Location = new System.Drawing.Point(612, 486);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(204, 48);
            this.btnAddNew.TabIndex = 106;
            this.btnAddNew.Text = "Add to Incident";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(701, 6);
            this.btnSave.Margin = new System.Windows.Forms.Padding(6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 48);
            this.btnSave.TabIndex = 107;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(6, 6);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // vehicleEquipmentEditControl1
            // 
            this.vehicleEquipmentEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            vehicle1.Active = true;
            vehicle1.AgencyOrOwner = null;
            vehicle1.ASE = null;
            vehicle1.CategoryKindCapacity = null;
            vehicle1.Classification = null;
            vehicle1.Features = null;
            vehicle1.ID = new System.Guid("74d4cf06-1228-4657-9d0e-c0fea9cffe87");
            vehicle1.IncidentAssignment = null;
            vehicle1.IncidentIDNo = null;
            vehicle1.Kind = null;
            vehicle1.LastUpdatedUTC = new System.DateTime(2023, 3, 7, 20, 9, 13, 13);
            vehicle1.LicenseOrID = null;
            vehicle1.Make = null;
            vehicle1.MustBeOutTime = new System.DateTime(((long)(0)));
            vehicle1.Notes = null;
            vehicle1.OperatorName = null;
            vehicle1.OpPeriod = 0;
            vehicle1.OrderRequestNo = null;
            vehicle1.ResourceIdentifier = null;
            vehicle1.ResourceName = null;
            vehicle1.StartTime = new System.DateTime(((long)(0)));
            vehicle1.TaskID = new System.Guid("00000000-0000-0000-0000-000000000000");
            vehicle1.Type = null;
            this.vehicleEquipmentEditControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleEquipmentEditControl1.Location = new System.Drawing.Point(5, 6);
            this.vehicleEquipmentEditControl1.Margin = new System.Windows.Forms.Padding(6);
            this.vehicleEquipmentEditControl1.Name = "vehicleEquipmentEditControl1";
            this.vehicleEquipmentEditControl1.Size = new System.Drawing.Size(811, 476);
            this.vehicleEquipmentEditControl1.TabIndex = 107;
            // 
            // VehicleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 683);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VehicleEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add / Enter a Vehicle/Equipment";
            this.Load += new System.EventHandler(this.VehicleEditForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnUseSaved;
        private System.Windows.Forms.ComboBox cboSavedVehicles;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkSaveForLater;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnSave;
        private CustomControls.VehicleEquipmentEditControl vehicleEquipmentEditControl1;
    }
}