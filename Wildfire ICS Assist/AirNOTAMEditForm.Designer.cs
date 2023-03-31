namespace Wildfire_ICS_Assist
{
    partial class AirNOTAMEditForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlPolygon = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.txtPolygonSE = new System.Windows.Forms.TextBox();
            this.lblSECoordinateOK = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPolygonSW = new System.Windows.Forms.TextBox();
            this.lblSWCoordinateOK = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPolygonNE = new System.Windows.Forms.TextBox();
            this.lblNECoordinateOK = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPolygonNW = new System.Windows.Forms.TextBox();
            this.lblNWCoordinateOK = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rbPoygon = new System.Windows.Forms.RadioButton();
            this.pnlRadius = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rbRadius = new System.Windows.Forms.RadioButton();
            this.numRadius = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRadiusCoordinates = new System.Windows.Forms.TextBox();
            this.lblCoordinateStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numAltitude = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCenterPoint = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlPolygon.SuspendLayout();
            this.pnlRadius.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_223_chevron_left;
            this.btnCancel.Location = new System.Drawing.Point(8, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 51);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_199_save;
            this.btnSave.Location = new System.Drawing.Point(466, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 51);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.pnlPolygon);
            this.splitContainer1.Panel1.Controls.Add(this.pnlRadius);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.numAltitude);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.txtCenterPoint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(603, 604);
            this.splitContainer1.SplitterDistance = 537;
            this.splitContainer1.TabIndex = 4;
            // 
            // pnlPolygon
            // 
            this.pnlPolygon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPolygon.Controls.Add(this.label17);
            this.pnlPolygon.Controls.Add(this.txtPolygonSE);
            this.pnlPolygon.Controls.Add(this.lblSECoordinateOK);
            this.pnlPolygon.Controls.Add(this.label19);
            this.pnlPolygon.Controls.Add(this.label20);
            this.pnlPolygon.Controls.Add(this.txtPolygonSW);
            this.pnlPolygon.Controls.Add(this.lblSWCoordinateOK);
            this.pnlPolygon.Controls.Add(this.label22);
            this.pnlPolygon.Controls.Add(this.label14);
            this.pnlPolygon.Controls.Add(this.txtPolygonNE);
            this.pnlPolygon.Controls.Add(this.lblNECoordinateOK);
            this.pnlPolygon.Controls.Add(this.label16);
            this.pnlPolygon.Controls.Add(this.label10);
            this.pnlPolygon.Controls.Add(this.txtPolygonNW);
            this.pnlPolygon.Controls.Add(this.lblNWCoordinateOK);
            this.pnlPolygon.Controls.Add(this.label13);
            this.pnlPolygon.Controls.Add(this.label9);
            this.pnlPolygon.Controls.Add(this.rbPoygon);
            this.pnlPolygon.Location = new System.Drawing.Point(13, 51);
            this.pnlPolygon.Name = "pnlPolygon";
            this.pnlPolygon.Size = new System.Drawing.Size(579, 252);
            this.pnlPolygon.TabIndex = 1;
            this.pnlPolygon.Enter += new System.EventHandler(this.pnlPolygon_Enter);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 217);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(124, 15);
            this.label17.TabIndex = 155;
            this.label17.Text = "Lat/Lng, UTM, MGRS";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPolygonSE
            // 
            this.txtPolygonSE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPolygonSE.Location = new System.Drawing.Point(136, 187);
            this.txtPolygonSE.Name = "txtPolygonSE";
            this.txtPolygonSE.Size = new System.Drawing.Size(434, 29);
            this.txtPolygonSE.TabIndex = 5;
            this.txtPolygonSE.Leave += new System.EventHandler(this.txtPolygonSE_Leave);
            // 
            // lblSECoordinateOK
            // 
            this.lblSECoordinateOK.AutoSize = true;
            this.lblSECoordinateOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSECoordinateOK.Location = new System.Drawing.Point(136, 219);
            this.lblSECoordinateOK.Name = "lblSECoordinateOK";
            this.lblSECoordinateOK.Size = new System.Drawing.Size(101, 15);
            this.lblSECoordinateOK.TabIndex = 154;
            this.lblSECoordinateOK.Text = "Coordinates okay";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(4, 188);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(126, 29);
            this.label19.TabIndex = 153;
            this.label19.Text = "South East";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 167);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(124, 15);
            this.label20.TabIndex = 151;
            this.label20.Text = "Lat/Lng, UTM, MGRS";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPolygonSW
            // 
            this.txtPolygonSW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPolygonSW.Location = new System.Drawing.Point(136, 137);
            this.txtPolygonSW.Name = "txtPolygonSW";
            this.txtPolygonSW.Size = new System.Drawing.Size(434, 29);
            this.txtPolygonSW.TabIndex = 4;
            this.txtPolygonSW.Leave += new System.EventHandler(this.txtPolygonSW_Leave);
            // 
            // lblSWCoordinateOK
            // 
            this.lblSWCoordinateOK.AutoSize = true;
            this.lblSWCoordinateOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSWCoordinateOK.Location = new System.Drawing.Point(136, 169);
            this.lblSWCoordinateOK.Name = "lblSWCoordinateOK";
            this.lblSWCoordinateOK.Size = new System.Drawing.Size(101, 15);
            this.lblSWCoordinateOK.TabIndex = 150;
            this.lblSWCoordinateOK.Text = "Coordinates okay";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(4, 138);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(126, 29);
            this.label22.TabIndex = 149;
            this.label22.Text = "South West";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 15);
            this.label14.TabIndex = 147;
            this.label14.Text = "Lat/Lng, UTM, MGRS";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPolygonNE
            // 
            this.txtPolygonNE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPolygonNE.Location = new System.Drawing.Point(136, 87);
            this.txtPolygonNE.Name = "txtPolygonNE";
            this.txtPolygonNE.Size = new System.Drawing.Size(434, 29);
            this.txtPolygonNE.TabIndex = 3;
            this.txtPolygonNE.Leave += new System.EventHandler(this.txtPolygonNE_Leave);
            // 
            // lblNECoordinateOK
            // 
            this.lblNECoordinateOK.AutoSize = true;
            this.lblNECoordinateOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNECoordinateOK.Location = new System.Drawing.Point(136, 119);
            this.lblNECoordinateOK.Name = "lblNECoordinateOK";
            this.lblNECoordinateOK.Size = new System.Drawing.Size(101, 15);
            this.lblNECoordinateOK.TabIndex = 146;
            this.lblNECoordinateOK.Text = "Coordinates okay";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(4, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 29);
            this.label16.TabIndex = 145;
            this.label16.Text = "North East";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 15);
            this.label10.TabIndex = 143;
            this.label10.Text = "Lat/Lng, UTM, MGRS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPolygonNW
            // 
            this.txtPolygonNW.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPolygonNW.Location = new System.Drawing.Point(136, 37);
            this.txtPolygonNW.Name = "txtPolygonNW";
            this.txtPolygonNW.Size = new System.Drawing.Size(434, 29);
            this.txtPolygonNW.TabIndex = 2;
            this.txtPolygonNW.Leave += new System.EventHandler(this.txtPolygonNW_Leave);
            // 
            // lblNWCoordinateOK
            // 
            this.lblNWCoordinateOK.AutoSize = true;
            this.lblNWCoordinateOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNWCoordinateOK.Location = new System.Drawing.Point(136, 69);
            this.lblNWCoordinateOK.Name = "lblNWCoordinateOK";
            this.lblNWCoordinateOK.Size = new System.Drawing.Size(101, 15);
            this.lblNWCoordinateOK.TabIndex = 142;
            this.lblNWCoordinateOK.Text = "Coordinates okay";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(4, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 29);
            this.label13.TabIndex = 141;
            this.label13.Text = "North West";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 29);
            this.label9.TabIndex = 139;
            this.label9.Text = "Polygon";
            // 
            // rbPoygon
            // 
            this.rbPoygon.AutoSize = true;
            this.rbPoygon.Location = new System.Drawing.Point(448, 3);
            this.rbPoygon.Name = "rbPoygon";
            this.rbPoygon.Size = new System.Drawing.Size(97, 28);
            this.rbPoygon.TabIndex = 137;
            this.rbPoygon.TabStop = true;
            this.rbPoygon.Text = "Polygon";
            this.rbPoygon.UseVisualStyleBackColor = true;
            this.rbPoygon.Visible = false;
            this.rbPoygon.CheckedChanged += new System.EventHandler(this.rbPoygon_CheckedChanged);
            // 
            // pnlRadius
            // 
            this.pnlRadius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRadius.Controls.Add(this.label8);
            this.pnlRadius.Controls.Add(this.label7);
            this.pnlRadius.Controls.Add(this.rbRadius);
            this.pnlRadius.Controls.Add(this.numRadius);
            this.pnlRadius.Controls.Add(this.label1);
            this.pnlRadius.Controls.Add(this.label3);
            this.pnlRadius.Controls.Add(this.txtRadiusCoordinates);
            this.pnlRadius.Controls.Add(this.lblCoordinateStatus);
            this.pnlRadius.Controls.Add(this.label5);
            this.pnlRadius.Location = new System.Drawing.Point(13, 309);
            this.pnlRadius.Name = "pnlRadius";
            this.pnlRadius.Size = new System.Drawing.Size(579, 133);
            this.pnlRadius.TabIndex = 6;
            this.pnlRadius.Enter += new System.EventHandler(this.pnlRadius_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 29);
            this.label8.TabIndex = 138;
            this.label8.Text = "Radius";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(57, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 15);
            this.label7.TabIndex = 137;
            this.label7.Text = "Lat/Lng, UTM, MGRS";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbRadius
            // 
            this.rbRadius.AutoSize = true;
            this.rbRadius.Location = new System.Drawing.Point(467, 3);
            this.rbRadius.Name = "rbRadius";
            this.rbRadius.Size = new System.Drawing.Size(86, 28);
            this.rbRadius.TabIndex = 136;
            this.rbRadius.TabStop = true;
            this.rbRadius.Text = "Radius";
            this.rbRadius.UseVisualStyleBackColor = true;
            this.rbRadius.Visible = false;
            this.rbRadius.CheckedChanged += new System.EventHandler(this.rbRadius_CheckedChanged);
            // 
            // numRadius
            // 
            this.numRadius.Location = new System.Drawing.Point(190, 40);
            this.numRadius.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRadius.Name = "numRadius";
            this.numRadius.Size = new System.Drawing.Size(87, 29);
            this.numRadius.TabIndex = 7;
            this.numRadius.ValueChanged += new System.EventHandler(this.numRadius_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 26);
            this.label1.TabIndex = 130;
            this.label1.Text = "Radius";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(284, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 133;
            this.label3.Text = "Nautical Miles";
            // 
            // txtRadiusCoordinates
            // 
            this.txtRadiusCoordinates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRadiusCoordinates.Location = new System.Drawing.Point(190, 74);
            this.txtRadiusCoordinates.Name = "txtRadiusCoordinates";
            this.txtRadiusCoordinates.Size = new System.Drawing.Size(384, 29);
            this.txtRadiusCoordinates.TabIndex = 8;
            this.txtRadiusCoordinates.Leave += new System.EventHandler(this.txtCoordinates_Leave);
            // 
            // lblCoordinateStatus
            // 
            this.lblCoordinateStatus.AutoSize = true;
            this.lblCoordinateStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordinateStatus.Location = new System.Drawing.Point(187, 106);
            this.lblCoordinateStatus.Name = "lblCoordinateStatus";
            this.lblCoordinateStatus.Size = new System.Drawing.Size(101, 15);
            this.lblCoordinateStatus.TabIndex = 129;
            this.lblCoordinateStatus.Text = "Coordinates okay";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 29);
            this.label5.TabIndex = 128;
            this.label5.Text = "Centre Coordinates";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(298, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 15);
            this.label6.TabIndex = 134;
            this.label6.Text = "Feet Above Sea Level (ASL)";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 501);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(424, 24);
            this.label2.TabIndex = 132;
            this.label2.Text = "Enter the geographic description of the center point of the restriction.";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 26);
            this.label4.TabIndex = 131;
            this.label4.Text = "Altitude";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // numAltitude
            // 
            this.numAltitude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numAltitude.Location = new System.Drawing.Point(172, 12);
            this.numAltitude.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numAltitude.Name = "numAltitude";
            this.numAltitude.Size = new System.Drawing.Size(120, 29);
            this.numAltitude.TabIndex = 0;
            this.numAltitude.ValueChanged += new System.EventHandler(this.numAltitude_ValueChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.Location = new System.Drawing.Point(13, 448);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 26);
            this.label12.TabIndex = 120;
            this.label12.Text = "Centre Point";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCenterPoint
            // 
            this.txtCenterPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCenterPoint.Location = new System.Drawing.Point(172, 448);
            this.txtCenterPoint.Multiline = true;
            this.txtCenterPoint.Name = "txtCenterPoint";
            this.txtCenterPoint.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCenterPoint.Size = new System.Drawing.Size(420, 50);
            this.txtCenterPoint.TabIndex = 9;
            this.txtCenterPoint.TextChanged += new System.EventHandler(this.txtCenterPoint_TextChanged);
            // 
            // AirNOTAMEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(603, 604);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(619, 643);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(619, 643);
            this.Name = "AirNOTAMEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit NOTAM Info";
            this.Load += new System.EventHandler(this.AirNOTAMEditForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlPolygon.ResumeLayout(false);
            this.pnlPolygon.PerformLayout();
            this.pnlRadius.ResumeLayout(false);
            this.pnlRadius.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltitude)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.NumericUpDown numAltitude;
        private System.Windows.Forms.NumericUpDown numRadius;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCenterPoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCoordinateStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRadiusCoordinates;
        private System.Windows.Forms.Panel pnlPolygon;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPolygonNE;
        private System.Windows.Forms.Label lblNECoordinateOK;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPolygonNW;
        private System.Windows.Forms.Label lblNWCoordinateOK;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton rbPoygon;
        private System.Windows.Forms.Panel pnlRadius;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbRadius;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtPolygonSE;
        private System.Windows.Forms.Label lblSECoordinateOK;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtPolygonSW;
        private System.Windows.Forms.Label lblSWCoordinateOK;
        private System.Windows.Forms.Label label22;
    }
}