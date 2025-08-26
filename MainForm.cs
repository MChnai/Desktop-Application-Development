using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN_QLDA_4_
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Managing Fields
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            new ManagingFieldsForm().Show();
            this.Hide();
        }

        private void pbField_MouseEnter(object sender, EventArgs e)
        {
            pbField.Image = Properties.Resources.Fisrt_Yellow;
        }

        private void pbField_MouseLeave(object sender, EventArgs e)
        {
            pbField.Image = Properties.Resources.Fisrt_Black;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            pbField_MouseEnter(sender, e);
        }
        #endregion

        #region Managing Students
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            new ManagingStudentForm().Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            pictureBox11_Click(sender, e);
        }

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            pbStudent.Image = Properties.Resources.Second_Yellow;
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pbStudent.Image = Properties.Resources.Second_Black;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            pbStudent.Image = Properties.Resources.Second_Yellow;
        }
        #endregion

        #region Managing projects
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            new ManagingProjectForm().Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            pictureBox10_Click(sender, e);
        }

        private void pbProject_MouseEnter(object sender, EventArgs e)
        {
            pbProject.Image = Properties.Resources.Third_Yellow;
        }

        private void pbProject_MouseLeave(object sender, EventArgs e)
        {
            pbProject.Image = Properties.Resources.Third_Black;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            pbProject.Image = Properties.Resources.Third_Yellow;
        }
        #endregion

        #region Managing lectures
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            new ManagingLectureForm().Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            pictureBox9_Click(sender, e);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbLecture_MouseEnter(object sender, EventArgs e)
        {
            pbLecture.Image = Properties.Resources.Fourth_Yellow;
        }

        private void pbLecture_MouseLeave(object sender, EventArgs e)
        {
            pbLecture.Image = Properties.Resources.Fourth_Black;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            pbLecture.Image = Properties.Resources.Fourth_Yellow;
        }
        #endregion

        #region Statistic
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            new Statistic().Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            pictureBox12_Click(sender, e);
        }

        private void pbStatistic_MouseEnter(object sender, EventArgs e)
        {
            pbStatistic.Image = Properties.Resources.Fourth_Yellow;
        }

        private void pbStatistic_MouseLeave(object sender, EventArgs e)
        {
            pbStatistic.Image = Properties.Resources.Fourth_Black;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            pbStatistic.Image = Properties.Resources.Fourth_Yellow;
        }
        #endregion

        //Turn Back button
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }
    }
}
