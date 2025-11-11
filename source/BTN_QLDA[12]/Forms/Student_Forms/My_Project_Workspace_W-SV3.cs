using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.Student;
using BTN_QLDA_12_.Models.User_Role;
using Microsoft.Office.Interop.Excel;
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
    public partial class My_Project_Workspace_W_SV3 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        List<ProjectMembers> pm;
        List<Topics> topic;
        List<Projects> project;
        List<ProjectPeriods> period;
        public My_Project_Workspace_W_SV3(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            lblName.Text = _Account.FullName;
            LoadTopics();
            LoadLatestProject();
        }
        private void LoadLatestProject()
        {
            foreach (var projectMem in pm)
            {
                List<string> list = new List<string>();
                foreach (var pro in project)
                    if (projectMem.ProjectID == pro.ProjectID)
                        foreach (var top in topic)
                            if (top.TopicID == pro.TopicID)
                                foreach (var periodMem in period)
                                    if (periodMem.ProjectPeriodID == top.ProjectPeriodID)
                                    {
                                        list.Add(top.Title);
                                        list.Add(top.Lecturer.FullName);
                                        list.Add(periodMem.GradingDeadline.ToString());
                                        CreatePanelProject(list);
                                    }
            }
        }
        private void CreatePanelProject(List<string> list)
        {
            Panel outsidepanel = new Panel();
            outsidepanel.Margin = new Padding(30, 20, 0, 20);
            outsidepanel.Size = new Size(860, 150);
            outsidepanel.BackColor = Color.Black;
            outsidepanel.BorderStyle = BorderStyle.FixedSingle;

            Panel insidePanel = new Panel();
            insidePanel.Location = new System.Drawing.Point(6, -11);
            insidePanel.BackColor = System.Drawing.Color.White;
            insidePanel.Size = new Size(1186, 247);

            System.Windows.Forms.Label tittle = new System.Windows.Forms.Label();
            tittle.Name = "lblTitle";
            tittle.Text = list[0];
            tittle.Location = new System.Drawing.Point(12, 26);
            tittle.Font = new System.Drawing.Font(new FontFamily("Roboto Medium"), (float)13.8, FontStyle.Bold);
            tittle.Size = new Size(1186, 30);

            System.Windows.Forms.Label TittleLecter = new System.Windows.Forms.Label();
            TittleLecter.Name = "lblTittleLecter";
            TittleLecter.Text = "GVHD: ";
            TittleLecter.Location = new System.Drawing.Point(13, 67);
            TittleLecter.Font = new System.Drawing.Font(new FontFamily("Roboto Medium"), (float)12, FontStyle.Bold);
            TittleLecter.Size = new Size(100, 30);

            System.Windows.Forms.Label TittleDeadline = new System.Windows.Forms.Label();
            TittleDeadline.Name = "lblTittleDeadline";
            TittleDeadline.Text = "Hạn nộp cuối kỳ: ";
            TittleDeadline.Location = new System.Drawing.Point(520, 67);
            TittleDeadline.Font = new System.Drawing.Font(new FontFamily("Roboto Medium"), (float)12, FontStyle.Bold);
            TittleDeadline.Size = new Size(130, 30);

            System.Windows.Forms.Label Lecter = new System.Windows.Forms.Label();
            Lecter.Name = "lblLecter";
            Lecter.Text = list[1];
            Lecter.Location = new System.Drawing.Point(110, 67);
            Lecter.ForeColor = Color.Gray;
            Lecter.Font = new System.Drawing.Font(new FontFamily("Roboto Medium"), (float)12, FontStyle.Regular);
            Lecter.Size = new Size(300, 30);

            System.Windows.Forms.Label deadline = new System.Windows.Forms.Label();
            deadline.Name = "lblDeadline";
            deadline.Text = list[2];
            deadline.Location = new System.Drawing.Point(600, 67);
            deadline.ForeColor = Color.Gray;
            deadline.Font = new System.Drawing.Font(new FontFamily("Roboto Medium"), (float)12, FontStyle.Regular);
            deadline.Size = new Size(400, 30);

            System.Windows.Forms.Button task = new System.Windows.Forms.Button();
            task.Name = "AddNewTask";
            task.Text = "Xem các task";
            task.Size = new Size(120, 28);
            task.Location = new System.Drawing.Point(580, 100);
            task.ForeColor = Color.White;
            task.BackColor = Color.FromArgb(0, 86, 179);
            task.FlatStyle = FlatStyle.Flat;
            task.Font = new System.Drawing.Font(new FontFamily("Roboto Medium"), (float)11, FontStyle.Bold);
            task.Click += new EventHandler(btnAddTask_Click);

            System.Windows.Forms.Button Report = new System.Windows.Forms.Button();
            Report.Name = "AddNewReport";
            Report.Text = "+ Thêm Report";
            Report.Size = new Size(120, 28);
            Report.Location = new System.Drawing.Point(720, 100);
            Report.ForeColor = Color.White;
            Report.BackColor = Color.FromArgb(220, 53, 69);
            Report.FlatStyle = FlatStyle.Flat;
            Report.Font = new System.Drawing.Font(new FontFamily("Roboto Medium"), (float)11, FontStyle.Bold);
            Report.Click += new EventHandler(btnAddFinalReport_Click);

            outsidepanel.Controls.Add(insidePanel);
            insidePanel.Controls.Add(tittle);
            insidePanel.Controls.Add(TittleLecter);
            insidePanel.Controls.Add(Lecter);
            insidePanel.Controls.Add(TittleDeadline);
            insidePanel.Controls.Add(deadline);
            insidePanel.Controls.Add(task);
            insidePanel.Controls.Add(Report);

            pnlRight.Controls.Add(outsidepanel);
        }
        private void LoadTopics()
        {
            pm = _context.ProjectMembers
                     .Where(p => p.StudentID == _Account.UserId)
                     .ToList();
            topic = _context.Topics.ToList();
            project = _context.Projects.ToList();
            period = _context.ProjectsPeriods.ToList();
            foreach(var projectMem in pm) 
                foreach(var pro in project)
                    if(projectMem.ProjectID == pro.ProjectID)
                        foreach(var top in topic)
                            if(top.TopicID == pro.TopicID)
                                foreach (var periodMem in period)
                                    if(periodMem.ProjectPeriodID == top.ProjectPeriodID)
                                    {
                                        ListViewItem item = new ListViewItem();
                                        item.Text = top.Title;
                                        item.SubItems.Add(periodMem.Name);
                                        item.SubItems.Add(top.MaxStudents.ToString());
                                        item.SubItems.Add(top.Description);
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
        private void pnlDashboard_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new Student_Dashboard_W_SV1(_context, _Account);
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
        private void pnlProjects_DoubleClick(object sender, EventArgs e)
        {
            var myProject = new Browse_Topics_W_SV2(_context, _Account);
            this.Hide();
            myProject.ShowDialog();
            this.Close();
        }
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
            Panel pn = clickedButton.Parent as Panel;
            System.Windows.Forms.Label titleLabel = pn.Controls
                                  .OfType<System.Windows.Forms.Label>()
                                  .FirstOrDefault(lbl => lbl.Name == "lblTitle");
            if (titleLabel != null)
            {
                //Test this again
                Topics topic = _context.Topics.Where(t => t.Title == titleLabel.Text).OrderBy(p => p.TopicID).FirstOrDefault();
                Projects project = _context.Projects.Where(t => t.TopicID == topic.TopicID).FirstOrDefault();
                var projectDetail = new Project_Task_Detail_W_SV3_Detail(_context, project, _Account);
                projectDetail.Show();
            }
        }
        private void btnAddFinalReport_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
            Panel pn = clickedButton.Parent as Panel;
            System.Windows.Forms.Label titleLabel = pn.Controls
                                  .OfType<System.Windows.Forms.Label>()
                                  .FirstOrDefault(lbl => lbl.Name == "lblTitle");
            if (titleLabel != null)
            {
                Topics topic = _context.Topics.Where(t => t.Title == titleLabel.Text).OrderBy(p => p.TopicID).FirstOrDefault();
                Projects project = _context.Projects.Where(t => t.TopicID == topic.TopicID).FirstOrDefault();
                var report = new My_Project_Detail_W_SV3_Detail(_context, _Account, project);
                report.Show();
            }
        }

        private void panel4_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muón đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                System.Windows.Forms.Application.Restart();
                this.Close();
            }
        }
    }
}
