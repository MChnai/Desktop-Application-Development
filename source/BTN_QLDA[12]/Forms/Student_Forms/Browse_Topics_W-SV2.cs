using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.User_Role;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
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

namespace BTN_QLDA_12_.Forms.Student_Forms
{
    public partial class Browse_Topics_W_SV2 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        public Browse_Topics_W_SV2(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            lblName.Text = _Account.FullName;
            LoadLecturecbb();
            LoadPeriodcbb();
        }
        private void LoadPeriodcbb()
        {
            List<ProjectPeriods> lecture = _context.ProjectsPeriods.ToList();
            foreach(var l  in lecture)
                cbbPeriod.Items.Add(l.Name);
        }
        private void LoadLecturecbb()
        {
            List<User> lecture = _context.users.Where(u => u.Role == RoleAccount.Lecturer.ToString()).ToList();
            foreach(var l  in lecture)
                cbbLecture.Items.Add(l.FullName);
        }
        private void tmSideBar_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                pnSideBar.Width -= 10;//decrease 10 pixcel each tick of time        
                var X = pictureBox11.Location.X - 10;
                pictureBox11.Location = new System.Drawing.Point(X, pictureBox11.Location.Y);
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
                pictureBox11.Location = new System.Drawing.Point(X, pictureBox11.Location.Y);
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
        private void CreatePanelTopic(List<string> topicInfo)
        {
            FlowLayoutPanel topic = new FlowLayoutPanel();
            topic.Margin = new Padding(40, 20, 0, 20);
            topic.BackColor = System.Drawing.Color.White;
            topic.Size = new System.Drawing.Size(390, 150);
            topic.BorderStyle = BorderStyle.FixedSingle;

            TextBox Name = new TextBox();
            Name.Text = topicInfo[0];
            Name.Location = new System.Drawing.Point(19, 8);
            Name.Size = new System.Drawing.Size(350, 100);
            Name.ForeColor = System.Drawing.Color.FromArgb(0, 123, 255);
            Name.BackColor = System.Drawing.Color.White;
            Name.Font = new System.Drawing.Font(new System.Drawing.FontFamily("Roboto Medium"), (float)13.8, FontStyle.Bold);
            Name.BorderStyle = BorderStyle.None;
            Name.Name = "lblTopicTitle";

            TextBox lecture = new TextBox();
            lecture.Text = topicInfo[1];
            lecture.Location = new System.Drawing.Point(20, 43);
            lecture.Size = new System.Drawing.Size(350, 100);
            lecture.ForeColor = System.Drawing.Color.Black;
            lecture.BackColor = System.Drawing.Color.White;
            lecture.Font = new System.Drawing.Font(new System.Drawing.FontFamily("Roboto Medium"), (float)11, FontStyle.Bold);
            lecture.BorderStyle = BorderStyle.None;

            TextBox description = new TextBox();
            description.Text = topicInfo[2];
            description.Location = new System.Drawing.Point(20, 74);
            description.Size = new System.Drawing.Size(350, 100);
            description.ForeColor = System.Drawing.Color.Gray;
            description.BackColor = System.Drawing.Color.White;
            description.Font = new System.Drawing.Font(new System.Drawing.FontFamily("Roboto Medium"), (float)10, FontStyle.Bold);
            description.BorderStyle = BorderStyle.None;

            Button detail = new Button();
            detail.Text = "Xem chi tiết";
            detail.FlatStyle = FlatStyle.Flat;
            detail.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            detail.Size = new System.Drawing.Size(100, 30);
            detail.Location = new System.Drawing.Point(180, 195);
            detail.Margin = new Padding(200, 4, 0, 0);
            detail.Font = new System.Drawing.Font(new System.Drawing.FontFamily("Roboto Medium"), (float)10, FontStyle.Bold);
            detail.Click += new EventHandler(button3_Click);

            Button sign = new Button();
            sign.Text = "Đăng ký";
            sign.FlatStyle = FlatStyle.Flat;
            sign.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            sign.ForeColor = System.Drawing.Color.White;
            sign.Size = new System.Drawing.Size(75, 30);
            sign.Location = new System.Drawing.Point(290, 195);
            sign.Font = new System.Drawing.Font(new System.Drawing.FontFamily("Roboto Medium"), (float)10, FontStyle.Bold);
            sign.Click += new EventHandler(button4_Click);

            topic.Controls.Add(Name);
            topic.Controls.Add(lecture);
            topic.Controls.Add(description);
            topic.Controls.Add(detail);
            topic.Controls.Add(sign);

            pnlRight.Controls.Add(topic);

        }
        private void ClearPanel()
        {
            List<FlowLayoutPanel> panelsToRemove = pnlRight.Controls
                                                  .OfType<FlowLayoutPanel>()
                                                  .ToList();
            foreach (FlowLayoutPanel panel in panelsToRemove)
            {
                pnlRight.Controls.Remove(panel);
                panel.Dispose();
            }
        }
        private List<List<string>> Filter()
        {
            ClearPanel();
            List<List<string>> result = new List<List<string>>();
            List<string> filters = new List<string>();
            List<Topics> topics = _context.Topics.ToList();
            List<ProjectPeriods>period = _context.ProjectsPeriods.ToList();
            List<User> lectures = _context.users.Where(u => u.Role == RoleAccount.Lecturer.ToString()).ToList();
            foreach (var topic in topics)
            {
                filters = new List<string>();
                filters.Add(topic.Title);
                foreach (var l in lectures)
                    if (l.UserId == topic.LecturerID)
                        filters.Add(l.FullName);
                filters.Add(topic.Description);
                filters.Add(topic.Status);
                foreach(var p in period)
                    if(p.ProjectPeriodID == topic.ProjectPeriodID)
                        filters.Add(p.Name);
                result.Add(filters);
            }
            if(cbbLecture.Text != string.Empty)
                result = result
                    .Where(list => list[1] == cbbLecture.Text)
                    .ToList();
            if(txtSearch.Text != string.Empty)
                result = result
                   .Where(list => list[0].Contains(txtSearch.Text))
                   .ToList();
            if(chkStatus.Checked)
                result = result
                   .Where(list => list[3] == "Còn trống")
                   .ToList();
            if(cbbPeriod.Text != string.Empty)
                result = result
                   .Where(list => list[4] == cbbPeriod.Text)
                   .ToList();
            return result;

        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            List<List<string>> item = Filter();
            foreach(var topic in item)
                CreatePanelTopic(topic);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Panel pn = clickedButton.Parent as Panel;
            TextBox titleLabel = pn.Controls
                                  .OfType<TextBox>()
                                  .FirstOrDefault(lbl => lbl.Name == "lblTopicTitle");
            if (titleLabel != null)
            {
                Topics topic = _context.Topics.Where(t => t.Title == titleLabel.Text).FirstOrDefault(); 
                var projectDetail = new Project_DetailW_SV2_Detail(_context, topic);
                projectDetail.Show();
            }
        }
        private void CreateNotifications(Announcements announcement, User lecturer)
        {
            var recipients = _context.users.Where(u => u.UserId == lecturer.UserId);
            if (!recipients.Any()) return;

            string content = announcement.Content;
            List<Notifications> list = _context.Notifications
                                        .Where(n => n.LinkURL.Contains("/manage/registrations/"))
                                        .OrderByDescending(no => no.LinkURL)
                                        .ToList();
            int id = 1;
            foreach (var notification in list)
                if (notification.LinkURL == ("/manage/registrations/") + id)
                    id ++;
            string link = $"/manage/registrations/" + id;
            var timestamp = DateTime.Now;

            var notifications = new Notifications
            {
                RecipientID = lecturer.UserId,
                Content = content,
                LinkURL = link,
                IsRead = false,
                Timestamp = timestamp
            };

            _context.Notifications.Add(notifications);
            _context.SaveChanges();
        }
        private User GetLecturer(int lecturerID)
        {
            List<User> users = _context.users.Where(u => u.Role == RoleAccount.Lecturer.ToString()).ToList();
            foreach (var user in users)
                if (user.UserId == lecturerID)
                    return user;
            return null;
        }
        private void ProcessAnnouncement(Topics topics)
        {
            User user = GetLecturer(topics.LecturerID);
            if (user == null)
            {
                MessageBox.Show("Không tìm thấy giảng viên");
                return;
            }
            string title = "Thông báo đăng ký đề tài của sinh viên " + _Account.UserCode;
            string contentRtf = _Account.FullName + " (" + _Account.UserCode + ") vừa đăng ký đề tài \"" + topics.Title + "\" của bạn";
            try
            {
                var announcement = new Announcements
                {
                    SenderID = _Account.UserId,
                    Title = title,
                    Content = contentRtf,
                    Type = "Chung",
                    TargetRole = "Lecturer",
                    TargetGroup = user.UserId.ToString(),
                    ScheduledTime = DateTime.Now,
                    SentTime = DateTime.Now
                };

                _context.Announcements.Add(announcement);
                _context.SaveChanges();
                CreateNotifications(announcement,user);
                MessageBox.Show("Đã thông báo cho giảng viên");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông báo: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng ký đề tài này?", "Xác nhận", MessageBoxButtons.OK);
            if(result == DialogResult.OK)
            {
                Button clickedButton = (Button)sender;
                Panel pn = clickedButton.Parent as Panel;
                TextBox titleLabel = pn.Controls
                                      .OfType<TextBox>()
                                      .FirstOrDefault(lbl => lbl.Name == "lblTopicTitle");
                if (titleLabel != null)
                {
                    Topics topic = _context.Topics.Where(t => t.Title == titleLabel.Text).FirstOrDefault();
                    ProcessAnnouncement(topic);
                }
            }
        }
        //open other forms
        private void pnlDashboard_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new Student_Dashboard_W_SV1(_context, _Account);
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new My_Project_Workspace_W_SV3(_context, _Account);
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muón đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                Application.Restart();
                this.Close();
            }
        }
    }
}
