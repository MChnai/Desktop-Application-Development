using BTN_QLDA_12_.Models;
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
using System.Xml;

namespace BTN_QLDA_12_.Forms.Lecture_Forms
{
    public partial class Project_Students_W_GV2_Detail : Form
    {
        ProjectManagement _context;
        Projects project;
        UsersModel _Account;
        public Project_Students_W_GV2_Detail(ProjectManagement context, Projects project, UsersModel users)
        {
            InitializeComponent();
            _context = context;
            _Account = users;
            this.project = project;
            LoadStudentList();
        }

        private void LoadStudentList()
        {
            List<ProjectMembers> members = _context.ProjectMembers
                                                .Where(m => m.ProjectID == project.ProjectID)
                                                .ToList();
            if(members != null)
                lblList.Text = string.Empty;
            foreach (ProjectMembers member in members)
            {
                User user = _context.users
                                .Where(u => u.UserId == member.StudentID && u.Role == RoleAccount.Student.ToString())
                                .FirstOrDefault();
                ListViewItem item = new ListViewItem();
                item.Text = user.FullName;
                item.SubItems.Add(user.UserCode);
                item.SubItems.Add(user.ClassName);
                item.SubItems.Add(user.Email);
                lblList.Items.Add(item);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
