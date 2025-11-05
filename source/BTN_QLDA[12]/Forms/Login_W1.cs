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
    public partial class Login_W1 : Form
    {
        private bool menuExpand = false;
        private readonly ProjectManagement _content;
        public UsersModel LoggedInAccount { get; private set; }

        public Login_W1()
        {
            InitializeComponent();
        }
        public Login_W1(ProjectManagement content)
        {
            InitializeComponent();
            _content = content;
        }

        #region
        private void tmAuthors_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                PnAuthors.Width -= 10;//decrease 10 pixcel each tick of time
                if (PnAuthors.Width == PnAuthors.MinimumSize.Width)
                {
                    menuExpand = false;
                    tmAuthors.Stop();
                }
            }
            else
            {
                PnAuthors.Width += 10;//Increase 10 pixcel each tick of time
                if (PnAuthors.Width == PnAuthors.MaximumSize.Width)
                {
                    menuExpand = true;
                    tmAuthors.Stop();
                }
            }
        }

        private void pbxFeather_Click(object sender, EventArgs e)
        {
            tmAuthors.Start();
        }
        #endregion

        #region Loggin
        private bool VerifyPassword(string inputPassword, string storedPassword)
        {
            return inputPassword == storedPassword;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string accountName = txtUserName.Text;
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Tên tài khoản và mật khẩu không được để trống.");
                return;
            }
            
            var account = _content.users
                .FirstOrDefault(a => a.UserCode == accountName);
            if(account == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản. hãy kiểm tra lại tên hoặc mật khẩu");
                return;
            }
            if (!VerifyPassword(password, account.PasswordHash))
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng.");
                return;
            }
            LoggedInAccount = new UsersModel
            {
                UserId = account.UserId,
                UserCode = account.UserCode,
                FullName = account.FullName,
                Mail = account.Email,
                ClassName = account.ClassName,
                PasswordHash = account.PasswordHash,
                Department = account.Department,
                Role = account.Role,
            };

            DialogResult = DialogResult.OK;
        }
        #endregion
    }
}
