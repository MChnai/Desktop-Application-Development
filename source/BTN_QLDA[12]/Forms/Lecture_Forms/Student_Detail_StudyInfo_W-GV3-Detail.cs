using BTN_QLDA_12_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN_QLDA_12_.Forms.Lecture_Forms
{
    public partial class Student_Detail_StudyInfo_W_GV3_Detail : Form
    {
        ProjectManagement _context;
        User student;
        public Student_Detail_StudyInfo_W_GV3_Detail(ProjectManagement context, User stu)
        {
            InitializeComponent();
            student = stu;
            _context = context;
            LoadStuInfo();
        }
        private void LoadStuInfo()
        {
            lblStu.Text = student.FullName;
            lblGPA.Text += student.GPA;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
