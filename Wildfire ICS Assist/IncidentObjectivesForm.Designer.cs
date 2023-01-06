namespace Wildfire_ICS_Assist
{
    partial class IncidentObjectivesForm
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
            this.dgvObjectives = new System.Windows.Forms.DataGridView();
            this.cpFireStatus = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.cboFireStatus = new System.Windows.Forms.ComboBox();
            this.txtFireSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cpGeneralSafety = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.txtGeneralSafetyMessage = new System.Windows.Forms.TextBox();
            this.cpWeather = new Wildfire_ICS_Assist.CustomControls.CollapsiblePanel();
            this.txtWeatherForcast = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.colObjective = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUp = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colDown = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectives)).BeginInit();
            this.cpFireStatus.SuspendLayout();
            this.cpGeneralSafety.SuspendLayout();
            this.cpWeather.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.btnPrint);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnNew);
            this.splitContainer1.Size = new System.Drawing.Size(1079, 455);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvObjectives);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.cpFireStatus);
            this.splitContainer2.Panel2.Controls.Add(this.cpGeneralSafety);
            this.splitContainer2.Panel2.Controls.Add(this.cpWeather);
            this.splitContainer2.Size = new System.Drawing.Size(1079, 396);
            this.splitContainer2.SplitterDistance = 577;
            this.splitContainer2.TabIndex = 2;
            // 
            // dgvObjectives
            // 
            this.dgvObjectives.AllowUserToAddRows = false;
            this.dgvObjectives.AllowUserToDeleteRows = false;
            this.dgvObjectives.AllowUserToResizeColumns = false;
            this.dgvObjectives.AllowUserToResizeRows = false;
            this.dgvObjectives.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvObjectives.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvObjectives.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.dgvObjectives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObjectives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colObjective,
            this.colUp,
            this.colDown});
            this.dgvObjectives.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvObjectives.Location = new System.Drawing.Point(0, 0);
            this.dgvObjectives.Name = "dgvObjectives";
            this.dgvObjectives.ReadOnly = true;
            this.dgvObjectives.RowHeadersVisible = false;
            this.dgvObjectives.RowTemplate.Height = 30;
            this.dgvObjectives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvObjectives.Size = new System.Drawing.Size(577, 396);
            this.dgvObjectives.TabIndex = 0;
            this.dgvObjectives.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjectives_CellContentClick);
            this.dgvObjectives.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjectives_CellContentDoubleClick);
            this.dgvObjectives.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObjectives_CellDoubleClick);
            this.dgvObjectives.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvObjectives_CellPainting);
            this.dgvObjectives.SelectionChanged += new System.EventHandler(this.dgvObjectives_SelectionChanged);
            // 
            // cpFireStatus
            // 
            this.cpFireStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpFireStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpFireStatus.CollapsedHeight = 40;
            this.cpFireStatus.CollapsedWidth = 485;
            this.cpFireStatus.CollapseLeft = true;
            this.cpFireStatus.Controls.Add(this.cboFireStatus);
            this.cpFireStatus.Controls.Add(this.txtFireSize);
            this.cpFireStatus.Controls.Add(this.label2);
            this.cpFireStatus.Controls.Add(this.label1);
            this.cpFireStatus.CurrentlyCollapsed = true;
            this.cpFireStatus.ExpandedHeight = 137;
            this.cpFireStatus.ExpandedWidth = 485;
            this.cpFireStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpFireStatus.Location = new System.Drawing.Point(7, 119);
            this.cpFireStatus.Margin = new System.Windows.Forms.Padding(6);
            this.cpFireStatus.Name = "cpFireStatus";
            this.cpFireStatus.Size = new System.Drawing.Size(485, 40);
            this.cpFireStatus.TabIndex = 60;
            this.cpFireStatus.TitleText = "Fire Size / Status";
            // 
            // cboFireStatus
            // 
            this.cboFireStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboFireStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboFireStatus.FormattingEnabled = true;
            this.cboFireStatus.Items.AddRange(new object[] {
            "OC",
            "NUC",
            "BH",
            "UC"});
            this.cboFireStatus.Location = new System.Drawing.Point(120, 83);
            this.cboFireStatus.Name = "cboFireStatus";
            this.cboFireStatus.Size = new System.Drawing.Size(183, 32);
            this.cboFireStatus.TabIndex = 38;
            this.cboFireStatus.Leave += new System.EventHandler(this.cboFireStatus_Leave);
            // 
            // txtFireSize
            // 
            this.txtFireSize.Location = new System.Drawing.Point(120, 48);
            this.txtFireSize.Name = "txtFireSize";
            this.txtFireSize.Size = new System.Drawing.Size(183, 29);
            this.txtFireSize.TabIndex = 37;
            this.txtFireSize.Leave += new System.EventHandler(this.txtFireSize_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 29);
            this.label2.TabIndex = 34;
            this.label2.Text = "Fire Status";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 29);
            this.label1.TabIndex = 33;
            this.label1.Text = "Fire Size ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cpGeneralSafety
            // 
            this.cpGeneralSafety.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpGeneralSafety.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpGeneralSafety.CollapsedHeight = 40;
            this.cpGeneralSafety.CollapsedWidth = 485;
            this.cpGeneralSafety.CollapseLeft = true;
            this.cpGeneralSafety.Controls.Add(this.txtGeneralSafetyMessage);
            this.cpGeneralSafety.CurrentlyCollapsed = true;
            this.cpGeneralSafety.ExpandedHeight = 260;
            this.cpGeneralSafety.ExpandedWidth = 485;
            this.cpGeneralSafety.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpGeneralSafety.Location = new System.Drawing.Point(7, 67);
            this.cpGeneralSafety.Margin = new System.Windows.Forms.Padding(6);
            this.cpGeneralSafety.Name = "cpGeneralSafety";
            this.cpGeneralSafety.Size = new System.Drawing.Size(485, 40);
            this.cpGeneralSafety.TabIndex = 59;
            this.cpGeneralSafety.TitleText = "General Safety Message";
            // 
            // txtGeneralSafetyMessage
            // 
            this.txtGeneralSafetyMessage.Location = new System.Drawing.Point(6, 49);
            this.txtGeneralSafetyMessage.Multiline = true;
            this.txtGeneralSafetyMessage.Name = "txtGeneralSafetyMessage";
            this.txtGeneralSafetyMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGeneralSafetyMessage.Size = new System.Drawing.Size(473, 206);
            this.txtGeneralSafetyMessage.TabIndex = 33;
            this.txtGeneralSafetyMessage.Leave += new System.EventHandler(this.txtGeneralSafetyMessage_Leave);
            // 
            // cpWeather
            // 
            this.cpWeather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(218)))), ((int)(((byte)(204)))));
            this.cpWeather.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cpWeather.CollapsedHeight = 40;
            this.cpWeather.CollapsedWidth = 485;
            this.cpWeather.CollapseLeft = true;
            this.cpWeather.Controls.Add(this.txtWeatherForcast);
            this.cpWeather.CurrentlyCollapsed = true;
            this.cpWeather.ExpandedHeight = 260;
            this.cpWeather.ExpandedWidth = 485;
            this.cpWeather.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpWeather.Location = new System.Drawing.Point(7, 15);
            this.cpWeather.Margin = new System.Windows.Forms.Padding(6);
            this.cpWeather.Name = "cpWeather";
            this.cpWeather.Size = new System.Drawing.Size(485, 40);
            this.cpWeather.TabIndex = 58;
            this.cpWeather.TitleText = "Weather Forcast";
            // 
            // txtWeatherForcast
            // 
            this.txtWeatherForcast.Location = new System.Drawing.Point(6, 49);
            this.txtWeatherForcast.Multiline = true;
            this.txtWeatherForcast.Name = "txtWeatherForcast";
            this.txtWeatherForcast.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtWeatherForcast.Size = new System.Drawing.Size(474, 206);
            this.txtWeatherForcast.TabIndex = 33;
            this.txtWeatherForcast.Leave += new System.EventHandler(this.txtWeatherForcast_Leave);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_16_print;
            this.btnPrint.Location = new System.Drawing.Point(954, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 42);
            this.btnPrint.TabIndex = 51;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDelete.Location = new System.Drawing.Point(274, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 51);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_31_pencil;
            this.btnEdit.Location = new System.Drawing.Point(143, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(125, 51);
            this.btnEdit.TabIndex = 34;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_371_plus;
            this.btnNew.Location = new System.Drawing.Point(12, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(125, 51);
            this.btnNew.TabIndex = 33;
            this.btnNew.Text = "Add";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // colObjective
            // 
            this.colObjective.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colObjective.DataPropertyName = "Objective";
            this.colObjective.HeaderText = "Objective";
            this.colObjective.MinimumWidth = 200;
            this.colObjective.Name = "colObjective";
            this.colObjective.ReadOnly = true;
            // 
            // colUp
            // 
            this.colUp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colUp.HeaderText = "";
            this.colUp.Name = "colUp";
            this.colUp.ReadOnly = true;
            this.colUp.Width = 65;
            // 
            // colDown
            // 
            this.colDown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDown.HeaderText = "";
            this.colDown.Name = "colDown";
            this.colDown.ReadOnly = true;
            this.colDown.Width = 65;
            // 
            // IncidentObjectivesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(245)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1079, 455);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "IncidentObjectivesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Incident Objectives";
            this.Load += new System.EventHandler(this.IncidentObjectivesForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvObjectives)).EndInit();
            this.cpFireStatus.ResumeLayout(false);
            this.cpFireStatus.PerformLayout();
            this.cpGeneralSafety.ResumeLayout(false);
            this.cpGeneralSafety.PerformLayout();
            this.cpWeather.ResumeLayout(false);
            this.cpWeather.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvObjectives;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CustomControls.CollapsiblePanel cpGeneralSafety;
        private System.Windows.Forms.TextBox txtGeneralSafetyMessage;
        private CustomControls.CollapsiblePanel cpWeather;
        private System.Windows.Forms.TextBox txtWeatherForcast;
        private CustomControls.CollapsiblePanel cpFireStatus;
        private System.Windows.Forms.ComboBox cboFireStatus;
        private System.Windows.Forms.TextBox txtFireSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjective;
        private System.Windows.Forms.DataGridViewButtonColumn colUp;
        private System.Windows.Forms.DataGridViewButtonColumn colDown;
    }
}