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

namespace BTN_QLDA_12_.Forms.Lecture_Forms
{
    public partial class Project_Detail_W_GV2_Detail : Form
    {
        ProjectManagement _context;
        public Project_Detail_W_GV2_Detail(ProjectManagement context)
        {
            InitializeComponent();
            _context = context;
            LoadLecturer();
            LoadPeriod();
        }
        private void LoadLecturer()
        {
            List<User> users = _context.users
                    .Where(u => u.Role == RoleAccount.Lecturer.ToString())
                    .ToList();
            foreach (User user in users) 
                cbbLecturer.Items.Add(user.FullName);
        }
        private void LoadPeriod()
        {
            List<ProjectPeriods> users = _context.ProjectsPeriods
                    .ToList();
            foreach (var user in users) 
                cbbPeriod.Items.Add(user.Name);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private int GetLecturerID()
        {
            List<User> users = _context.users
                    .Where(u => u.Role == RoleAccount.Lecturer.ToString())
                    .ToList();
            foreach(User user in users) 
                if(user.FullName == cbbLecturer.Text)
                    return user.UserId;
            return 0;
        }
        private int GetPeriodID()
        {
            List<ProjectPeriods> users = _context.ProjectsPeriods
                   .ToList();
            foreach (var user in users)
                if (user.Name == cbbPeriod.Text)
                    return user.ProjectPeriodID;
            return 0;
        }
        private bool Check()
        {
            if (txtCondition.Text == string.Empty ||
                txtDetail.Text == string.Empty ||
                txtName.Text == string.Empty ||
                cbbPeriod.Text == string.Empty ||
                cbbLecturer.Text == string.Empty ||
                nupMaxStudent.Value == 0)
            {
                MessageBox.Show("Thông tin không phù hợp. Vui lòng kiểm tra lại");
                return false;
            }
            return true;
        }
        private void Save()
        {
            try
            {
                Topics topic = new Topics
                {
                    LecturerID = GetLecturerID(),
                    Title = txtName.Text,
                    ProjectPeriodID = GetPeriodID(),
                    Description = txtDetail.Text,
                    MaxStudents = (int)nupMaxStudent.Value,
                    Requirements = txtCondition.Text,
                    Status = "Còn trống"
                };
                _context.Topics.Add(topic);
                _context.SaveChanges(); 

                MessageBox.Show("Đã thêm mới đề tài thành công.");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                string errorMessage = "Lỗi xác thực dữ liệu:\n";

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += $" - Thuộc tính: '{validationError.PropertyName}', Lỗi: '{validationError.ErrorMessage}'\n";
                    }
                }

                MessageBox.Show(errorMessage, "Lỗi khi lưu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;
            Save();
        }
    }
}
