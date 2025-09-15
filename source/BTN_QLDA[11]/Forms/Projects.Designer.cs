namespace BTN_QLDA_11_.Forms
{
    partial class frmQLDA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQLDA));
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnInstructors = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnLDomains = new System.Windows.Forms.Button();
            this.btnProjects = new System.Windows.Forms.Button();
            this.dtgrvProjects = new System.Windows.Forms.DataGridView();
            this.clActions = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.projectManagement3DataSet = new BTN_QLDA_11_.ProjectManagement3DataSet();
            this.projectManagement3DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvProjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectManagement3DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectManagement3DataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelTop.Controls.Add(this.btnInstructors);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.btnStudents);
            this.panelTop.Controls.Add(this.btnLDomains);
            this.panelTop.Controls.Add(this.btnProjects);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1252, 131);
            this.panelTop.TabIndex = 7;
            // 
            // btnInstructors
            // 
            this.btnInstructors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnInstructors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstructors.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstructors.ForeColor = System.Drawing.Color.White;
            this.btnInstructors.Location = new System.Drawing.Point(751, 67);
            this.btnInstructors.Name = "btnInstructors";
            this.btnInstructors.Size = new System.Drawing.Size(172, 46);
            this.btnInstructors.TabIndex = 1;
            this.btnInstructors.Text = "INSTRUCTORS";
            this.btnInstructors.UseVisualStyleBackColor = false;
            this.btnInstructors.Click += new System.EventHandler(this.btnInstructors_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label2.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(389, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(484, 48);
            this.label2.TabIndex = 0;
            this.label2.Text = "PROJECTS MANAGEMNT";
            // 
            // btnStudents
            // 
            this.btnStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudents.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudents.ForeColor = System.Drawing.Color.White;
            this.btnStudents.Location = new System.Drawing.Point(611, 67);
            this.btnStudents.Name = "btnStudents";
            this.btnStudents.Size = new System.Drawing.Size(134, 46);
            this.btnStudents.TabIndex = 1;
            this.btnStudents.Text = "STUDENTS";
            this.btnStudents.UseVisualStyleBackColor = false;
            this.btnStudents.Click += new System.EventHandler(this.btnStudents_Click);
            // 
            // btnLDomains
            // 
            this.btnLDomains.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnLDomains.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLDomains.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLDomains.ForeColor = System.Drawing.Color.White;
            this.btnLDomains.Location = new System.Drawing.Point(471, 67);
            this.btnLDomains.Name = "btnLDomains";
            this.btnLDomains.Size = new System.Drawing.Size(134, 46);
            this.btnLDomains.TabIndex = 1;
            this.btnLDomains.Text = "DOMAINS";
            this.btnLDomains.UseVisualStyleBackColor = false;
            this.btnLDomains.Click += new System.EventHandler(this.btnLDomains_Click);
            // 
            // btnProjects
            // 
            this.btnProjects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnProjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProjects.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProjects.ForeColor = System.Drawing.Color.White;
            this.btnProjects.Location = new System.Drawing.Point(331, 67);
            this.btnProjects.Name = "btnProjects";
            this.btnProjects.Size = new System.Drawing.Size(134, 46);
            this.btnProjects.TabIndex = 1;
            this.btnProjects.Text = "PROJECTS";
            this.btnProjects.UseVisualStyleBackColor = false;
            // 
            // dtgrvProjects
            // 
            this.dtgrvProjects.BackgroundColor = System.Drawing.Color.White;
            this.dtgrvProjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrvProjects.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clActions,
            this.clEdit,
            this.clDelete});
            this.dtgrvProjects.GridColor = System.Drawing.Color.White;
            this.dtgrvProjects.Location = new System.Drawing.Point(20, 334);
            this.dtgrvProjects.Name = "dtgrvProjects";
            this.dtgrvProjects.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtgrvProjects.RowHeadersVisible = false;
            this.dtgrvProjects.RowHeadersWidth = 51;
            this.dtgrvProjects.RowTemplate.Height = 24;
            this.dtgrvProjects.Size = new System.Drawing.Size(1220, 323);
            this.dtgrvProjects.TabIndex = 14;
            this.dtgrvProjects.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrvProjects_CellContentClick);
            // 
            // clActions
            // 
            this.clActions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.clActions.DefaultCellStyle = dataGridViewCellStyle1;
            this.clActions.FillWeight = 1F;
            this.clActions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clActions.HeaderText = "VIEW";
            this.clActions.MinimumWidth = 6;
            this.clActions.Name = "clActions";
            this.clActions.Text = "View";
            this.clActions.UseColumnTextForButtonValue = true;
            this.clActions.Width = 47;
            // 
            // clEdit
            // 
            this.clEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.clEdit.DefaultCellStyle = dataGridViewCellStyle2;
            this.clEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clEdit.HeaderText = "EDIT";
            this.clEdit.MinimumWidth = 6;
            this.clEdit.Name = "clEdit";
            this.clEdit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clEdit.Text = "Edit";
            this.clEdit.UseColumnTextForButtonValue = true;
            this.clEdit.Width = 67;
            // 
            // clDelete
            // 
            this.clDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.clDelete.DefaultCellStyle = dataGridViewCellStyle3;
            this.clDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clDelete.HeaderText = "DELETE";
            this.clDelete.MinimumWidth = 6;
            this.clDelete.Name = "clDelete";
            this.clDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clDelete.Text = "Delete";
            this.clDelete.UseColumnTextForButtonValue = true;
            this.clDelete.Width = 89;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(20, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(226, 39);
            this.button1.TabIndex = 13;
            this.button1.Text = "+ ADD NEW PROJECT";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtSearch.Location = new System.Drawing.Point(20, 249);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(425, 34);
            this.txtSearch.TabIndex = 12;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 213);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel1.Location = new System.Drawing.Point(20, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1188, 2);
            this.panel1.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.label3.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(53, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "FIND PROJECTS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.label1.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(12, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(285, 34);
            this.label1.TabIndex = 9;
            this.label1.Text = "CURRENT PROJECTS";
            // 
            // projectManagement3DataSet
            // 
            this.projectManagement3DataSet.DataSetName = "ProjectManagement3DataSet";
            this.projectManagement3DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // projectManagement3DataSetBindingSource
            // 
            this.projectManagement3DataSetBindingSource.DataSource = this.projectManagement3DataSet;
            this.projectManagement3DataSetBindingSource.Position = 0;
            // 
            // frmQLDA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 663);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dtgrvProjects);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmQLDA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý đề tài đồ án";
            this.Load += new System.EventHandler(this.frmQLDA_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvProjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectManagement3DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectManagement3DataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnInstructors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnLDomains;
        private System.Windows.Forms.Button btnProjects;
        private System.Windows.Forms.DataGridView dtgrvProjects;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn clActions;
        private System.Windows.Forms.DataGridViewButtonColumn clEdit;
        private System.Windows.Forms.DataGridViewButtonColumn clDelete;
        private System.Windows.Forms.BindingSource projectManagement3DataSetBindingSource;
        private ProjectManagement3DataSet projectManagement3DataSet;
    }
}