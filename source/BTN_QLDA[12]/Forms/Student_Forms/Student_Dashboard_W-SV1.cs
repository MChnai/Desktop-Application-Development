using BTN_QLDA_12_.Forms.Lecture_Forms;
using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.Student;
using BTN_QLDA_12_.Models.User_Role;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN_QLDA_12_.Forms.Student_Forms
{
    public partial class Student_Dashboard_W_SV1 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        public Student_Dashboard_W_SV1(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            lblName.Text = _Account.FullName;
            lblGreeting.Text = "Chào mừng, " + _Account.FullName;
            LoadTopicList();
            LoadNearestNotification();
        }
        private void LoadNearestNotification()
        {
            Notifications notifications = new Notifications();
            notifications = _context.Notifications
                                .Where(u => u.RecipientID == _Account.UserId )
                                .OrderByDescending(n => n.Timestamp)
                                .FirstOrDefault();

            lblNearestActions.Text = notifications.Content;
        }
        public List<string> GetTopicsByStudentIDWithInclude(int studentId)
        {
            try
            {
                List<string> result = new List<string>();
                List<ProjectMembers> pm = _context.ProjectMembers
                                            .Where(stu => stu.StudentID == studentId).ToList();
                List<Projects> p = _context.Projects.ToList();
                List<Topics> topic = _context.Topics.ToList();
                List<ProjectPeriods> projectperiod = _context.ProjectsPeriods.ToList();
                List<User> lectures = _context.users.Where(u => u.Role == RoleAccount.Lecturer.ToString()).ToList();
                foreach (var member in pm)
                    foreach (var project in p)
                        if (member.ProjectID == project.ProjectID)
                            foreach (var top in topic)
                                if (top.TopicID == project.TopicID)
                                    foreach (var period in projectperiod)
                                        if (period.ProjectPeriodID == top.ProjectPeriodID)
                                            foreach (var u in lectures)
                                                if (top.LecturerID == u.UserId)
                                                    result.Add(top.Title + "," +
                                                                period.Name + "," +
                                                                u.FullName + "," +
                                                                top.Description);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving topics for StudentID {studentId} with Include: {ex.Message}");
                return new List<string>();
            }
        }
        private void LoadTopicList()
        {
            lvTopics.Items.Clear();
            List<string> topics = GetTopicsByStudentIDWithInclude(_Account.UserId);
            foreach (var topic in topics)
            {
                ListViewItem item = new ListViewItem();
                string[] list = topic.Split(',');
                item.Text = list[0];
                item.SubItems.Add(list[1]);
                item.SubItems.Add(list[2]);
                item.SubItems.Add(list[3]);
                lvTopics.Items.Add(item);
            }
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            tmSideBar.Start();
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
        private void pnlProjects_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new Browse_Topics_W_SV2(_context, _Account);
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new My_Project_Workspace_W_SV3();
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
    }
}
