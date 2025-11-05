using BTN_QLDA_12_.Models;
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
    public partial class Lecture_Detail_W_A3_Detail : Form
    {
        ProjectManagement _context;
        public Lecture_Detail_W_A3_Detail(ProjectManagement context)
        {
            InitializeComponent();
            _context = context;
            LoadCbbDepartment();
            LoadClass();
        }
        public Lecture_Detail_W_A3_Detail(ProjectManagement context, string _role)
        {
            InitializeComponent();
            _context = context;
            LoadCbbDepartment();
            LoadClass();
            if(_role != null)
                cbbRole.Text = _role;
        }
        private void LoadCbbDepartment()
        {
            List<Department> departments = new List<Department>();
            departments = _context.department.ToList();
            foreach(Department department in departments) 
                cbbDepartment.Items.Add(department.Name);
        }
        private void LoadClass()
        {
            List<Class> classes = new List<Class>();
            classes = _context.classes.ToList();
            foreach(var c in classes)
                cbbClass.Items.Add(c.Name);
        }
        private string NewUserCode()
        {
            List<User> users = new List<User>();
            users = _context.users
                .Where(u => u.Role == cbbRole.Text)
                .ToList();

            int id = 1;
            if (cbbRole.Text == RoleAccount.Admin.ToString())
            {                
                foreach (User user in users)
                    if (user.UserCode == "admin" + id)
                        id++;
                return "admin" + id;
            }
            else if (cbbRole.Text == RoleAccount.Lecturer.ToString())
            {
                foreach (User user in users)
                    if (user.UserCode == "gv00" + id)
                        id++;
                return "GV00" + id;
            }
            foreach (User user in users)
                if (user.UserCode == "SV00" + id)
                    id++;
            return "SV00" + id;

        }
        private void SaveNewUser()
        {
            string ID = txtID.Text;
            string name = txtName.Text;
            string mail = txtMail.Text;
            string role = cbbRole.Text;
            string department;
            if (cbbDepartment.Text != string.Empty)
                department = cbbDepartment.Text;
            else
                department = null;
            string className;
            if(cbbClass.Text != string.Empty)
                className = cbbClass.Text;
            else
                className = null;
            string password = "123";
            string status = StatusType.Active.ToString();

            var user = new User
            {
                FullName = name,
                Email = mail,
                Role = role,
                Department = department,
                ClassName = className,
                PasswordHash = password,
                Status = status,
                UserCode = ID
,            };

            _context.users.Add(user);
            _context.SaveChanges();

            MessageBox.Show("Đã thêm mới người dùng thành công");
        }
        private bool checkInfo()
        {
            if (cbbRole.Text == RoleAccount.Student.ToString())
                if (txtID.Text == string.Empty ||
                    txtName.Text == string.Empty ||
                    txtMail.Text == string.Empty ||
                    cbbRole.Text == string.Empty ||
                    cbbDepartment.Text == string.Empty ||
                    cbbClass.Text == string.Empty)
                {
                    MessageBox.Show("Thông tin không hợp lệ");
                    return false;
                }
            else if(cbbRole.Text == RoleAccount.Lecturer.ToString())
                    if (txtID.Text == string.Empty ||
                   txtName.Text == string.Empty ||
                   txtMail.Text == string.Empty ||
                   cbbRole.Text == string.Empty ||
                   cbbDepartment.Text == string.Empty)
                    {
                        MessageBox.Show("Thông tin không hợp lệ");
                        return false;
                    }
            else
                    if (txtID.Text == string.Empty ||
                    txtName.Text == string.Empty ||
                    txtMail.Text == string.Empty ||
                    cbbRole.Text == string.Empty)
                    {
                        MessageBox.Show("Thông tin không hợp lệ");
                        return false;
                    }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkInfo())
                return;
            SaveNewUser();
        }
        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtID.Text = NewUserCode();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
