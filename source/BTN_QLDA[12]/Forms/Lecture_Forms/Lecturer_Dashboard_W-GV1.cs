using BTN_QLDA_12_.Forms.Lecture_Forms;
using BTN_QLDA_12_.Forms.Student_Forms;
using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.User_Role;
using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class Lecturer_Dashboard_W_GV1 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        public Lecturer_Dashboard_W_GV1(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            lblAccountName.Text = _Account.FullName;
            LoadSignedNotification();
            LoadNearestNotification();
            LoadTopicList();
            lblGreeting.Text = "Chào mừng, " +  _Account.FullName ;
        }
        private void LoadTopicList()
        {
            List<Topics> topics = new List<Topics>();
            List<ProjectPeriods> period = new List<ProjectPeriods>();
            topics = _context.Topics
                        .Where(t => t.LecturerID == _Account.UserId)
                        .ToList();
            period = _context.ProjectsPeriods.ToList();
            lvTopics.Items.Clear(); 
            foreach (Topics topic in topics)
            {
                ListViewItem item = new ListViewItem();
                item.Text = topic.Title;
                foreach (var p in period)
                    if (p.ProjectPeriodID == topic.ProjectPeriodID)
                        item.SubItems.Add(p.Name);
                item.SubItems.Add(topic.MaxStudents.ToString());
                item.SubItems.Add(topic.Status);
                lvTopics.Items.Add(item);
            }
        }
        private void LoadSignedNotification()
        {
            List<Notifications> notifications = new List<Notifications>();
            notifications = _context.Notifications
                                .Where(u => u.RecipientID == _Account.UserId && u.LinkURL.Contains("/manage/registrations"))
                                .ToList();
            int amount = notifications.Count();
            lblSignNotification.Text = "Bạn có " + amount + " yêu cầu đăng ký đang chờ";
        }
        private void LoadNearestNotification()
        {
            Notifications notifications = new Notifications();
            notifications = _context.Notifications
                                .Where(u => u.RecipientID == _Account.UserId && !u.LinkURL.Contains("/manage/registrations"))
                                .OrderByDescending(n => n.Timestamp)
                                .FirstOrDefault();

            lblNearestActions.Text = notifications.Content;
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
        private void btnSideBar_Click(object sender, EventArgs e)
        {

        }
        private void bntAddNewTopic_Click(object sender, EventArgs e)
        {
            var newTopic = new Project_Detail_W_GV2_Detail(_context);
            newTopic.FormClosed += new FormClosedEventHandler(Lecturer_Dashboard_W_GV1_FormClosed);
            newTopic.ShowDialog();
        }
        private void Lecturer_Dashboard_W_GV1_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadSignedNotification();
            LoadNearestNotification();
            LoadTopicList();
        }
        private void pnlProjects_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new My_Topics_W_GV2(_context, _Account);
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new Lecture_Forms.Approve_Registrations_W_GV3(_context, _Account);
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
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            tmSideBar.Start();
        }

        private void llbToSign_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var myProject = new Lecture_Forms.Approve_Registrations_W_GV3(_context, _Account);
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
    }
}
