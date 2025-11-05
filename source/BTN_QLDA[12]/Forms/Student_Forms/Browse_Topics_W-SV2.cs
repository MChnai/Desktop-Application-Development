using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.User_Role;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
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
                if (pnSideBar.Width == pnSideBar.Size.Width)
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
            topic.BackColor = Color.White;
            topic.Size = new System.Drawing.Size(390, 200);
            topic.BorderStyle = BorderStyle.FixedSingle;

            TextBox Name = new TextBox();
            Name.Text = topicInfo[0];
            Name.Location = new Point(19, 8);
            Name.Size = new System.Drawing.Size(350, 100);
            Name.ForeColor = Color.FromArgb(0, 123, 255);
            Name.BackColor = Color.White;
            Name.Font = new Font(new FontFamily("Roboto Medium"), (float)13.8, FontStyle.Bold);
            Name.BorderStyle = BorderStyle.None;

            TextBox lecture = new TextBox();
            lecture.Text = topicInfo[1];
            lecture.Location = new Point(20, 43);
            lecture.Size = new System.Drawing.Size(350, 100);
            lecture.ForeColor = Color.Black;
            lecture.BackColor = Color.White;
            lecture.Font = new Font(new FontFamily("Roboto Medium"), (float)11, FontStyle.Bold);
            lecture.BorderStyle = BorderStyle.None;

            TextBox description = new TextBox();
            description.Text = topicInfo[2];
            description.Location = new Point(20, 74);
            description.Size = new System.Drawing.Size(350, 100);
            description.ForeColor = Color.Gray;
            description.BackColor = Color.White;
            description.Font = new Font(new FontFamily("Roboto Medium"), (float)10, FontStyle.Bold);
            description.BorderStyle = BorderStyle.None;

            Button detail = new Button();
            detail.Text = "Xem chi tiết";
            detail.FlatStyle = FlatStyle.Flat;
            detail.BackColor = Color.FromArgb(224, 224, 224);
            detail.Size = new System.Drawing.Size(100, 30);
            detail.Location = new Point(180, 195);
            detail.Font = new Font(new FontFamily("Roboto Medium"), (float)10, FontStyle.Bold);
            detail.Click += new EventHandler(button3_Click);

            Button sign = new Button();
            sign.Text = "Đăng ký";
            sign.FlatStyle = FlatStyle.Flat;
            sign.BackColor = Color.FromArgb(40, 167, 69);
            sign.ForeColor = Color.White;
            sign.Size = new System.Drawing.Size(75, 30);
            sign.Location = new Point(290, 195);
            sign.Font = new Font(new FontFamily("Roboto Medium"), (float)10, FontStyle.Bold);

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
            Panel selectedPanel = panel1 as Panel;
        }
    }
}
