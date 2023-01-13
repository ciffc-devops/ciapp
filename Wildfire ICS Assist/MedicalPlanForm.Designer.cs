namespace Wildfire_ICS_Assist
{
    partial class MedicalPlanForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnDeleteAidStation = new System.Windows.Forms.Button();
            this.btnEditAidStation = new System.Windows.Forms.Button();
            this.btnAddAidStation = new System.Windows.Forms.Button();
            this.dgvAidStations = new System.Windows.Forms.DataGridView();
            this.colAidName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAidLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAidParamedics = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnDeleteTransport = new System.Windows.Forms.Button();
            this.btnEditTransport = new System.Windows.Forms.Button();
            this.btnAddTransport = new System.Windows.Forms.Button();
            this.dgvTransport = new System.Windows.Forms.DataGridView();
            this.colAmbulanceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmbulanceLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteHospital = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEditHospital = new System.Windows.Forms.Button();
            this.dgvHospitals = new System.Windows.Forms.DataGridView();
            this.colHospitalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHospitalLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHospitalTravelAir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHospitalTravelGround = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddHospital = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmergencyProcedures = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPreparedBy = new System.Windows.Forms.ComboBox();
            this.cboApprovedBy = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAidStations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitals)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txtEmergencyProcedures);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.cboPreparedBy);
            this.splitContainer1.Panel2.Controls.Add(this.cboApprovedBy);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1251, 590);
            this.splitContainer1.SplitterDistance = 398;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnDeleteAidStation);
            this.splitContainer2.Panel1.Controls.Add(this.btnEditAidStation);
            this.splitContainer2.Panel1.Controls.Add(this.btnAddAidStation);
            this.splitContainer2.Panel1.Controls.Add(this.dgvAidStations);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1251, 398);
            this.splitContainer2.SplitterDistance = 416;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnDeleteAidStation
            // 
            this.btnDeleteAidStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAidStation.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteAidStation.Location = new System.Drawing.Point(235, 353);
            this.btnDeleteAidStation.Name = "btnDeleteAidStation";
            this.btnDeleteAidStation.Size = new System.Drawing.Size(113, 42);
            this.btnDeleteAidStation.TabIndex = 49;
            this.btnDeleteAidStation.Text = "Delete";
            this.btnDeleteAidStation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteAidStation.UseVisualStyleBackColor = true;
            this.btnDeleteAidStation.Click += new System.EventHandler(this.btnDeleteAidStation_Click);
            // 
            // btnEditAidStation
            // 
            this.btnEditAidStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditAidStation.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditAidStation.Location = new System.Drawing.Point(116, 353);
            this.btnEditAidStation.Name = "btnEditAidStation";
            this.btnEditAidStation.Size = new System.Drawing.Size(113, 42);
            this.btnEditAidStation.TabIndex = 48;
            this.btnEditAidStation.Text = "Edit";
            this.btnEditAidStation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditAidStation.UseVisualStyleBackColor = true;
            this.btnEditAidStation.Click += new System.EventHandler(this.btnEditAidStation_Click);
            // 
            // btnAddAidStation
            // 
            this.btnAddAidStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddAidStation.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddAidStation.Location = new System.Drawing.Point(8, 353);
            this.btnAddAidStation.Name = "btnAddAidStation";
            this.btnAddAidStation.Size = new System.Drawing.Size(102, 42);
            this.btnAddAidStation.TabIndex = 47;
            this.btnAddAidStation.Text = "Add";
            this.btnAddAidStation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddAidStation.UseVisualStyleBackColor = true;
            this.btnAddAidStation.Click += new System.EventHandler(this.btnAddAidStation_Click);
            // 
            // dgvAidStations
            // 
            this.dgvAidStations.AllowUserToAddRows = false;
            this.dgvAidStations.AllowUserToDeleteRows = false;
            this.dgvAidStations.AllowUserToResizeColumns = false;
            this.dgvAidStations.AllowUserToResizeRows = false;
            this.dgvAidStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAidStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAidStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAidName,
            this.colAidLocation,
            this.colAidParamedics});
            this.dgvAidStations.Location = new System.Drawing.Point(8, 41);
            this.dgvAidStations.Name = "dgvAidStations";
            this.dgvAidStations.ReadOnly = true;
            this.dgvAidStations.RowHeadersVisible = false;
            this.dgvAidStations.RowTemplate.Height = 30;
            this.dgvAidStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAidStations.Size = new System.Drawing.Size(405, 306);
            this.dgvAidStations.TabIndex = 1;
            this.dgvAidStations.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAidStations_CellDoubleClick);
            this.dgvAidStations.SelectionChanged += new System.EventHandler(this.dgvAidStations_SelectionChanged);
            // 
            // colAidName
            // 
            this.colAidName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAidName.DataPropertyName = "Name";
            this.colAidName.HeaderText = "Name";
            this.colAidName.MinimumWidth = 150;
            this.colAidName.Name = "colAidName";
            this.colAidName.ReadOnly = true;
            // 
            // colAidLocation
            // 
            this.colAidLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAidLocation.DataPropertyName = "Location";
            this.colAidLocation.HeaderText = "Location";
            this.colAidLocation.Name = "colAidLocation";
            this.colAidLocation.ReadOnly = true;
            this.colAidLocation.Width = 106;
            // 
            // colAidParamedics
            // 
            this.colAidParamedics.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAidParamedics.DataPropertyName = "ParamedicsAvailable";
            this.colAidParamedics.HeaderText = "EHS";
            this.colAidParamedics.Name = "colAidParamedics";
            this.colAidParamedics.ReadOnly = true;
            this.colAidParamedics.Width = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Medical Aid Stations";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.btnDeleteTransport);
            this.splitContainer3.Panel1.Controls.Add(this.btnEditTransport);
            this.splitContainer3.Panel1.Controls.Add(this.btnAddTransport);
            this.splitContainer3.Panel1.Controls.Add(this.dgvTransport);
            this.splitContainer3.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnDeleteHospital);
            this.splitContainer3.Panel2.Controls.Add(this.label6);
            this.splitContainer3.Panel2.Controls.Add(this.btnEditHospital);
            this.splitContainer3.Panel2.Controls.Add(this.dgvHospitals);
            this.splitContainer3.Panel2.Controls.Add(this.btnAddHospital);
            this.splitContainer3.Size = new System.Drawing.Size(831, 398);
            this.splitContainer3.SplitterDistance = 415;
            this.splitContainer3.TabIndex = 0;
            // 
            // btnDeleteTransport
            // 
            this.btnDeleteTransport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteTransport.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteTransport.Location = new System.Drawing.Point(235, 353);
            this.btnDeleteTransport.Name = "btnDeleteTransport";
            this.btnDeleteTransport.Size = new System.Drawing.Size(113, 42);
            this.btnDeleteTransport.TabIndex = 53;
            this.btnDeleteTransport.Text = "Delete";
            this.btnDeleteTransport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteTransport.UseVisualStyleBackColor = true;
            this.btnDeleteTransport.Click += new System.EventHandler(this.btnDeleteTransport_Click);
            // 
            // btnEditTransport
            // 
            this.btnEditTransport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditTransport.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditTransport.Location = new System.Drawing.Point(116, 353);
            this.btnEditTransport.Name = "btnEditTransport";
            this.btnEditTransport.Size = new System.Drawing.Size(113, 42);
            this.btnEditTransport.TabIndex = 52;
            this.btnEditTransport.Text = "Edit";
            this.btnEditTransport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditTransport.UseVisualStyleBackColor = true;
            this.btnEditTransport.Click += new System.EventHandler(this.btnEditTransport_Click);
            // 
            // btnAddTransport
            // 
            this.btnAddTransport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddTransport.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddTransport.Location = new System.Drawing.Point(8, 353);
            this.btnAddTransport.Name = "btnAddTransport";
            this.btnAddTransport.Size = new System.Drawing.Size(102, 42);
            this.btnAddTransport.TabIndex = 51;
            this.btnAddTransport.Text = "Add";
            this.btnAddTransport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTransport.UseVisualStyleBackColor = true;
            this.btnAddTransport.Click += new System.EventHandler(this.btnAddTransport_Click);
            // 
            // dgvTransport
            // 
            this.dgvTransport.AllowUserToAddRows = false;
            this.dgvTransport.AllowUserToDeleteRows = false;
            this.dgvTransport.AllowUserToResizeColumns = false;
            this.dgvTransport.AllowUserToResizeRows = false;
            this.dgvTransport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAmbulanceName,
            this.colAmbulanceLocation});
            this.dgvTransport.Location = new System.Drawing.Point(8, 41);
            this.dgvTransport.Name = "dgvTransport";
            this.dgvTransport.ReadOnly = true;
            this.dgvTransport.RowHeadersVisible = false;
            this.dgvTransport.RowTemplate.Height = 30;
            this.dgvTransport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransport.Size = new System.Drawing.Size(404, 306);
            this.dgvTransport.TabIndex = 50;
            this.dgvTransport.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransport_CellDoubleClick);
            this.dgvTransport.SelectionChanged += new System.EventHandler(this.dgvTransport_SelectionChanged);
            // 
            // colAmbulanceName
            // 
            this.colAmbulanceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAmbulanceName.DataPropertyName = "Organization";
            this.colAmbulanceName.HeaderText = "Medivac Service";
            this.colAmbulanceName.MinimumWidth = 150;
            this.colAmbulanceName.Name = "colAmbulanceName";
            this.colAmbulanceName.ReadOnly = true;
            // 
            // colAmbulanceLocation
            // 
            this.colAmbulanceLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colAmbulanceLocation.DataPropertyName = "Location";
            this.colAmbulanceLocation.HeaderText = "Location";
            this.colAmbulanceLocation.Name = "colAmbulanceLocation";
            this.colAmbulanceLocation.ReadOnly = true;
            this.colAmbulanceLocation.Width = 106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 29);
            this.label5.TabIndex = 1;
            this.label5.Text = "Transportation";
            // 
            // btnDeleteHospital
            // 
            this.btnDeleteHospital.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteHospital.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteHospital.Location = new System.Drawing.Point(235, 353);
            this.btnDeleteHospital.Name = "btnDeleteHospital";
            this.btnDeleteHospital.Size = new System.Drawing.Size(113, 42);
            this.btnDeleteHospital.TabIndex = 57;
            this.btnDeleteHospital.Text = "Delete";
            this.btnDeleteHospital.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteHospital.UseVisualStyleBackColor = true;
            this.btnDeleteHospital.Click += new System.EventHandler(this.btnDeleteHospital_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 29);
            this.label6.TabIndex = 2;
            this.label6.Text = "Hospitals";
            // 
            // btnEditHospital
            // 
            this.btnEditHospital.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditHospital.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditHospital.Location = new System.Drawing.Point(116, 353);
            this.btnEditHospital.Name = "btnEditHospital";
            this.btnEditHospital.Size = new System.Drawing.Size(113, 42);
            this.btnEditHospital.TabIndex = 56;
            this.btnEditHospital.Text = "Edit";
            this.btnEditHospital.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditHospital.UseVisualStyleBackColor = true;
            this.btnEditHospital.Click += new System.EventHandler(this.btnEditHospital_Click);
            // 
            // dgvHospitals
            // 
            this.dgvHospitals.AllowUserToAddRows = false;
            this.dgvHospitals.AllowUserToDeleteRows = false;
            this.dgvHospitals.AllowUserToResizeColumns = false;
            this.dgvHospitals.AllowUserToResizeRows = false;
            this.dgvHospitals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHospitals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospitals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHospitalName,
            this.colHospitalLocation,
            this.colHospitalTravelAir,
            this.colHospitalTravelGround});
            this.dgvHospitals.Location = new System.Drawing.Point(8, 41);
            this.dgvHospitals.Name = "dgvHospitals";
            this.dgvHospitals.ReadOnly = true;
            this.dgvHospitals.RowHeadersVisible = false;
            this.dgvHospitals.RowTemplate.Height = 30;
            this.dgvHospitals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHospitals.Size = new System.Drawing.Size(401, 306);
            this.dgvHospitals.TabIndex = 54;
            this.dgvHospitals.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHospitals_CellDoubleClick);
            // 
            // colHospitalName
            // 
            this.colHospitalName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colHospitalName.DataPropertyName = "name";
            this.colHospitalName.HeaderText = "Hospital";
            this.colHospitalName.MinimumWidth = 150;
            this.colHospitalName.Name = "colHospitalName";
            this.colHospitalName.ReadOnly = true;
            // 
            // colHospitalLocation
            // 
            this.colHospitalLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHospitalLocation.DataPropertyName = "location";
            this.colHospitalLocation.HeaderText = "Location";
            this.colHospitalLocation.Name = "colHospitalLocation";
            this.colHospitalLocation.ReadOnly = true;
            this.colHospitalLocation.Width = 106;
            // 
            // colHospitalTravelAir
            // 
            this.colHospitalTravelAir.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHospitalTravelAir.DataPropertyName = "travelTimeAir";
            this.colHospitalTravelAir.HeaderText = "Air";
            this.colHospitalTravelAir.Name = "colHospitalTravelAir";
            this.colHospitalTravelAir.ReadOnly = true;
            this.colHospitalTravelAir.Width = 58;
            // 
            // colHospitalTravelGround
            // 
            this.colHospitalTravelGround.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colHospitalTravelGround.DataPropertyName = "travelTimeGround";
            this.colHospitalTravelGround.HeaderText = "Grnd.";
            this.colHospitalTravelGround.Name = "colHospitalTravelGround";
            this.colHospitalTravelGround.ReadOnly = true;
            this.colHospitalTravelGround.Width = 82;
            // 
            // btnAddHospital
            // 
            this.btnAddHospital.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddHospital.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddHospital.Location = new System.Drawing.Point(8, 353);
            this.btnAddHospital.Name = "btnAddHospital";
            this.btnAddHospital.Size = new System.Drawing.Size(102, 42);
            this.btnAddHospital.TabIndex = 55;
            this.btnAddHospital.Text = "Add";
            this.btnAddHospital.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddHospital.UseVisualStyleBackColor = true;
            this.btnAddHospital.Click += new System.EventHandler(this.btnAddHospital_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 29);
            this.label3.TabIndex = 58;
            this.label3.Text = "Medical Emergency Procedures";
            // 
            // txtEmergencyProcedures
            // 
            this.txtEmergencyProcedures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmergencyProcedures.Location = new System.Drawing.Point(8, 36);
            this.txtEmergencyProcedures.Multiline = true;
            this.txtEmergencyProcedures.Name = "txtEmergencyProcedures";
            this.txtEmergencyProcedures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEmergencyProcedures.Size = new System.Drawing.Size(1234, 99);
            this.txtEmergencyProcedures.TabIndex = 57;
            this.txtEmergencyProcedures.TextChanged += new System.EventHandler(this.txtEmergencyProcedures_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(579, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 32);
            this.label2.TabIndex = 56;
            this.label2.Text = "Approved By";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(3, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 32);
            this.label1.TabIndex = 55;
            this.label1.Text = "Prepared By";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboPreparedBy
            // 
            this.cboPreparedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboPreparedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPreparedBy.FormattingEnabled = true;
            this.cboPreparedBy.Location = new System.Drawing.Point(129, 146);
            this.cboPreparedBy.Name = "cboPreparedBy";
            this.cboPreparedBy.Size = new System.Drawing.Size(416, 32);
            this.cboPreparedBy.TabIndex = 54;
            this.cboPreparedBy.Leave += new System.EventHandler(this.cboPreparedBy_Leave);
            // 
            // cboApprovedBy
            // 
            this.cboApprovedBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboApprovedBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApprovedBy.FormattingEnabled = true;
            this.cboApprovedBy.Location = new System.Drawing.Point(707, 146);
            this.cboApprovedBy.Name = "cboApprovedBy";
            this.cboApprovedBy.Size = new System.Drawing.Size(416, 32);
            this.cboApprovedBy.TabIndex = 53;
            this.cboApprovedBy.Leave += new System.EventHandler(this.cboApprovedBy_Leave);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.Location = new System.Drawing.Point(1129, 141);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 42);
            this.btnPrint.TabIndex = 52;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // MedicalPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1251, 590);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(1101, 491);
            this.Name = "MedicalPlanForm";
            this.Text = "Medical Plan";
            this.Load += new System.EventHandler(this.MedicalPlanForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAidStations)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmergencyProcedures;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboPreparedBy;
        private System.Windows.Forms.ComboBox cboApprovedBy;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvAidStations;
        private System.Windows.Forms.Button btnDeleteAidStation;
        private System.Windows.Forms.Button btnEditAidStation;
        private System.Windows.Forms.Button btnAddAidStation;
        private System.Windows.Forms.Button btnDeleteTransport;
        private System.Windows.Forms.Button btnEditTransport;
        private System.Windows.Forms.Button btnAddTransport;
        private System.Windows.Forms.DataGridView dgvTransport;
        private System.Windows.Forms.Button btnDeleteHospital;
        private System.Windows.Forms.Button btnEditHospital;
        private System.Windows.Forms.DataGridView dgvHospitals;
        private System.Windows.Forms.Button btnAddHospital;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAidName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAidLocation;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAidParamedics;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmbulanceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmbulanceLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHospitalName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHospitalLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHospitalTravelAir;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHospitalTravelGround;
    }
}