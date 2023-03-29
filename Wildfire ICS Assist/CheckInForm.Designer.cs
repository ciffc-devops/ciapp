namespace Wildfire_ICS_Assist
{
    partial class CheckInForm
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
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.wizardPages1 = new Wildfire_ICS_Assist.CustomControls.WizardPages();
            this.tpCheckInType = new System.Windows.Forms.TabPage();
            this.btnHECrew = new System.Windows.Forms.Button();
            this.btnEquipAndOperator = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnVisitor = new System.Windows.Forms.Button();
            this.btnSinglePersonnel = new System.Windows.Forms.Button();
            this.btnVehicleEquipment = new System.Windows.Forms.Button();
            this.btnCrew = new System.Windows.Forms.Button();
            this.tpResourceDetails = new System.Windows.Forms.TabPage();
            this.pnlPersonEdit = new System.Windows.Forms.Panel();
            this.personnelEditControl1 = new Wildfire_ICS_Assist.CustomControls.PersonnelEditControl();
            this.chkSavePersonForLater = new System.Windows.Forms.CheckBox();
            this.lblEditPersonTitle = new System.Windows.Forms.Label();
            this.btnSelectNewPerson = new System.Windows.Forms.Button();
            this.pnlSavedPersonnel = new System.Windows.Forms.Panel();
            this.btnSelectSavedPerson = new System.Windows.Forms.Button();
            this.cboSavedPersonnel = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tpCrewDetails = new System.Windows.Forms.TabPage();
            this.crewEditControl1 = new Wildfire_ICS_Assist.CustomControls.CrewEditControl();
            this.tpVisitorDetails = new System.Windows.Forms.TabPage();
            this.btnSelectVisitor = new System.Windows.Forms.Button();
            this.visitorEditControl1 = new Wildfire_ICS_Assist.CustomControls.VisitorEditControl();
            this.label19 = new System.Windows.Forms.Label();
            this.tpVehiclesEquipment = new System.Windows.Forms.TabPage();
            this.pnlEditVehicle = new System.Windows.Forms.Panel();
            this.lblEditVehicleTitle = new System.Windows.Forms.Label();
            this.vehicleEquipmentEditControl1 = new Wildfire_ICS_Assist.CustomControls.VehicleEquipmentEditControl();
            this.chkSaveVehicleForLater = new System.Windows.Forms.CheckBox();
            this.btnSelectNewVehicle = new System.Windows.Forms.Button();
            this.pnlSavedVehicle = new System.Windows.Forms.Panel();
            this.cboSavedOperator = new System.Windows.Forms.ComboBox();
            this.lblSavedOperator = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnSelectSavedVehicle = new System.Windows.Forms.Button();
            this.cboSavedVehicles = new System.Windows.Forms.ComboBox();
            this.tpCheckInDetails = new System.Windows.Forms.TabPage();
            this.resourceCheckInEditControl1 = new Wildfire_ICS_Assist.CustomControls.ResourceCheckInEditControl();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDoneCrewEdit = new System.Windows.Forms.Button();
            this.chkAutoNewCheckin = new System.Windows.Forms.CheckBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.wizardPages1.SuspendLayout();
            this.tpCheckInType.SuspendLayout();
            this.tpResourceDetails.SuspendLayout();
            this.pnlPersonEdit.SuspendLayout();
            this.pnlSavedPersonnel.SuspendLayout();
            this.tpCrewDetails.SuspendLayout();
            this.tpVisitorDetails.SuspendLayout();
            this.tpVehiclesEquipment.SuspendLayout();
            this.pnlEditVehicle.SuspendLayout();
            this.pnlSavedVehicle.SuspendLayout();
            this.tpCheckInDetails.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.wizardPages1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnDoneCrewEdit);
            this.splitContainer1.Panel2.Controls.Add(this.chkAutoNewCheckin);
            this.splitContainer1.Panel2.Controls.Add(this.btnBack);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnCheckIn);
            this.splitContainer1.Size = new System.Drawing.Size(785, 1066);
            this.splitContainer1.SplitterDistance = 997;
            this.splitContainer1.TabIndex = 149;
            // 
            // wizardPages1
            // 
            this.wizardPages1.Controls.Add(this.tpCheckInType);
            this.wizardPages1.Controls.Add(this.tpResourceDetails);
            this.wizardPages1.Controls.Add(this.tpCrewDetails);
            this.wizardPages1.Controls.Add(this.tpVisitorDetails);
            this.wizardPages1.Controls.Add(this.tpVehiclesEquipment);
            this.wizardPages1.Controls.Add(this.tpCheckInDetails);
            this.wizardPages1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardPages1.Location = new System.Drawing.Point(0, 0);
            this.wizardPages1.Name = "wizardPages1";
            this.wizardPages1.SelectedIndex = 0;
            this.wizardPages1.Size = new System.Drawing.Size(785, 997);
            this.wizardPages1.TabIndex = 148;
            this.wizardPages1.SelectedIndexChanged += new System.EventHandler(this.wizardPages1_SelectedIndexChanged);
            // 
            // tpCheckInType
            // 
            this.tpCheckInType.Controls.Add(this.btnHECrew);
            this.tpCheckInType.Controls.Add(this.btnEquipAndOperator);
            this.tpCheckInType.Controls.Add(this.label14);
            this.tpCheckInType.Controls.Add(this.btnVisitor);
            this.tpCheckInType.Controls.Add(this.btnSinglePersonnel);
            this.tpCheckInType.Controls.Add(this.btnVehicleEquipment);
            this.tpCheckInType.Controls.Add(this.btnCrew);
            this.tpCheckInType.Location = new System.Drawing.Point(4, 33);
            this.tpCheckInType.Name = "tpCheckInType";
            this.tpCheckInType.Padding = new System.Windows.Forms.Padding(3);
            this.tpCheckInType.Size = new System.Drawing.Size(777, 960);
            this.tpCheckInType.TabIndex = 0;
            this.tpCheckInType.Text = "Check In Type";
            // 
            // btnHECrew
            // 
            this.btnHECrew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHECrew.Image = global::Wildfire_ICS_Assist.Properties.Resources.HECrew;
            this.btnHECrew.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnHECrew.Location = new System.Drawing.Point(381, 357);
            this.btnHECrew.Name = "btnHECrew";
            this.btnHECrew.Size = new System.Drawing.Size(243, 91);
            this.btnHECrew.TabIndex = 11;
            this.btnHECrew.Text = "Heavy Equipment Crew";
            this.btnHECrew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHECrew.UseVisualStyleBackColor = true;
            this.btnHECrew.Click += new System.EventHandler(this.btnHECrew_Click);
            // 
            // btnEquipAndOperator
            // 
            this.btnEquipAndOperator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEquipAndOperator.Image = global::Wildfire_ICS_Assist.Properties.Resources.EquipOp;
            this.btnEquipAndOperator.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEquipAndOperator.Location = new System.Drawing.Point(381, 454);
            this.btnEquipAndOperator.Name = "btnEquipAndOperator";
            this.btnEquipAndOperator.Size = new System.Drawing.Size(243, 91);
            this.btnEquipAndOperator.TabIndex = 10;
            this.btnEquipAndOperator.Text = "Equipment";
            this.btnEquipAndOperator.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEquipAndOperator.UseVisualStyleBackColor = true;
            this.btnEquipAndOperator.Click += new System.EventHandler(this.btnEquipAndOperator_Click);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 308);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(765, 29);
            this.label14.TabIndex = 9;
            this.label14.Text = "What type of resource would you like to check in?";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnVisitor
            // 
            this.btnVisitor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVisitor.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_35_user_incognito;
            this.btnVisitor.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVisitor.Location = new System.Drawing.Point(381, 551);
            this.btnVisitor.Name = "btnVisitor";
            this.btnVisitor.Size = new System.Drawing.Size(243, 91);
            this.btnVisitor.TabIndex = 3;
            this.btnVisitor.Text = "Visitor";
            this.btnVisitor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVisitor.UseVisualStyleBackColor = true;
            this.btnVisitor.Click += new System.EventHandler(this.btnVisitor_Click);
            // 
            // btnSinglePersonnel
            // 
            this.btnSinglePersonnel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSinglePersonnel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_4_user;
            this.btnSinglePersonnel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSinglePersonnel.Location = new System.Drawing.Point(132, 551);
            this.btnSinglePersonnel.Name = "btnSinglePersonnel";
            this.btnSinglePersonnel.Size = new System.Drawing.Size(243, 91);
            this.btnSinglePersonnel.TabIndex = 2;
            this.btnSinglePersonnel.Text = "Individual Personnel";
            this.btnSinglePersonnel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSinglePersonnel.UseVisualStyleBackColor = true;
            this.btnSinglePersonnel.Click += new System.EventHandler(this.btnSinglePersonnel_Click);
            // 
            // btnVehicleEquipment
            // 
            this.btnVehicleEquipment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVehicleEquipment.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_29_cars;
            this.btnVehicleEquipment.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVehicleEquipment.Location = new System.Drawing.Point(132, 454);
            this.btnVehicleEquipment.Name = "btnVehicleEquipment";
            this.btnVehicleEquipment.Size = new System.Drawing.Size(243, 91);
            this.btnVehicleEquipment.TabIndex = 1;
            this.btnVehicleEquipment.Text = "Vehicle";
            this.btnVehicleEquipment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVehicleEquipment.UseVisualStyleBackColor = true;
            this.btnVehicleEquipment.Click += new System.EventHandler(this.btnVehicleEquipment_Click);
            // 
            // btnCrew
            // 
            this.btnCrew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCrew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_532_user_family;
            this.btnCrew.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCrew.Location = new System.Drawing.Point(132, 357);
            this.btnCrew.Name = "btnCrew";
            this.btnCrew.Size = new System.Drawing.Size(243, 91);
            this.btnCrew.TabIndex = 0;
            this.btnCrew.Text = "Crew";
            this.btnCrew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCrew.UseVisualStyleBackColor = true;
            this.btnCrew.Click += new System.EventHandler(this.btnCrew_Click);
            // 
            // tpResourceDetails
            // 
            this.tpResourceDetails.Controls.Add(this.pnlPersonEdit);
            this.tpResourceDetails.Controls.Add(this.pnlSavedPersonnel);
            this.tpResourceDetails.Location = new System.Drawing.Point(4, 22);
            this.tpResourceDetails.Name = "tpResourceDetails";
            this.tpResourceDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpResourceDetails.Size = new System.Drawing.Size(777, 971);
            this.tpResourceDetails.TabIndex = 1;
            this.tpResourceDetails.Text = "Person";
            // 
            // pnlPersonEdit
            // 
            this.pnlPersonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPersonEdit.Controls.Add(this.personnelEditControl1);
            this.pnlPersonEdit.Controls.Add(this.chkSavePersonForLater);
            this.pnlPersonEdit.Controls.Add(this.lblEditPersonTitle);
            this.pnlPersonEdit.Controls.Add(this.btnSelectNewPerson);
            this.pnlPersonEdit.Location = new System.Drawing.Point(8, 92);
            this.pnlPersonEdit.Name = "pnlPersonEdit";
            this.pnlPersonEdit.Size = new System.Drawing.Size(757, 873);
            this.pnlPersonEdit.TabIndex = 113;
            // 
            // personnelEditControl1
            // 
            this.personnelEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.personnelEditControl1.BackColor = System.Drawing.Color.Transparent;
            this.personnelEditControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personnelEditControl1.Location = new System.Drawing.Point(12, 44);
            this.personnelEditControl1.Margin = new System.Windows.Forms.Padding(6);
            this.personnelEditControl1.MinimumSize = new System.Drawing.Size(442, 702);
            this.personnelEditControl1.Name = "personnelEditControl1";
            this.personnelEditControl1.Size = new System.Drawing.Size(739, 774);
            this.personnelEditControl1.TabIndex = 9;
            // 
            // chkSavePersonForLater
            // 
            this.chkSavePersonForLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSavePersonForLater.AutoSize = true;
            this.chkSavePersonForLater.Location = new System.Drawing.Point(386, 834);
            this.chkSavePersonForLater.Name = "chkSavePersonForLater";
            this.chkSavePersonForLater.Size = new System.Drawing.Size(229, 28);
            this.chkSavePersonForLater.TabIndex = 112;
            this.chkSavePersonForLater.Text = "Save for future incidents";
            this.chkSavePersonForLater.UseVisualStyleBackColor = true;
            // 
            // lblEditPersonTitle
            // 
            this.lblEditPersonTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEditPersonTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditPersonTitle.Location = new System.Drawing.Point(10, 9);
            this.lblEditPersonTitle.Name = "lblEditPersonTitle";
            this.lblEditPersonTitle.Size = new System.Drawing.Size(735, 29);
            this.lblEditPersonTitle.TabIndex = 8;
            this.lblEditPersonTitle.Text = "New Personnel";
            // 
            // btnSelectNewPerson
            // 
            this.btnSelectNewPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectNewPerson.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnSelectNewPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectNewPerson.Location = new System.Drawing.Point(621, 827);
            this.btnSelectNewPerson.Name = "btnSelectNewPerson";
            this.btnSelectNewPerson.Size = new System.Drawing.Size(130, 40);
            this.btnSelectNewPerson.TabIndex = 7;
            this.btnSelectNewPerson.Text = "Select";
            this.btnSelectNewPerson.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSelectNewPerson.UseVisualStyleBackColor = true;
            this.btnSelectNewPerson.Click += new System.EventHandler(this.btnSelectNew_Click);
            // 
            // pnlSavedPersonnel
            // 
            this.pnlSavedPersonnel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSavedPersonnel.BackColor = System.Drawing.Color.White;
            this.pnlSavedPersonnel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSavedPersonnel.Controls.Add(this.btnSelectSavedPerson);
            this.pnlSavedPersonnel.Controls.Add(this.cboSavedPersonnel);
            this.pnlSavedPersonnel.Controls.Add(this.label6);
            this.pnlSavedPersonnel.Location = new System.Drawing.Point(8, 6);
            this.pnlSavedPersonnel.Name = "pnlSavedPersonnel";
            this.pnlSavedPersonnel.Size = new System.Drawing.Size(761, 80);
            this.pnlSavedPersonnel.TabIndex = 1;
            // 
            // btnSelectSavedPerson
            // 
            this.btnSelectSavedPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSavedPerson.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnSelectSavedPerson.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectSavedPerson.Location = new System.Drawing.Point(620, 27);
            this.btnSelectSavedPerson.Name = "btnSelectSavedPerson";
            this.btnSelectSavedPerson.Size = new System.Drawing.Size(130, 40);
            this.btnSelectSavedPerson.TabIndex = 5;
            this.btnSelectSavedPerson.Text = "Select";
            this.btnSelectSavedPerson.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSelectSavedPerson.UseVisualStyleBackColor = true;
            this.btnSelectSavedPerson.Click += new System.EventHandler(this.btnSelectSaved_Click);
            // 
            // cboSavedPersonnel
            // 
            this.cboSavedPersonnel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedPersonnel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSavedPersonnel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSavedPersonnel.DisplayMember = "NameWithAgency";
            this.cboSavedPersonnel.FormattingEnabled = true;
            this.cboSavedPersonnel.Location = new System.Drawing.Point(8, 32);
            this.cboSavedPersonnel.Name = "cboSavedPersonnel";
            this.cboSavedPersonnel.Size = new System.Drawing.Size(606, 32);
            this.cboSavedPersonnel.TabIndex = 4;
            this.cboSavedPersonnel.ValueMember = "PersonID";
            this.cboSavedPersonnel.Leave += new System.EventHandler(this.cboSavedPersonnel_Leave);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(753, 29);
            this.label6.TabIndex = 8;
            this.label6.Text = "Saved Personnel";
            // 
            // tpCrewDetails
            // 
            this.tpCrewDetails.Controls.Add(this.crewEditControl1);
            this.tpCrewDetails.Location = new System.Drawing.Point(4, 22);
            this.tpCrewDetails.Name = "tpCrewDetails";
            this.tpCrewDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpCrewDetails.Size = new System.Drawing.Size(777, 971);
            this.tpCrewDetails.TabIndex = 2;
            this.tpCrewDetails.Text = "Crew";
            // 
            // crewEditControl1
            // 
            this.crewEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crewEditControl1.EditExisting = false;
            this.crewEditControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crewEditControl1.Location = new System.Drawing.Point(0, 0);
            this.crewEditControl1.Margin = new System.Windows.Forms.Padding(6);
            this.crewEditControl1.Name = "crewEditControl1";
            this.crewEditControl1.Size = new System.Drawing.Size(777, 962);
            this.crewEditControl1.TabIndex = 0;
            // 
            // tpVisitorDetails
            // 
            this.tpVisitorDetails.Controls.Add(this.btnSelectVisitor);
            this.tpVisitorDetails.Controls.Add(this.visitorEditControl1);
            this.tpVisitorDetails.Controls.Add(this.label19);
            this.tpVisitorDetails.Location = new System.Drawing.Point(4, 22);
            this.tpVisitorDetails.Name = "tpVisitorDetails";
            this.tpVisitorDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpVisitorDetails.Size = new System.Drawing.Size(777, 971);
            this.tpVisitorDetails.TabIndex = 4;
            this.tpVisitorDetails.Text = "Visitor";
            // 
            // btnSelectVisitor
            // 
            this.btnSelectVisitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectVisitor.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnSelectVisitor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectVisitor.Location = new System.Drawing.Point(636, 288);
            this.btnSelectVisitor.Name = "btnSelectVisitor";
            this.btnSelectVisitor.Size = new System.Drawing.Size(130, 40);
            this.btnSelectVisitor.TabIndex = 12;
            this.btnSelectVisitor.Text = "Select";
            this.btnSelectVisitor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSelectVisitor.UseVisualStyleBackColor = true;
            this.btnSelectVisitor.Click += new System.EventHandler(this.btnSelectVisitor_Click);
            // 
            // visitorEditControl1
            // 
            this.visitorEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visitorEditControl1.BackColor = System.Drawing.Color.Transparent;
            this.visitorEditControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.visitorEditControl1.Location = new System.Drawing.Point(2, 44);
            this.visitorEditControl1.Margin = new System.Windows.Forms.Padding(6);
            this.visitorEditControl1.Name = "visitorEditControl1";
            this.visitorEditControl1.Size = new System.Drawing.Size(764, 235);
            this.visitorEditControl1.TabIndex = 11;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(1, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(765, 46);
            this.label19.TabIndex = 10;
            this.label19.Text = "Visitor";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tpVehiclesEquipment
            // 
            this.tpVehiclesEquipment.Controls.Add(this.pnlEditVehicle);
            this.tpVehiclesEquipment.Controls.Add(this.pnlSavedVehicle);
            this.tpVehiclesEquipment.Location = new System.Drawing.Point(4, 22);
            this.tpVehiclesEquipment.Name = "tpVehiclesEquipment";
            this.tpVehiclesEquipment.Padding = new System.Windows.Forms.Padding(3);
            this.tpVehiclesEquipment.Size = new System.Drawing.Size(777, 971);
            this.tpVehiclesEquipment.TabIndex = 5;
            this.tpVehiclesEquipment.Text = "Veh/Eqp";
            // 
            // pnlEditVehicle
            // 
            this.pnlEditVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEditVehicle.Controls.Add(this.lblEditVehicleTitle);
            this.pnlEditVehicle.Controls.Add(this.vehicleEquipmentEditControl1);
            this.pnlEditVehicle.Controls.Add(this.chkSaveVehicleForLater);
            this.pnlEditVehicle.Controls.Add(this.btnSelectNewVehicle);
            this.pnlEditVehicle.Location = new System.Drawing.Point(6, 137);
            this.pnlEditVehicle.Name = "pnlEditVehicle";
            this.pnlEditVehicle.Size = new System.Drawing.Size(763, 828);
            this.pnlEditVehicle.TabIndex = 116;
            // 
            // lblEditVehicleTitle
            // 
            this.lblEditVehicleTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEditVehicleTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditVehicleTitle.Location = new System.Drawing.Point(3, 8);
            this.lblEditVehicleTitle.Name = "lblEditVehicleTitle";
            this.lblEditVehicleTitle.Size = new System.Drawing.Size(757, 29);
            this.lblEditVehicleTitle.TabIndex = 115;
            this.lblEditVehicleTitle.Text = "New Vehicle / Equipment";
            // 
            // vehicleEquipmentEditControl1
            // 
            this.vehicleEquipmentEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vehicleEquipmentEditControl1.EnableOperatorField = true;
            this.vehicleEquipmentEditControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vehicleEquipmentEditControl1.Location = new System.Drawing.Point(8, 43);
            this.vehicleEquipmentEditControl1.Margin = new System.Windows.Forms.Padding(6);
            this.vehicleEquipmentEditControl1.Name = "vehicleEquipmentEditControl1";
            this.vehicleEquipmentEditControl1.Size = new System.Drawing.Size(749, 722);
            this.vehicleEquipmentEditControl1.TabIndex = 113;
            // 
            // chkSaveVehicleForLater
            // 
            this.chkSaveVehicleForLater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSaveVehicleForLater.AutoSize = true;
            this.chkSaveVehicleForLater.Location = new System.Drawing.Point(406, 786);
            this.chkSaveVehicleForLater.Name = "chkSaveVehicleForLater";
            this.chkSaveVehicleForLater.Size = new System.Drawing.Size(229, 28);
            this.chkSaveVehicleForLater.TabIndex = 111;
            this.chkSaveVehicleForLater.Text = "Save for future incidents";
            this.chkSaveVehicleForLater.UseVisualStyleBackColor = true;
            // 
            // btnSelectNewVehicle
            // 
            this.btnSelectNewVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectNewVehicle.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnSelectNewVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectNewVehicle.Location = new System.Drawing.Point(644, 777);
            this.btnSelectNewVehicle.Margin = new System.Windows.Forms.Padding(6);
            this.btnSelectNewVehicle.Name = "btnSelectNewVehicle";
            this.btnSelectNewVehicle.Size = new System.Drawing.Size(113, 45);
            this.btnSelectNewVehicle.TabIndex = 112;
            this.btnSelectNewVehicle.Text = "Select";
            this.btnSelectNewVehicle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSelectNewVehicle.UseVisualStyleBackColor = true;
            this.btnSelectNewVehicle.Click += new System.EventHandler(this.btnSelectNewVehicle_Click);
            // 
            // pnlSavedVehicle
            // 
            this.pnlSavedVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSavedVehicle.BackColor = System.Drawing.Color.White;
            this.pnlSavedVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSavedVehicle.Controls.Add(this.cboSavedOperator);
            this.pnlSavedVehicle.Controls.Add(this.lblSavedOperator);
            this.pnlSavedVehicle.Controls.Add(this.label22);
            this.pnlSavedVehicle.Controls.Add(this.btnSelectSavedVehicle);
            this.pnlSavedVehicle.Controls.Add(this.cboSavedVehicles);
            this.pnlSavedVehicle.Location = new System.Drawing.Point(8, 15);
            this.pnlSavedVehicle.Name = "pnlSavedVehicle";
            this.pnlSavedVehicle.Size = new System.Drawing.Size(761, 116);
            this.pnlSavedVehicle.TabIndex = 114;
            // 
            // cboSavedOperator
            // 
            this.cboSavedOperator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedOperator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSavedOperator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSavedOperator.DisplayMember = "NameWithKindAndType";
            this.cboSavedOperator.FormattingEnabled = true;
            this.cboSavedOperator.Location = new System.Drawing.Point(129, 74);
            this.cboSavedOperator.Name = "cboSavedOperator";
            this.cboSavedOperator.Size = new System.Drawing.Size(508, 32);
            this.cboSavedOperator.TabIndex = 133;
            this.cboSavedOperator.ValueMember = "ID";
            this.cboSavedOperator.Leave += new System.EventHandler(this.cboSavedOperator_Leave);
            // 
            // lblSavedOperator
            // 
            this.lblSavedOperator.Location = new System.Drawing.Point(11, 77);
            this.lblSavedOperator.Name = "lblSavedOperator";
            this.lblSavedOperator.Size = new System.Drawing.Size(106, 24);
            this.lblSavedOperator.TabIndex = 134;
            this.lblSavedOperator.Text = "Operator";
            this.lblSavedOperator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(3, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(753, 29);
            this.label22.TabIndex = 8;
            this.label22.Text = "Saved Vehicles / Equipment";
            // 
            // btnSelectSavedVehicle
            // 
            this.btnSelectSavedVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSavedVehicle.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnSelectSavedVehicle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectSavedVehicle.Location = new System.Drawing.Point(643, 36);
            this.btnSelectSavedVehicle.Name = "btnSelectSavedVehicle";
            this.btnSelectSavedVehicle.Size = new System.Drawing.Size(113, 70);
            this.btnSelectSavedVehicle.TabIndex = 110;
            this.btnSelectSavedVehicle.Text = "Select";
            this.btnSelectSavedVehicle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSelectSavedVehicle.UseVisualStyleBackColor = true;
            this.btnSelectSavedVehicle.Click += new System.EventHandler(this.btnSelectSavedVehicle_Click);
            // 
            // cboSavedVehicles
            // 
            this.cboSavedVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSavedVehicles.DisplayMember = "IDWithMakeOwner";
            this.cboSavedVehicles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSavedVehicles.FormattingEnabled = true;
            this.cboSavedVehicles.Location = new System.Drawing.Point(8, 36);
            this.cboSavedVehicles.Name = "cboSavedVehicles";
            this.cboSavedVehicles.Size = new System.Drawing.Size(629, 32);
            this.cboSavedVehicles.TabIndex = 109;
            this.cboSavedVehicles.ValueMember = "VehicleID";
            // 
            // tpCheckInDetails
            // 
            this.tpCheckInDetails.Controls.Add(this.resourceCheckInEditControl1);
            this.tpCheckInDetails.Controls.Add(this.label2);
            this.tpCheckInDetails.Location = new System.Drawing.Point(4, 33);
            this.tpCheckInDetails.Name = "tpCheckInDetails";
            this.tpCheckInDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpCheckInDetails.Size = new System.Drawing.Size(777, 960);
            this.tpCheckInDetails.TabIndex = 3;
            this.tpCheckInDetails.Text = "Check In Details";
            // 
            // resourceCheckInEditControl1
            // 
            this.resourceCheckInEditControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resourceCheckInEditControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resourceCheckInEditControl1.Location = new System.Drawing.Point(9, 48);
            this.resourceCheckInEditControl1.Margin = new System.Windows.Forms.Padding(6);
            this.resourceCheckInEditControl1.Name = "resourceCheckInEditControl1";
            this.resourceCheckInEditControl1.Size = new System.Drawing.Size(760, 910);
            this.resourceCheckInEditControl1.TabIndex = 12;
            this.resourceCheckInEditControl1.Load += new System.EventHandler(this.resourceCheckInEditControl1_Load);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(423, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "Check-In Information";
            // 
            // btnDoneCrewEdit
            // 
            this.btnDoneCrewEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoneCrewEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoneCrewEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_224_chevron_right;
            this.btnDoneCrewEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDoneCrewEdit.Location = new System.Drawing.Point(649, 5);
            this.btnDoneCrewEdit.Name = "btnDoneCrewEdit";
            this.btnDoneCrewEdit.Size = new System.Drawing.Size(124, 51);
            this.btnDoneCrewEdit.TabIndex = 8;
            this.btnDoneCrewEdit.Text = "Next";
            this.btnDoneCrewEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDoneCrewEdit.UseVisualStyleBackColor = true;
            this.btnDoneCrewEdit.Visible = false;
            this.btnDoneCrewEdit.Click += new System.EventHandler(this.btnDoneCrewEdit_Click);
            // 
            // chkAutoNewCheckin
            // 
            this.chkAutoNewCheckin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutoNewCheckin.AutoSize = true;
            this.chkAutoNewCheckin.Location = new System.Drawing.Point(324, 17);
            this.chkAutoNewCheckin.Name = "chkAutoNewCheckin";
            this.chkAutoNewCheckin.Size = new System.Drawing.Size(239, 28);
            this.chkAutoNewCheckin.TabIndex = 25;
            this.chkAutoNewCheckin.Text = "Auto start a new check-in";
            this.chkAutoNewCheckin.UseVisualStyleBackColor = true;
            this.chkAutoNewCheckin.Visible = false;
            // 
            // btnBack
            // 
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnBack.Location = new System.Drawing.Point(142, 5);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(124, 51);
            this.btnBack.TabIndex = 22;
            this.btnBack.Text = "Back";
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_799_chevron_last_left;
            this.btnCancel.Location = new System.Drawing.Point(6, 5);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 51);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckIn.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_431_log_in;
            this.btnCheckIn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckIn.Location = new System.Drawing.Point(569, 5);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(204, 51);
            this.btnCheckIn.TabIndex = 24;
            this.btnCheckIn.Text = "Check In";
            this.btnCheckIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Visible = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // CheckInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 1066);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(801, 1008);
            this.Name = "CheckInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Check In Form";
            this.Load += new System.EventHandler(this.PersonnelSignInForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.wizardPages1.ResumeLayout(false);
            this.tpCheckInType.ResumeLayout(false);
            this.tpResourceDetails.ResumeLayout(false);
            this.pnlPersonEdit.ResumeLayout(false);
            this.pnlPersonEdit.PerformLayout();
            this.pnlSavedPersonnel.ResumeLayout(false);
            this.tpCrewDetails.ResumeLayout(false);
            this.tpVisitorDetails.ResumeLayout(false);
            this.tpVehiclesEquipment.ResumeLayout(false);
            this.pnlEditVehicle.ResumeLayout(false);
            this.pnlEditVehicle.PerformLayout();
            this.pnlSavedVehicle.ResumeLayout(false);
            this.tpCheckInDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlSavedPersonnel;
        private System.Windows.Forms.ComboBox cboSavedPersonnel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblEditPersonTitle;
        private System.Windows.Forms.Button btnSelectSavedPerson;
        private System.Windows.Forms.Button btnSelectNewPerson;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private CustomControls.WizardPages wizardPages1;
        private System.Windows.Forms.TabPage tpCheckInType;
        private System.Windows.Forms.TabPage tpResourceDetails;
        private System.Windows.Forms.TabPage tpCrewDetails;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tpCheckInDetails;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnVisitor;
        private System.Windows.Forms.Button btnSinglePersonnel;
        private System.Windows.Forms.Button btnVehicleEquipment;
        private System.Windows.Forms.Button btnCrew;
        private System.Windows.Forms.TabPage tpVisitorDetails;
        private System.Windows.Forms.TabPage tpVehiclesEquipment;
        private System.Windows.Forms.Label label19;
        private CustomControls.PersonnelEditControl personnelEditControl1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlSavedVehicle;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnSelectSavedVehicle;
        private System.Windows.Forms.ComboBox cboSavedVehicles;
        private CustomControls.VehicleEquipmentEditControl vehicleEquipmentEditControl1;
        private System.Windows.Forms.CheckBox chkSaveVehicleForLater;
        private System.Windows.Forms.Button btnSelectNewVehicle;
        private System.Windows.Forms.Label lblEditVehicleTitle;
        private System.Windows.Forms.CheckBox chkSavePersonForLater;
        private System.Windows.Forms.Button btnSelectVisitor;
        private CustomControls.VisitorEditControl visitorEditControl1;
        private System.Windows.Forms.CheckBox chkAutoNewCheckin;
        private CustomControls.ResourceCheckInEditControl resourceCheckInEditControl1;
        private CustomControls.CrewEditControl crewEditControl1;
        private System.Windows.Forms.Button btnDoneCrewEdit;
        private System.Windows.Forms.Panel pnlPersonEdit;
        private System.Windows.Forms.Panel pnlEditVehicle;
        private System.Windows.Forms.ComboBox cboSavedOperator;
        private System.Windows.Forms.Label lblSavedOperator;
        private System.Windows.Forms.Button btnEquipAndOperator;
        private System.Windows.Forms.Button btnHECrew;
    }
}