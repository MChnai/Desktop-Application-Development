namespace BTN_QLDA_12_.Forms.Lecture_Forms
{
    partial class Student_Detail_StudyInfo_W_GV3_Detail
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
            this.button2 = new System.Windows.Forms.Button();
            this.lblGPA = new System.Windows.Forms.Label();
            this.lblStu = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Roboto Condensed", 12F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(483, 138);
            this.button2.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 33);
            this.button2.TabIndex = 152;
            this.button2.Text = "Đóng";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblGPA
            // 
            this.lblGPA.AutoSize = true;
            this.lblGPA.BackColor = System.Drawing.SystemColors.Control;
            this.lblGPA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblGPA.Font = new System.Drawing.Font("Roboto Condensed", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGPA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(179)))));
            this.lblGPA.Location = new System.Drawing.Point(8, 74);
            this.lblGPA.Margin = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.lblGPA.Name = "lblGPA";
            this.lblGPA.Size = new System.Drawing.Size(194, 39);
            this.lblGPA.TabIndex = 149;
            this.lblGPA.Text = "GPA tích lũy: ";
            this.lblGPA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStu
            // 
            this.lblStu.AutoSize = true;
            this.lblStu.BackColor = System.Drawing.SystemColors.Control;
            this.lblStu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStu.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            this.lblStu.Location = new System.Drawing.Point(10, 10);
            this.lblStu.Margin = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.lblStu.Name = "lblStu";
            this.lblStu.Size = new System.Drawing.Size(339, 37);
            this.lblStu.TabIndex = 141;
            this.lblStu.Text = "THÔNG TIN SINH VIÊN: ";
            this.lblStu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(37)))), ((int)(((byte)(60)))));
            this.panel6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.panel6.Location = new System.Drawing.Point(11, 52);
            this.panel6.Margin = new System.Windows.Forms.Padding(30, 20, 0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(586, 5);
            this.panel6.TabIndex = 142;
            // 
            // Student_Detail_StudyInfo_W_GV3_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 189);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblGPA);
            this.Controls.Add(this.lblStu);
            this.Controls.Add(this.panel6);
            this.Name = "Student_Detail_StudyInfo_W_GV3_Detail";
            this.Text = "Thông tin về học lực sinh viên";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblGPA;
        private System.Windows.Forms.Label lblStu;
        private System.Windows.Forms.Panel panel6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}