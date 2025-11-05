using BTN_QLDA_12_.Forms.Student_Forms;
using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.Student;
using BTN_QLDA_12_.Models.User_Role;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN_QLDA_12_.Forms.Lecture_Forms
{
    public partial class Approve_Registrations_W_GV3 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        List<Notifications> notifications;
        public Approve_Registrations_W_GV3(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            lblAccountName.Text = _Account.FullName;
            LoadRegistants();
        }
        private void LoadRegistants()
        {
            lvRequest.Items.Clear();
            notifications = new List<Notifications>();
            notifications = _context.Notifications
                                .Where(n => n.RecipientID == _Account.UserId && n.LinkURL.Contains("/manage/registrations"))
                                .ToList();
            foreach (Notifications notification in notifications)
            {
                string[] first = notification.Content.Split('(');
                string[] seccond = first[1].Split(')');
                string[] third = seccond[1].Split('"');
                ListViewItem item = new ListViewItem();
                item.Text = first[0];
                item.SubItems.Add(seccond[0]);
                item.SubItems.Add(third[1]);
                item.SubItems.Add(notification.Timestamp.ToString("dd/MM/yyyy"));
                lvRequest.Items.Add(item);
            }
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
        private void pnlProjects_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new My_Topics_W_GV2(_context, _Account);
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
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            tmSideBar.Start();
        }
        private void xemBảngĐiểmSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void UpdateTopic(int topicID, int studentID)
        {
            Topics topic = new Topics();
            int top = GetTopic(topicID);
            topic = _context.Topics.Where(t => t.TopicID == top).FirstOrDefault();
            topic.MaxStudents--;
            if (topic.MaxStudents == 0)
                topic.Status = "Đã đủ";
            _context.Topics.AddOrUpdate(topic);
            _context.SaveChanges();

            ProjectMembers pm = new ProjectMembers
            {
                ProjectID = topicID,
                StudentID = studentID,
                IsGroupLeader = false,
            };
            _context.ProjectMembers.Add(pm);
            _context.SaveChanges();

        }
        private int GetTopic(int projectID)
        {
            List<Projects> project = _context.Projects.ToList();
            foreach(var t in project) 
                if(t.ProjectID == projectID)
                    return t.TopicID;
            return 0;
        }
        private int GetTopicID(string topicName)
        {
            List<Topics> topic = _context.Topics.ToList();
            int topicID = 0;
            foreach(Topics t in topic) 
                if(t.Title == topicName)
                    topicID = t.TopicID;
            List<Projects> project = _context.Projects.ToList();
            foreach(var t in project) 
                if(t.TopicID == topicID)
                    return t.ProjectID;
            return 0;
        }
        private int GetStudentID(string code)
        {
            List<User> user = _context.users.Where(u => u.Role == RoleAccount.Student.ToString()).ToList();
            foreach (var u in user)
                if (u.UserCode == code)
                    return u.UserId;
            return 0;
        }
        private void DeleteNotification(ListViewItem item)
        {
            foreach (var n in notifications)
            {
                string[] first = n.Content.Split('(');
                string[] seccond = first[1].Split(')');
                string[] third = seccond[1].Split('"');
                if (first[0] == item.SubItems[0].Text &&
                    seccond[0] == item.SubItems[1].Text &&
                    third[1] == item.SubItems[2].Text)
                    _context.Notifications.Remove(n);
                _context.SaveChanges();
            }
        }
        private void duyệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lvRequest.SelectedItems.Count > 0)
            {
                ListViewItem item = lvRequest.SelectedItems[0];
                UpdateTopic(GetTopicID(item.SubItems[2].Text), GetStudentID(item.SubItems[1].Text));
                MessageBox.Show("Đã duyệt thành công sinh viên " + item.SubItems[0].Text + " vào đồ án " + item.SubItems[2].Text);
                DeleteNotification(item);
            }
        }
        private void từChốiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvRequest.SelectedItems.Count > 0)
            {
                ListViewItem item = lvRequest.SelectedItems[0];
                var refuseNotification = new Refuse_Notification_W_GV3_Detail(_context, item.SubItems[2].Text, GetStudentID(item.SubItems[1].Text), _Account);
                refuseNotification.ShowDialog();
                if(refuseNotification.DialogResult == DialogResult.OK)
                {
                    DeleteNotification(item);
                    LoadRegistants();
                }
            }
        }
    }
}
