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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpAidStations = new System.Windows.Forms.TabPage();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.dgvAidStations = new System.Windows.Forms.DataGridView();
            this.colAidName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAidLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAidParamedics = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.llBox4 = new System.Windows.Forms.LinkLabel();
            this.btnAddAidStation = new System.Windows.Forms.Button();
            this.btnDeleteAidStation = new System.Windows.Forms.Button();
            this.btnEditAidStation = new System.Windows.Forms.Button();
            this.tpTransport = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.dgvTransport = new System.Windows.Forms.DataGridView();
            this.colAmbulanceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmbulanceLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFieldHelp5 = new System.Windows.Forms.Button();
            this.btnAddTransport = new System.Windows.Forms.Button();
            this.btnDeleteTransport = new System.Windows.Forms.Button();
            this.btnEditTransport = new System.Windows.Forms.Button();
            this.toHospitals = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvHospitals = new System.Windows.Forms.DataGridView();
            this.colHospitalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHospitalLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHospitalTravelAir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHospitalTravelGround = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFieldHelp6 = new System.Windows.Forms.Button();
            this.btnAddHospital = new System.Windows.Forms.Button();
            this.btnDeleteHospital = new System.Windows.Forms.Button();
            this.btnEditHospital = new System.Windows.Forms.Button();
            this.toProcedures = new System.Windows.Forms.TabPage();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.txtEmergencyProcedures = new SpellBox();
            this.btnFieldHelp7 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.prepAndApprovePanel1 = new Wildfire_ICS_Assist.CustomControls.PrepAndApprovePanel();
            this.btnFormVideo = new System.Windows.Forms.Button();
            this.btnFormHelp = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpAidStations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAidStations)).BeginInit();
            this.tpTransport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransport)).BeginInit();
            this.toHospitals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitals)).BeginInit();
            this.toProcedures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnFormVideo);
            this.splitContainer1.Panel2.Controls.Add(this.btnFormHelp);
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(890, 499);
            this.splitContainer1.SplitterDistance = 443;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpAidStations);
            this.tabControl1.Controls.Add(this.tpTransport);
            this.tabControl1.Controls.Add(this.toHospitals);
            this.tabControl1.Controls.Add(this.toProcedures);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(890, 443);
            this.tabControl1.TabIndex = 58;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tpAidStations
            // 
            this.tpAidStations.Controls.Add(this.splitContainer6);
            this.tpAidStations.Location = new System.Drawing.Point(4, 33);
            this.tpAidStations.Name = "tpAidStations";
            this.tpAidStations.Padding = new System.Windows.Forms.Padding(3);
            this.tpAidStations.Size = new System.Drawing.Size(882, 406);
            this.tpAidStations.TabIndex = 0;
            this.tpAidStations.Text = "Medical Aid Stations";
            this.tpAidStations.UseVisualStyleBackColor = true;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer6.IsSplitterFixed = true;
            this.splitContainer6.Location = new System.Drawing.Point(3, 3);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.dgvAidStations);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.llBox4);
            this.splitContainer6.Panel2.Controls.Add(this.btnAddAidStation);
            this.splitContainer6.Panel2.Controls.Add(this.btnDeleteAidStation);
            this.splitContainer6.Panel2.Controls.Add(this.btnEditAidStation);
            this.splitContainer6.Size = new System.Drawing.Size(876, 400);
            this.splitContainer6.SplitterDistance = 348;
            this.splitContainer6.TabIndex = 0;
            // 
            // dgvAidStations
            // 
            this.dgvAidStations.AllowUserToAddRows = false;
            this.dgvAidStations.AllowUserToDeleteRows = false;
            this.dgvAidStations.AllowUserToResizeColumns = false;
            this.dgvAidStations.AllowUserToResizeRows = false;
            this.dgvAidStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAidStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAidName,
            this.colAidLocation,
            this.colAidParamedics});
            this.dgvAidStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAidStations.Location = new System.Drawing.Point(0, 0);
            this.dgvAidStations.Name = "dgvAidStations";
            this.dgvAidStations.ReadOnly = true;
            this.dgvAidStations.RowHeadersVisible = false;
            this.dgvAidStations.RowTemplate.Height = 30;
            this.dgvAidStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAidStations.Size = new System.Drawing.Size(876, 348);
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
            // llBox4
            // 
            this.llBox4.AutoSize = true;
            this.llBox4.Location = new System.Drawing.Point(767, 12);
            this.llBox4.Name = "llBox4";
            this.llBox4.Size = new System.Drawing.Size(104, 24);
            this.llBox4.TabIndex = 50;
            this.llBox4.TabStop = true;
            this.llBox4.Text = "Instructions";
            // 
            // btnAddAidStation
            // 
            this.btnAddAidStation.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddAidStation.Location = new System.Drawing.Point(3, 3);
            this.btnAddAidStation.Name = "btnAddAidStation";
            this.btnAddAidStation.Size = new System.Drawing.Size(102, 42);
            this.btnAddAidStation.TabIndex = 47;
            this.btnAddAidStation.Text = "Add";
            this.btnAddAidStation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddAidStation.UseVisualStyleBackColor = true;
            this.btnAddAidStation.Click += new System.EventHandler(this.btnAddAidStation_Click);
            // 
            // btnDeleteAidStation
            // 
            this.btnDeleteAidStation.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteAidStation.Location = new System.Drawing.Point(230, 3);
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
            this.btnEditAidStation.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditAidStation.Location = new System.Drawing.Point(111, 3);
            this.btnEditAidStation.Name = "btnEditAidStation";
            this.btnEditAidStation.Size = new System.Drawing.Size(113, 42);
            this.btnEditAidStation.TabIndex = 48;
            this.btnEditAidStation.Text = "Edit";
            this.btnEditAidStation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditAidStation.UseVisualStyleBackColor = true;
            this.btnEditAidStation.Click += new System.EventHandler(this.btnEditAidStation_Click);
            // 
            // tpTransport
            // 
            this.tpTransport.Controls.Add(this.splitContainer3);
            this.tpTransport.Location = new System.Drawing.Point(4, 33);
            this.tpTransport.Name = "tpTransport";
            this.tpTransport.Padding = new System.Windows.Forms.Padding(3);
            this.tpTransport.Size = new System.Drawing.Size(882, 406);
            this.tpTransport.TabIndex = 1;
            this.tpTransport.Text = "Transporation";
            this.tpTransport.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.dgvTransport);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnFieldHelp5);
            this.splitContainer3.Panel2.Controls.Add(this.btnAddTransport);
            this.splitContainer3.Panel2.Controls.Add(this.btnDeleteTransport);
            this.splitContainer3.Panel2.Controls.Add(this.btnEditTransport);
            this.splitContainer3.Size = new System.Drawing.Size(876, 400);
            this.splitContainer3.SplitterDistance = 343;
            this.splitContainer3.TabIndex = 0;
            // 
            // dgvTransport
            // 
            this.dgvTransport.AllowUserToAddRows = false;
            this.dgvTransport.AllowUserToDeleteRows = false;
            this.dgvTransport.AllowUserToResizeColumns = false;
            this.dgvTransport.AllowUserToResizeRows = false;
            this.dgvTransport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAmbulanceName,
            this.colAmbulanceLocation});
            this.dgvTransport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransport.Location = new System.Drawing.Point(0, 0);
            this.dgvTransport.Name = "dgvTransport";
            this.dgvTransport.ReadOnly = true;
            this.dgvTransport.RowHeadersVisible = false;
            this.dgvTransport.RowTemplate.Height = 30;
            this.dgvTransport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransport.Size = new System.Drawing.Size(876, 343);
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
            // btnFieldHelp5
            // 
            this.btnFieldHelp5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFieldHelp5.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_196_circle_empty_info;
            this.btnFieldHelp5.Location = new System.Drawing.Point(727, 6);
            this.btnFieldHelp5.Name = "btnFieldHelp5";
            this.btnFieldHelp5.Size = new System.Drawing.Size(144, 37);
            this.btnFieldHelp5.TabIndex = 55;
            this.btnFieldHelp5.Text = "Field Help";
            this.btnFieldHelp5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFieldHelp5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFieldHelp5.UseVisualStyleBackColor = true;
            // 
            // btnAddTransport
            // 
            this.btnAddTransport.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddTransport.Location = new System.Drawing.Point(3, 3);
            this.btnAddTransport.Name = "btnAddTransport";
            this.btnAddTransport.Size = new System.Drawing.Size(102, 42);
            this.btnAddTransport.TabIndex = 51;
            this.btnAddTransport.Text = "Add";
            this.btnAddTransport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTransport.UseVisualStyleBackColor = true;
            this.btnAddTransport.Click += new System.EventHandler(this.btnAddTransport_Click);
            // 
            // btnDeleteTransport
            // 
            this.btnDeleteTransport.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteTransport.Location = new System.Drawing.Point(230, 3);
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
            this.btnEditTransport.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditTransport.Location = new System.Drawing.Point(111, 3);
            this.btnEditTransport.Name = "btnEditTransport";
            this.btnEditTransport.Size = new System.Drawing.Size(113, 42);
            this.btnEditTransport.TabIndex = 52;
            this.btnEditTransport.Text = "Edit";
            this.btnEditTransport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditTransport.UseVisualStyleBackColor = true;
            this.btnEditTransport.Click += new System.EventHandler(this.btnEditTransport_Click);
            // 
            // toHospitals
            // 
            this.toHospitals.Controls.Add(this.splitContainer2);
            this.toHospitals.Location = new System.Drawing.Point(4, 33);
            this.toHospitals.Name = "toHospitals";
            this.toHospitals.Size = new System.Drawing.Size(882, 406);
            this.toHospitals.TabIndex = 2;
            this.toHospitals.Text = "Hospitals";
            this.toHospitals.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvHospitals);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnFieldHelp6);
            this.splitContainer2.Panel2.Controls.Add(this.btnAddHospital);
            this.splitContainer2.Panel2.Controls.Add(this.btnDeleteHospital);
            this.splitContainer2.Panel2.Controls.Add(this.btnEditHospital);
            this.splitContainer2.Size = new System.Drawing.Size(882, 406);
            this.splitContainer2.SplitterDistance = 353;
            this.splitContainer2.TabIndex = 58;
            // 
            // dgvHospitals
            // 
            this.dgvHospitals.AllowUserToAddRows = false;
            this.dgvHospitals.AllowUserToDeleteRows = false;
            this.dgvHospitals.AllowUserToResizeColumns = false;
            this.dgvHospitals.AllowUserToResizeRows = false;
            this.dgvHospitals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHospitals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHospitalName,
            this.colHospitalLocation,
            this.colHospitalTravelAir,
            this.colHospitalTravelGround});
            this.dgvHospitals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHospitals.Location = new System.Drawing.Point(0, 0);
            this.dgvHospitals.Name = "dgvHospitals";
            this.dgvHospitals.ReadOnly = true;
            this.dgvHospitals.RowHeadersVisible = false;
            this.dgvHospitals.RowTemplate.Height = 30;
            this.dgvHospitals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHospitals.Size = new System.Drawing.Size(882, 353);
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
            // btnFieldHelp6
            // 
            this.btnFieldHelp6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFieldHelp6.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_196_circle_empty_info;
            this.btnFieldHelp6.Location = new System.Drawing.Point(735, 6);
            this.btnFieldHelp6.Name = "btnFieldHelp6";
            this.btnFieldHelp6.Size = new System.Drawing.Size(144, 37);
            this.btnFieldHelp6.TabIndex = 58;
            this.btnFieldHelp6.Text = "Field Help";
            this.btnFieldHelp6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFieldHelp6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFieldHelp6.UseVisualStyleBackColor = true;
            // 
            // btnAddHospital
            // 
            this.btnAddHospital.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnAddHospital.Location = new System.Drawing.Point(3, 3);
            this.btnAddHospital.Name = "btnAddHospital";
            this.btnAddHospital.Size = new System.Drawing.Size(102, 42);
            this.btnAddHospital.TabIndex = 55;
            this.btnAddHospital.Text = "Add";
            this.btnAddHospital.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddHospital.UseVisualStyleBackColor = true;
            this.btnAddHospital.Click += new System.EventHandler(this.btnAddHospital_Click);
            // 
            // btnDeleteHospital
            // 
            this.btnDeleteHospital.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteHospital.Location = new System.Drawing.Point(230, 3);
            this.btnDeleteHospital.Name = "btnDeleteHospital";
            this.btnDeleteHospital.Size = new System.Drawing.Size(113, 42);
            this.btnDeleteHospital.TabIndex = 57;
            this.btnDeleteHospital.Text = "Delete";
            this.btnDeleteHospital.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDeleteHospital.UseVisualStyleBackColor = true;
            this.btnDeleteHospital.Click += new System.EventHandler(this.btnDeleteHospital_Click);
            // 
            // btnEditHospital
            // 
            this.btnEditHospital.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEditHospital.Location = new System.Drawing.Point(111, 3);
            this.btnEditHospital.Name = "btnEditHospital";
            this.btnEditHospital.Size = new System.Drawing.Size(113, 42);
            this.btnEditHospital.TabIndex = 56;
            this.btnEditHospital.Text = "Edit";
            this.btnEditHospital.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditHospital.UseVisualStyleBackColor = true;
            this.btnEditHospital.Click += new System.EventHandler(this.btnEditHospital_Click);
            // 
            // toProcedures
            // 
            this.toProcedures.Controls.Add(this.splitContainer4);
            this.toProcedures.Location = new System.Drawing.Point(4, 33);
            this.toProcedures.Name = "toProcedures";
            this.toProcedures.Size = new System.Drawing.Size(882, 406);
            this.toProcedures.TabIndex = 3;
            this.toProcedures.Text = "Procedures and Approval";
            this.toProcedures.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.txtEmergencyProcedures);
            this.splitContainer4.Panel1.Controls.Add(this.btnFieldHelp7);
            this.splitContainer4.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.prepAndApprovePanel1);
            this.splitContainer4.Size = new System.Drawing.Size(882, 406);
            this.splitContainer4.SplitterDistance = 200;
            this.splitContainer4.TabIndex = 61;
            // 
            // txtEmergencyProcedures
            // 
            this.txtEmergencyProcedures.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmergencyProcedures.Location = new System.Drawing.Point(8, 46);
            this.txtEmergencyProcedures.Multiline = true;
            this.txtEmergencyProcedures.Name = "txtEmergencyProcedures";
            this.txtEmergencyProcedures.Size = new System.Drawing.Size(866, 149);
            this.txtEmergencyProcedures.TabIndex = 59;
            this.txtEmergencyProcedures.WordWrap = true;
            this.txtEmergencyProcedures.TextChanged += new System.EventHandler(this.txtEmergencyProcedures_TextChanged_1);
            this.txtEmergencyProcedures.Leave += new System.EventHandler(this.txtEmergencyProcedures_Leave_1);
            this.txtEmergencyProcedures.Child = new System.Windows.Controls.TextBox();
            // 
            // btnFieldHelp7
            // 
            this.btnFieldHelp7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFieldHelp7.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_196_circle_empty_info;
            this.btnFieldHelp7.Location = new System.Drawing.Point(730, 3);
            this.btnFieldHelp7.Name = "btnFieldHelp7";
            this.btnFieldHelp7.Size = new System.Drawing.Size(144, 37);
            this.btnFieldHelp7.TabIndex = 60;
            this.btnFieldHelp7.Text = "Field Help";
            this.btnFieldHelp7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFieldHelp7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFieldHelp7.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 29);
            this.label3.TabIndex = 58;
            this.label3.Text = "Medical Emergency Procedures";
            // 
            // prepAndApprovePanel1
            // 
            this.prepAndApprovePanel1.ApprovedByDateTime = new System.DateTime(((long)(0)));
            this.prepAndApprovePanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prepAndApprovePanel1.Collapsed = false;
            this.prepAndApprovePanel1.CollapsedBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.prepAndApprovePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prepAndApprovePanel1.EnableExpandCollapse = false;
            this.prepAndApprovePanel1.ExpandsRight = true;
            this.prepAndApprovePanel1.ExpandsUpward = false;
            this.prepAndApprovePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepAndApprovePanel1.Location = new System.Drawing.Point(0, 0);
            this.prepAndApprovePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.prepAndApprovePanel1.Name = "prepAndApprovePanel1";
            this.prepAndApprovePanel1.PreparedByDateTime = new System.DateTime(2024, 10, 31, 10, 27, 52, 800);
            this.prepAndApprovePanel1.Size = new System.Drawing.Size(882, 202);
            this.prepAndApprovePanel1.SizeWhenCollapsed = new System.Drawing.Size(485, 40);
            this.prepAndApprovePanel1.SizeWhenExpanded = new System.Drawing.Size(619, 197);
            this.prepAndApprovePanel1.TabIndex = 60;
            this.prepAndApprovePanel1.TitleText = "Prepared and Approved Info";
            this.prepAndApprovePanel1.PreparedByChanged += new System.EventHandler(this.prepAndApprovePanel1_PreparedByChanged);
            this.prepAndApprovePanel1.ApprovedByChanged += new System.EventHandler(this.prepAndApprovePanel1_ApprovedByChanged);
            // 
            // btnFormVideo
            // 
            this.btnFormVideo.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_filetypes_52_folder_video;
            this.btnFormVideo.Location = new System.Drawing.Point(162, 3);
            this.btnFormVideo.Name = "btnFormVideo";
            this.btnFormVideo.Size = new System.Drawing.Size(163, 42);
            this.btnFormVideo.TabIndex = 54;
            this.btnFormVideo.Text = "Form Video";
            this.btnFormVideo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFormVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFormVideo.UseVisualStyleBackColor = true;
            this.btnFormVideo.Click += new System.EventHandler(this.btnFormVideo_Click);
            // 
            // btnFormHelp
            // 
            this.btnFormHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFormHelp.FlatAppearance.BorderSize = 2;
            this.btnFormHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFormHelp.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_196_circle_empty_info;
            this.btnFormHelp.Location = new System.Drawing.Point(12, 3);
            this.btnFormHelp.Name = "btnFormHelp";
            this.btnFormHelp.Size = new System.Drawing.Size(144, 42);
            this.btnFormHelp.TabIndex = 53;
            this.btnFormHelp.Tag = "Help";
            this.btnFormHelp.Text = "Form Help";
            this.btnFormHelp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFormHelp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFormHelp.UseVisualStyleBackColor = true;
            this.btnFormHelp.Click += new System.EventHandler(this.btnFormHelp_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_filetypes_2_file_rich_text;
            this.btnPrint.Location = new System.Drawing.Point(734, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(144, 42);
            this.btnPrint.TabIndex = 52;
            this.btnPrint.Tag = "ViewPDF";
            this.btnPrint.Text = "View PDF";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 5000;
            this.toolTip1.AutoPopDelay = 50000;
            this.toolTip1.BackColor = System.Drawing.Color.Black;
            this.toolTip1.ForeColor = System.Drawing.Color.White;
            this.toolTip1.InitialDelay = 1;
            this.toolTip1.ReshowDelay = 1000;
            this.toolTip1.ToolTipTitle = "Form Instructions";
            // 
            // MedicalPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(890, 499);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(784, 453);
            this.Name = "MedicalPlanForm";
            this.Text = "Medical Plan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MedicalPlanForm_FormClosing);
            this.Load += new System.EventHandler(this.MedicalPlanForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpAidStations.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAidStations)).EndInit();
            this.tpTransport.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransport)).EndInit();
            this.toHospitals.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHospitals)).EndInit();
            this.toProcedures.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrint;
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
        private SpellBox txtEmergencyProcedures;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpAidStations;
        private System.Windows.Forms.TabPage tpTransport;
        private System.Windows.Forms.TabPage toHospitals;
        private System.Windows.Forms.TabPage toProcedures;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CustomControls.PrepAndApprovePanel prepAndApprovePanel1;
        private System.Windows.Forms.Button btnFormHelp;
        private System.Windows.Forms.Button btnFormVideo;
        private System.Windows.Forms.Button btnFieldHelp5;
        private System.Windows.Forms.Button btnFieldHelp6;
        private System.Windows.Forms.Button btnFieldHelp7;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.LinkLabel llBox4;
    }
}