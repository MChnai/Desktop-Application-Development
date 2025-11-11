using BTN_QLDA_12_.Models;
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
    public partial class Project_DetailW_SV2_Detail : Form
    {
        ProjectManagement _context;
        Topics _Account;
        public Project_DetailW_SV2_Detail(ProjectManagement context, Topics account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            LoadInformation();
            label8.Text = _Account.Title;
        }
        private void LoadInformation()
        {
            User lecture = _context.users.Where(u => u.UserId == _Account.LecturerID).FirstOrDefault();
            Projects project = _context.Projects.Where(p => p.TopicID == _Account.TopicID).FirstOrDefault();
            List<ProjectMembers> pm = new List<ProjectMembers>();
            if (project != null)
                pm = _context.ProjectMembers.Where(p => p.ProjectID == project.ProjectID).ToList();
            lblLectureName.Text = lecture.FullName;
            lblMaxStudent.Text = pm.Count() + "/" + _Account.MaxStudents.ToString();
            lblDetail.Text = _Account.Description;
            lblCondition.Text = _Account.Requirements;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
