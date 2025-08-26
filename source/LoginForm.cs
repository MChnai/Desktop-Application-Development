using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN_QLDA_4_
{
    public partial class LoginForm : Form
    {
        bool menuExpand = false;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "M.Chnai" && txtPassword.Text == "Matsuda Chnai")
            {
                new MainForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Your username or your password is incorrect. Please try again.\n");
                txtPassword.Clear();
                txtUserName.Clear();
                txtUserName.Focus();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            mtAuthors.Start();
        }

        private void mtAuthors_Tick(object sender, EventArgs e)
        {
            if(menuExpand)
            {
                PnAuthors.Width -= 10;//decrease 10 pixcel each tick of time
                if(PnAuthors.Width == PnAuthors.MinimumSize.Width)
                {
                    menuExpand = false;
                    mtAuthors.Stop();
                }
            }
            else
            {
                PnAuthors.Width += 10;//Increase 10 pixcel each tick of time
                if (PnAuthors.Width == PnAuthors.MaximumSize.Width)
                {
                    menuExpand = true;
                    mtAuthors.Stop();
                }
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            if(txtUserName.Text == "User name")
            {
                txtUserName.Text = "";
                txtUserName.ForeColor = Color.Black;
            }
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Text = "User name";
                txtUserName.ForeColor = Color.LightGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.LightGray;
            }
        }

        private void PnAuthors_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

            txtUserName.Text = "User name";
            txtUserName.ForeColor = Color.LightGray;
            txtPassword.Text = "Password";
            txtPassword.ForeColor = Color.LightGray;
        }
    }
}
