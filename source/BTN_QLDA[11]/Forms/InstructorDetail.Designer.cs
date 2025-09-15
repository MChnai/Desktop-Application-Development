namespace BTN_QLDA_11_.Forms
{
    partial class InstructorDetail
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnInstructors = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStudents = new System.Windows.Forms.Button();
            this.btnDomain = new System.Windows.Forms.Button();
            this.btnProjects = new System.Windows.Forms.Button();
            this.dtgrvProjects = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvProjects)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelTop.Controls.Add(this.btnInstructors);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.btnStudents);
            this.panelTop.Controls.Add(this.btnDomain);
            this.panelTop.Controls.Add(this.btnProjects);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1252, 131);
            this.panelTop.TabIndex = 21;
            // 
            // btnInstructors
            // 
            this.btnInstructors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnInstructors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstructors.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstructors.ForeColor = System.Drawing.Color.White;
            this.btnInstructors.Location = new System.Drawing.Point(751, 67);
            this.btnInstructors.Name = "btnInstructors";
            this.btnInstructors.Size = new System.Drawing.Size(175, 46);
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
            // btnDomain
            // 
            this.btnDomain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDomain.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDomain.ForeColor = System.Drawing.Color.White;
            this.btnDomain.Location = new System.Drawing.Point(471, 67);
            this.btnDomain.Name = "btnDomain";
            this.btnDomain.Size = new System.Drawing.Size(134, 46);
            this.btnDomain.TabIndex = 1;
            this.btnDomain.Text = "DOMAINS";
            this.btnDomain.UseVisualStyleBackColor = false;
            this.btnDomain.Click += new System.EventHandler(this.btnDomain_Click);
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
            this.btnProjects.Click += new System.EventHandler(this.btnProjects_Click);
            // 
            // dtgrvProjects
            // 
            this.dtgrvProjects.BackgroundColor = System.Drawing.Color.White;
            this.dtgrvProjects.ColumnHeadersHeight = 29;
            this.dtgrvProjects.EnableHeadersVisualStyles = false;
            this.dtgrvProjects.Location = new System.Drawing.Point(24, 296);
            this.dtgrvProjects.Name = "dtgrvProjects";
            this.dtgrvProjects.RowHeadersVisible = false;
            this.dtgrvProjects.RowHeadersWidth = 51;
            this.dtgrvProjects.RowTemplate.Height = 24;
            this.dtgrvProjects.Size = new System.Drawing.Size(1205, 358);
            this.dtgrvProjects.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Roboto Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(24, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(282, 37);
            this.button1.TabIndex = 25;
            this.button1.Text = "BACK TO INSTRUCTORS";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panel1.Location = new System.Drawing.Point(24, 189);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1205, 2);
            this.panel1.TabIndex = 24;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.lblName.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblName.Location = new System.Drawing.Point(20, 260);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(321, 24);
            this.lblName.TabIndex = 22;
            this.lblName.Text = "INSTRUCTOR JOINED PROJECTS: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.label1.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(18, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 34);
            this.label1.TabIndex = 23;
            this.label1.Text = "INSTRUCTORS";
            // 
            // InstructorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 663);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.dtgrvProjects);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Name = "InstructorDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instructor Detail";
            this.Load += new System.EventHandler(this.InstructorDetail_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrvProjects)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnInstructors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStudents;
        private System.Windows.Forms.Button btnDomain;
        private System.Windows.Forms.Button btnProjects;
        private System.Windows.Forms.DataGridView dtgrvProjects;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
    }
}