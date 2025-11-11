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
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTN_QLDA_12_.Forms
{
    public partial class User_Management_W_A3 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        List<User> userList;
        List<User> studentList;
        public User_Management_W_A3(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            lblAccountName.Text = _Account.FullName;
            userList = new List<User>();
            studentList = new List<User>();
            LoadList();
            Display(userList);
        }

        private void LoadList()
        {
            userList = _context.users
                            .Where(u => u.Role == RoleAccount.Lecturer.ToString())
                            .ToList();
            studentList = _context.users
                            .Where(u => u.Role == RoleAccount.Student.ToString())
                            .ToList();
        }
        private void Display(List<User> users)
        {
            lvLecturerStudent.Items.Clear();
            if (users.Count > 0)
                if (users[0].Role == RoleAccount.Lecturer.ToString())
                    foreach (var user in users)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = user.FullName;
                        item.SubItems.Add(user.Email);
                        item.SubItems.Add(user.Department);
                        lvLecturerStudent.Items.Add(item);
                    }
                else
                    foreach (var user in users)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = user.FullName;
                        item.SubItems.Add(user.Email);
                        item.SubItems.Add(user.Department);
                        item.SubItems.Add(user.ClassName);
                        lvLecturerStudent.Items.Add(item);
                    }
        }
        private List<User> Find()
        {
            List<User> result = new List<User>();
            if (lblLecturer.ForeColor == Color.RoyalBlue)
                foreach (var user in userList)
                    if (user.FullName.Contains(txtSearch.Text) ||
                        user.Email.Contains(txtSearch.Text) ||
                        user.Department.Contains(txtSearch.Text))
                        result.Add(user);
            if (lblStudent.ForeColor == Color.RoyalBlue)
                foreach (var user in studentList)
                    if (user.FullName.Contains(txtSearch.Text) ||
                        user.Email.Contains(txtSearch.Text) ||
                        user.Department.Contains(txtSearch.Text) ||
                        user.ClassName.Contains(txtSearch.Text))
                        result.Add(user);
            return result;
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
                Display(Find());
            else if (lblLecturer.ForeColor == Color.RoyalBlue)
                Display(userList);
            else
                Display(studentList);
        }
        private void lblStudent_DoubleClick(object sender, EventArgs e)
        {
            lblLecturer.ForeColor = Color.Gray;
            lblStudent.ForeColor = Color.RoyalBlue;
            pnlLecture.BackColor = Color.Gray;
            pnlStudent.BackColor = Color.RoyalBlue;

            Display(studentList);
            lblLecturerList.Text = "Danh sách sinh viên";
            btnAdd1.Text = "+ Thêm 1 sinh viên";
        }
        private void lblLecturer_DoubleClick(object sender, EventArgs e)
        {
            lblStudent.ForeColor = Color.Gray;
            lblLecturer.ForeColor = Color.RoyalBlue;
            pnlStudent.BackColor = Color.Gray;
            pnlLecture.BackColor = Color.RoyalBlue;

            Display(userList);
            lblLecturerList.Text = "Danh sách giảng viên";
            btnAdd1.Text = "+ Thêm 1 giảng viên";
        }
        private void tmSideBar_Tick_1(object sender, EventArgs e)
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
        private void btnSideBar_Click(object sender, EventArgs e)
        {
            tmSideBar.Start();
        }
        private void btnAdd1_Click(object sender, EventArgs e)
        {
            Forms.Lecture_Detail_W_A3_Detail userManagement;
            if(lblLecturer.ForeColor == Color.RoyalBlue)
                userManagement = new Forms.Lecture_Detail_W_A3_Detail(_context, RoleAccount.Lecturer.ToString());
            else
                userManagement = new Forms.Lecture_Detail_W_A3_Detail(_context, RoleAccount.Student.ToString());
            userManagement.FormClosed += new FormClosedEventHandler(User_Management_W_A3_FormClosed);
            userManagement.ShowDialog();
        }
        private void User_Management_W_A3_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadList();
            if (lblLecturer.ForeColor == Color.RoyalBlue)
                Display(userList);
            else
                Display(studentList);
        }

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
        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.Global_Announcements_W_A4(_context, _Account);
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
        private string NewUserCode(string cbbRole)
        {
            List<User> users = new List<User>();
            users = _context.users
                .Where(u => u.Role == cbbRole)
                .ToList();

            int id = 1;
            if (cbbRole == RoleAccount.Admin.ToString())
            {
                foreach (User user in users)
                    if (user.UserCode == "admin" + id)
                        id++;
                return "admin" + id;
            }
            else if (cbbRole == RoleAccount.Lecturer.ToString())
            {
                foreach (User user in users)
                    if (user.UserCode == "gv00" + id || user.UserCode == "GV00" + id)
                        id++;
                return "GV00" + id;
            }
            foreach (User user in users)
                if (user.UserCode == "SV00" + id)
                    id++;
            return "SV00" + id;

        }
        private void SaveNewUser(User u)
        {
            string ID = u.UserCode;
            string name = u.FullName;
            string mail = u.Email;
            string role = u.Role;
            string department;
            if (u.Department != string.Empty)
                department = u.Department;
            else
                department = null;
            string className;
            if (u.ClassName != string.Empty)
                className = u.ClassName;
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
,
            };

            _context.users.Add(user);
            _context.SaveChanges();
        }
        private string GetFilePath()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "G:\\"; 
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select an Excel File to Read";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileName;
                }
            }
            return null;
        }
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            string filepath = GetFilePath();
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Open(filepath);
            Excel.Worksheet worksheet = workbook.Worksheets[1];
            int usedrow = worksheet.UsedRange.Rows.Count;

            for(int i = 2;  i < usedrow; i++)
            {
                string role = worksheet.Cells[i, 1].Value.ToString();   
                string FullName = worksheet.Cells[i, 2].Value.ToString();   
                string Email = worksheet.Cells[i, 3].Value.ToString();   
                string Department = worksheet.Cells[i, 4].Value.ToString();
                string Class = null;
                string Code = NewUserCode(role);
                User user = new User
                {
                    UserCode = Code,
                    Role = role,
                    FullName = FullName,
                    Email = Email,
                    Department = Department,
                };


                if (role == RoleAccount.Student.ToString())
                {
                    Class = worksheet.Cells[i, 5].Value.ToString();                   
                    user.ClassName = Class;
                }
                SaveNewUser(user);
            }
            MessageBox.Show("Đã thêm mới thành công");
            workbook.Close();

            LoadList();
            if (lblLecturer.ForeColor == Color.RoyalBlue)
                Display(userList);
            else
                Display(studentList);
        }

        private void panel4_DoubleClick(object sender, EventArgs e)
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
