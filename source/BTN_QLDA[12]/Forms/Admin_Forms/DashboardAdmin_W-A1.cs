using BTN_QLDA_12_.Forms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BTN_QLDA_12_.Forms
{
    public partial class DashboardAdmin_W_A1 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        List<Announcements> Announcements;

        public DashboardAdmin_W_A1(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;            
            lblAccountName.Text = _Account.FullName;
            lblTotalLecture.Text = GetTotalLecture().ToString();
            lblTotalStudent.Text = GetTotalStudent().ToString();
            lblTotalProjecvtPeriodOpened.Text = GetTotalProjectPeriod().ToString();
            LoadLatestAction();
        }
        //Load admin dashboard
        private void LoadLatestAction()
        {
            Announcements = new List<Announcements>();
            Announcements = _context.Announcements.ToList();
            foreach (var announcement in Announcements)
            {
                TextBox tb = new TextBox();
                tb.Multiline = true;
                tb.Text = announcement.Title + Environment.NewLine + "\t" + announcement.Content;
                tb.Font = new Font("Roboto Condensed Medium", 12f, FontStyle.Bold);
                tb.Size = new Size(700, 50);
                tb.BorderStyle = BorderStyle.None;

                pnlLatestActions.Controls.Add(tb);

                FlowLayoutPanel pn = new FlowLayoutPanel();
                pn.BorderStyle = BorderStyle.None;
                pn.BackColor = Color.Black;
                pn.Size = new Size(830, 1);

                pnlLatestActions.Controls.Add(pn);
            }
        }
        private int GetTotalLecture()
        {
            return _context.users.Count(u => u.Role == RoleAccount.Lecturer.ToString());
        }
        private int GetTotalStudent()
        {
            return _context.users.Count(u => u.Role == RoleAccount.Student.ToString());
        }
        private int GetTotalProjectPeriod()
        {
            return _context.ProjectsPeriods.Count(pr => pr.Status != PeriodStatus.Đã_đóng.ToString().Replace("_", " "));
        }
        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void tmSideBar_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                pnSideBar.Width -= 10;//decrease 10 pixcel each tick of time        
                var X = btnSideBar.Location.X - 10;
                btnSideBar.Location = new Point(X, btnSideBar.Location.Y);
                if (pnSideBar.Width == pnSideBar.MinimumSize.Width)
                {
                    menuExpand = false;
                    tmSideBar.Stop();
                }
            }
            else
            {
                pnSideBar.Width += 10;//Increase 10 pixcel each tick of time
                var X = btnSideBar.Location.X + 10;
                btnSideBar.Location = new Point(X, btnSideBar.Location.Y);
                if (pnSideBar.Width == pnSideBar.MaximumSize.Width)
                {
                    menuExpand = true;
                    tmSideBar.Stop();
                }
            }
        }
        private void btnSideBar_Click(object sender, EventArgs e)
        {
            tmSideBar.Start();
        }
        //Move to W-A3 Lecture
        private void panel5_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var userManagement = new Forms.User_Management_W_A3(_context, _Account);
            userManagement.ShowDialog();
            this.Close();
        }
        //Move to W-A3 Student
        private void panel12_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var userManagement = new Forms.User_Management_W_A3(_context, _Account);
            userManagement.ShowDialog();
            this.Close();
        }
        //move to W-A2 Project Period management
        private void panel10_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var userManagement = new Forms.ProjectPeriodManagement_W_A2(_context, _Account);
            userManagement.ShowDialog();
            this.Close();
        }
        //Add new Period
        private void btnAddNewPeriod_Click(object sender, EventArgs e)
        {
            var userManagement = new Forms.Admin_Forms.ProjectPeriodDetail_W_A2_Detail(_context);
            userManagement.FormClosed += new FormClosedEventHandler(DashboardAdmin_W_A1_FormClosed);
            userManagement.ShowDialog();
        }
        //Add 1 new user
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            var userManagement = new Forms.Lecture_Detail_W_A3_Detail(_context);
            userManagement.FormClosed += new FormClosedEventHandler(DashboardAdmin_W_A1_FormClosed);
            userManagement.ShowDialog();
        }
        //panel sidebar
        private void pnlProjects_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.ProjectPeriodManagement_W_A2(_context, _Account);
            PeriodManagement.ShowDialog();
            this.Close();
        }
        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.Global_Announcements_W_A4(_context, _Account);
            PeriodManagement.ShowDialog();
            this.Close();
        }
        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.Reporting_Analytics_W_A5(_context, _Account);
            PeriodManagement.ShowDialog();
            this.Close();
        }
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.User_Management_W_A3(_context, _Account);
            PeriodManagement.ShowDialog();
            this.Close();
        }
        //Form close
        private void DashboardAdmin_W_A1_FormClosed(object sender, FormClosedEventArgs e)
        {
            lblAccountName.Text = _Account.FullName;
            lblTotalLecture.Text = GetTotalLecture().ToString();
            lblTotalStudent.Text = GetTotalStudent().ToString();
            lblTotalProjecvtPeriodOpened.Text = GetTotalProjectPeriod().ToString();
        }

        private void panel4_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muón đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.OK);
            if(result == DialogResult.OK)
            {
                Application.Restart();
                this.Close();
            }
        }
    }
}
