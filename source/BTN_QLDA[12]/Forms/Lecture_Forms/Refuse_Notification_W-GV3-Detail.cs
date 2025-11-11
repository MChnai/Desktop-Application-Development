using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.User_Role;
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

namespace BTN_QLDA_12_.Forms.Lecture_Forms
{
    public partial class Refuse_Notification_W_GV3_Detail : Form
    {
        ProjectManagement _context;
        private string topic;
        private int StudentID;
        private User user;
        UsersModel _Account;
        public Refuse_Notification_W_GV3_Detail(ProjectManagement context, string topic, int studentID, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            this.topic = topic;
            StudentID = studentID;
            _Account = account;
        }
        private User GetStudent()
        {
            List<User> users = _context.users.Where(u => u.Role == RoleAccount.Student.ToString()).ToList();
            foreach(var  user in users) 
                if(user.UserId == StudentID)
                    return user;
            return null;
        }
        private void ProcessAnnouncement()
        {
            user = GetStudent();
            if(user == null)
            {
                MessageBox.Show("KHông tìm thấy sinh viên");
                return;
            }  
            string title = "Thông báo từ chối đề tài " + topic;
            string contentRtf = txtReason.Text;
            try
            {
                var announcement = new Announcements
                {
                    SenderID = _Account.UserId,
                    Title = title,
                    Content = contentRtf,
                    Type = "Chung",
                    TargetRole = "Student",
                    TargetGroup = user.UserId.ToString(),
                    ScheduledTime = DateTime.Now,
                    SentTime = DateTime.Now
                };

                _context.Announcements.Add(announcement);
                _context.SaveChanges();
                CreateNotifications(announcement);
                MessageBox.Show("Đã thông báo cho sinh viên");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông báo: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateNotifications(Announcements announcement)
        {
            var recipients = _context.users.Where(u => u.UserId == user.UserId);
            if (!recipients.Any()) return;

            string content = $"Thông báo {announcement.Type}: {announcement.Title}";
            string link = $"/Announcements/{announcement.AnnouncementID}";
            var timestamp = DateTime.Now;

            var notifications = new Notifications
                {
                    RecipientID = user.UserId,
                    Content = content,
                    LinkURL = link,
                    IsRead = false,
                    Timestamp = timestamp
                };

            _context.Notifications.Add(notifications);
            _context.SaveChanges();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(txtReason.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập lý do.");
                return;
            }
            ProcessAnnouncement();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
