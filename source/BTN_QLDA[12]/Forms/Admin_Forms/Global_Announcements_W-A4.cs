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
    public partial class Global_Announcements_W_A4 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        public Global_Announcements_W_A4(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            lblAccountName.Text = _Account.FullName;
        }
        private void ProcessAnnouncement(bool isScheduled)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Tiêu đề không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(rtxContent.Text))
            {
                MessageBox.Show("Nội dung không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = txtTitle.Text.Trim();
            string contentRtf = rtxContent.Text; 
            string type = cboType.SelectedItem.ToString();
            string roleKey = cboTargetGroup.Text;

            string targetRoleDb = "All"; 
            string targetGroupDb = null; 
            if (roleKey == "Lecturer")
            {
                targetRoleDb = "Lecturer";
            }
            else if (roleKey == "Student")
            {
                targetRoleDb = "Student";
            }           

            try
            {
                var announcement = new Announcements
                {
                    SenderID = _Account.UserId,
                    Title = title,
                    Content = contentRtf, 
                    Type = type,
                    TargetRole = targetRoleDb,
                    TargetGroup = targetGroupDb,
                    ScheduledTime = isScheduled ? dtpScheduleTime.Value : (DateTime?)null,
                    SentTime = (DateTime)(isScheduled ? (DateTime?)null : DateTime.Now)
                };

                _context.Announcements.Add(announcement);
                _context.SaveChanges();
                if (!isScheduled)
                {
                    CreateNotifications(announcement, targetRoleDb, targetGroupDb);
                }

                MessageBox.Show(isScheduled ? "Đã lên lịch thành công!" : "Đã gửi thông báo thành công!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông báo: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateNotifications(Announcements announcement, string role, string groupName)
        {
            IQueryable<User> query = _context.users
                                             .Include("DepartmentInof")
                                             .Include("classInfo");

            if (role == "Lecturer")
            {
                query = query.Where(u => u.Role == "Lecturer");
                if (groupName != null)
                {
                    query = query.Where(u => u.Department == groupName);
                }
            }
            else if (role == "Student")
            {
                query = query.Where(u => u.Role == "Student");
                if (groupName != null)
                {
                    query = query.Where(u => u.ClassName == groupName);
                }
            }

            var recipients = query.ToList();
            if (!recipients.Any()) return;

            string content = $"Thông báo {announcement.Type}: {announcement.Title}";
            string link = $"/Announcements/{announcement.AnnouncementID}"; // Link ảo
            var timestamp = DateTime.Now;

            var notifications = new List<Notifications>();
            foreach (var user in recipients)
            {
                notifications.Add(new Notifications
                {
                    RecipientID = user.UserId,
                    Content = content,
                    LinkURL = link,
                    IsRead = false,
                    Timestamp = timestamp
                });
            }

            _context.Notifications.AddRange(notifications);
            _context.SaveChanges();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProcessAnnouncement(isScheduled: false);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            dtpScheduleTime.Visible = true;
            dtpScheduleTime.Value = DateTime.Now.AddHours(1);
        }
        //Open other forms
        private void pnlDashboard_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.DashboardAdmin_W_A1(_context, _Account);
            PeriodManagement.ShowDialog();
            this.Close();
        }
        private void pnlProjects_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.ProjectPeriodManagement_W_A2(_context, _Account);
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
        private void panel3_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.Reporting_Analytics_W_A5(_context, _Account);
            PeriodManagement.ShowDialog();
            this.Close();
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
        //open side bar
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            tmSideBar.Start();
        }
    }
}
