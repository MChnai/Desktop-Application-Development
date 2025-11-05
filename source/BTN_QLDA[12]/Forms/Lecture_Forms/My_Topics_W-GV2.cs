using BTN_QLDA_12_.Forms.Student_Forms;
using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.User_Role;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN_QLDA_12_.Forms.Lecture_Forms
{
    public partial class My_Topics_W_GV2 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        public My_Topics_W_GV2(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            lblAccountName.Text = _Account.FullName;
        }
        private void tmSideBar_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                pnSideBar.Width -= 10;//decrease 10 pixcel each tick of time        
                var X = pictureBox11.Location.X - 10;
                pictureBox11.Location = new Point(X, pictureBox11.Location.Y);
                if (pnSideBar.Width == pnSideBar.MinimumSize.Width)
                {
                    menuExpand = false;
                    tmSideBar.Stop();
                }
            }
            else
            {
                pnSideBar.Width += 10;//Increase 10 pixcel each tick of time
                var X = pictureBox11.Location.X + 10;
                pictureBox11.Location = new Point(X, pictureBox11.Location.Y);
                if (pnSideBar.Width == pnSideBar.MaximumSize.Width)
                {
                    menuExpand = true;
                    tmSideBar.Stop();
                }
            }
        }
        private void pnlDashboard_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new Student_Dashboard_W_SV1(_context, _Account);
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new Approve_Registrations_W_GV3(_context, _Account);
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new Account_Information_W2();
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
    }
}
