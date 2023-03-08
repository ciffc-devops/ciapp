﻿namespace Wildfire_ICS_Assist.CustomControls
{
    partial class CrewEditControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTransport = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteResource = new System.Windows.Forms.Button();
            this.dgvGroup = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLeader = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnAddVehicle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(5, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 23);
            this.label11.TabIndex = 115;
            this.label11.Text = "(within incident)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(21, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 29);
            this.label3.TabIndex = 111;
            this.label3.Text = "Crew Identifier*:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTransport
            // 
            this.txtTransport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransport.Location = new System.Drawing.Point(204, 111);
            this.txtTransport.Name = "txtTransport";
            this.txtTransport.Size = new System.Drawing.Size(538, 29);
            this.txtTransport.TabIndex = 4;
            this.txtTransport.TextChanged += new System.EventHandler(this.txtTransport_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(204, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(538, 29);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 29);
            this.label5.TabIndex = 113;
            this.label5.Text = "Transport:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 29);
            this.label6.TabIndex = 119;
            this.label6.Text = "Email";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(204, 76);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(538, 29);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 29);
            this.label1.TabIndex = 118;
            this.label1.Text = "Cellphone";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.Location = new System.Drawing.Point(204, 38);
            this.txtPhone.Mask = "(999) 000-0000";
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(538, 29);
            this.txtPhone.TabIndex = 2;
            this.txtPhone.Leave += new System.EventHandler(this.txtPhone_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 388);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 47);
            this.label2.TabIndex = 122;
            this.label2.Text = "Edit values directly in the grid";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeleteResource
            // 
            this.btnDeleteResource.Enabled = false;
            this.btnDeleteResource.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_17_bin;
            this.btnDeleteResource.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteResource.Location = new System.Drawing.Point(12, 318);
            this.btnDeleteResource.Name = "btnDeleteResource";
            this.btnDeleteResource.Size = new System.Drawing.Size(157, 67);
            this.btnDeleteResource.TabIndex = 7;
            this.btnDeleteResource.Text = "Delete";
            this.btnDeleteResource.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteResource.UseVisualStyleBackColor = true;
            this.btnDeleteResource.Click += new System.EventHandler(this.btnDeleteResource_Click);
            // 
            // dgvGroup
            // 
            this.dgvGroup.AllowUserToAddRows = false;
            this.dgvGroup.AllowUserToDeleteRows = false;
            this.dgvGroup.AllowUserToResizeColumns = false;
            this.dgvGroup.AllowUserToResizeRows = false;
            this.dgvGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colKind,
            this.colType,
            this.colLeader});
            this.dgvGroup.Location = new System.Drawing.Point(175, 172);
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.RowHeadersVisible = false;
            this.dgvGroup.RowTemplate.Height = 30;
            this.dgvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroup.Size = new System.Drawing.Size(567, 358);
            this.dgvGroup.TabIndex = 8;
            this.dgvGroup.SelectionChanged += new System.EventHandler(this.dgvGroup_SelectionChanged);
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colName.DataPropertyName = "ResourceName";
            this.colName.HeaderText = "Resource Name";
            this.colName.MinimumWidth = 250;
            this.colName.Name = "colName";
            // 
            // colKind
            // 
            this.colKind.DataPropertyName = "Kind";
            this.colKind.HeaderText = "Kind";
            this.colKind.Name = "colKind";
            // 
            // colType
            // 
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "Type";
            this.colType.Name = "colType";
            // 
            // colLeader
            // 
            this.colLeader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.colLeader.DataPropertyName = "Role";
            this.colLeader.HeaderText = "Role";
            this.colLeader.Items.AddRange(new object[] {
            "Leader",
            "Crew Boss",
            "Crew",
            "Operator"});
            this.colLeader.Name = "colLeader";
            this.colLeader.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLeader.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLeader.Width = 74;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_893_user_worker;
            this.btnAddPerson.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddPerson.Location = new System.Drawing.Point(12, 172);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(157, 67);
            this.btnAddPerson.TabIndex = 5;
            this.btnAddPerson.Text = "Add Person";
            this.btnAddPerson.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnAddVehicle
            // 
            this.btnAddVehicle.Image = global::Wildfire_ICS_Assist.Properties.Resources.glyphicons_basic_29_cars;
            this.btnAddVehicle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddVehicle.Location = new System.Drawing.Point(12, 245);
            this.btnAddVehicle.Name = "btnAddVehicle";
            this.btnAddVehicle.Size = new System.Drawing.Size(157, 67);
            this.btnAddVehicle.TabIndex = 6;
            this.btnAddVehicle.Text = "Add Veh/Equip";
            this.btnAddVehicle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddVehicle.UseVisualStyleBackColor = true;
            this.btnAddVehicle.Click += new System.EventHandler(this.btnAddVehicle_Click);
            // 
            // CrewEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddVehicle);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleteResource);
            this.Controls.Add(this.dgvGroup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTransport);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CrewEditControl";
            this.Size = new System.Drawing.Size(745, 533);
            this.Load += new System.EventHandler(this.CrewEditControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTransport;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtPhone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteResource;
        private System.Windows.Forms.DataGridView dgvGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewComboBoxColumn colLeader;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnAddVehicle;
    }
}
