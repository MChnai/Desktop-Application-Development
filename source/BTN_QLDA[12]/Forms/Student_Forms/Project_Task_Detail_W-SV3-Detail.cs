using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.Student;
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

namespace BTN_QLDA_12_.Forms.Student_Forms
{
    public partial class Project_Task_Detail_W_SV3_Detail : Form
    {
        ProjectManagement _context;
        Projects _project;
        UsersModel user;
        public Project_Task_Detail_W_SV3_Detail(ProjectManagement context, Projects account, UsersModel users)
        {
            InitializeComponent();
            _context = context;
            _project = account;
            user = users;
            LoadTask();
        }
        private void LoadTask()
        {
            List<ProjectTasks> tasks = _context.ProjectTasks
                                            .Where(t => t.ProjectID == _project.ProjectID)
                                            .ToList();
            Topics tp = _context.Topics
                            .Where(t => t.TopicID == _project.TopicID)
                            .FirstOrDefault();
            foreach (var task in tasks)
            {
                TextBox tb = new TextBox();
                tb.Multiline = true;
                tb.Text = task.TaskName;
                tb.Font = new System.Drawing.Font("Roboto Condensed Medium", 12, FontStyle.Regular);
                tb.Size = new Size(700, 20);
                tb.BorderStyle = BorderStyle.None;

                pnlLatestActions.Controls.Add(tb);

                FlowLayoutPanel pn = new FlowLayoutPanel();
                pn.BorderStyle = BorderStyle.None;
                pn.BackColor = System.Drawing.Color.Black;
                pn.Size = new Size(830, 1);

                pnlLatestActions.Controls.Add(pn);
            }

            label8.Text = tp.Title;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           if(lblName.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa điền thông tin task");
                return;
            }
            ProjectTasks task = new ProjectTasks
            {
                ProjectID = _project.ProjectID,
                AssignedTo = null,
                TaskName = lblName.Text,
                CreatorID = user.UserId,
                DueDate = DateTime.Now,
                IsCompleted = false,
            };
            _context.ProjectTasks.Add(task);
            _context.SaveChanges();
            LoadTask();
        }
    }
}
