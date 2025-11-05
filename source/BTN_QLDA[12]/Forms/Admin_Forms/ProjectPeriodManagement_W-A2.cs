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

namespace BTN_QLDA_12_.Forms
{
    public partial class ProjectPeriodManagement_W_A2 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        List<ProjectPeriods> ProjectPeriods;
        public ProjectPeriodManagement_W_A2(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            lblAccountName.Text = _Account.FullName;  
            ProjectPeriods = new List<ProjectPeriods>();
            LoadPeriodList();
        }

        #region panel side bar
        private void tmSideBar_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                pnSideBar.Width -= 10;//decrease 10 pixcel each tick of time        
                var X = btnSideBar1.Location.X - 10;
                btnSideBar1.Location = new Point(X, btnSideBar1.Location.Y);
                if (pnSideBar.Width == pnSideBar.MinimumSize.Width)
                {
                    menuExpand = false;
                    tmSideBar.Stop();
                }
            }
            else
            {
                pnSideBar.Width += 10;//Increase 10 pixcel each tick of time
                var X = btnSideBar1.Location.X + 10;
                btnSideBar1.Location = new Point(X, btnSideBar1.Location.Y);
                if (pnSideBar.Width == pnSideBar.MaximumSize.Width)
                {
                    menuExpand = true;
                    tmSideBar.Stop();
                }
            }
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            tmSideBar.Start();
        }
        #endregion

        #region Load list
        private void LoadPeriodList()
        {
            lvProjectPeriod.Items.Clear();
            ProjectPeriods = _context.ProjectsPeriods.ToList();
            foreach(var item  in ProjectPeriods)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = item.Name.ToString();
                listViewItem.SubItems.Add(item.StartDate.ToString("dd/MM/yyyy"));
                listViewItem.SubItems.Add(item.EndDate.ToString("dd/MM/yyyy"));
                listViewItem.SubItems.Add(item.Status.ToString());
                lvProjectPeriod.Items.Add(listViewItem);
            }
        }
        private void LoadList(List<ProjectPeriods> list)
        {
            lvProjectPeriod.Items.Clear();
            foreach (var item in list)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.Text = item.Name.ToString();
                listViewItem.SubItems.Add(item.StartDate.ToString("dd/MM/yyyy"));
                listViewItem.SubItems.Add(item.EndDate.ToString("dd/MM/yyyy"));
                listViewItem.SubItems.Add(item.Status.ToString());
                lvProjectPeriod.Items.Add(listViewItem);
            }
        }
        private List<ProjectPeriods> FindList(string value)
        {
            List<ProjectPeriods> result = new List<ProjectPeriods>();
            foreach(ProjectPeriods item in ProjectPeriods)
            {
                if(item.Name.Contains(value) ||
                    item.StartDate.ToString("dd/MM/yyyy").Contains(value) ||
                    item.EndDate.ToString("dd/MM/yyyy").Contains(value) ||
                    item.Status.Contains(value))
                    result.Add(item);
            }
            return result;
        }
        #endregion

        #region Side bar
        private void pnlDashboard_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.DashboardAdmin_W_A1(_context, _Account);
            PeriodManagement.ShowDialog();
            this.Close();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
                LoadList(FindList(txtSearch.Text));
            else
                LoadPeriodList();
        }
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.User_Management_W_A3(_context, _Account);
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
        #endregion

        #region Add and search functions
        private void btnAddNewPeriod_Click(object sender, EventArgs e)
        {
            var userManagement = new Forms.Admin_Forms.ProjectPeriodDetail_W_A2_Detail(_context);
            userManagement.FormClosed += new FormClosedEventHandler(ProjectPeriodManagement_W_A2_FormClosed);
            userManagement.ShowDialog();
        }
        private void ProjectPeriodManagement_W_A2_FormClosed(object sender, FormClosedEventArgs e)
        {
            lblAccountName.Text = _Account.FullName;
            ProjectPeriods = new List<ProjectPeriods>();
            LoadPeriodList();
        }
        #endregion
    }
}
