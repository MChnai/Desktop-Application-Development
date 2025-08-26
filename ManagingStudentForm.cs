using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BTN_QLDA_4_
{
    public partial class ManagingStudentForm : Form
    {
        bool menuExpand = false;
        public ManagingStudentForm()
        {
            InitializeComponent();
        }
        private ListViewItem FindItem(string id)
        {
            foreach (ListViewItem lvi in lvStudent.Items)
                if (lvi.Text == txtID.Text)
                    return lvi;
            return null;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)
                 || string.IsNullOrEmpty(txtName.Text)
                 || string.IsNullOrEmpty(mtxtMail.Text)
                 || string.IsNullOrEmpty(mtxtPhoneNum.Text)
                 || string.IsNullOrEmpty(cbSex.Text))
                MessageBox.Show("Information is not enough yet. Please trype all the necessary information.");
            else
            {
                ListViewItem item = new ListViewItem();
                item.Text = txtID.Text;
                item.SubItems.Add(txtName.Text);
                item.SubItems.Add(cbSex.Text);
                item.SubItems.Add(dtpDateBirth.Text);
                item.SubItems.Add(mtxtMail.Text);
                item.SubItems.Add(mtxtPhoneNum.Text);
                lvStudent.Items.Add(item);

                txtID.Clear();
                txtName.Clear();
                cbSex.Items.Clear();
                mtxtPhoneNum.Clear();
                mtxtMail.Clear();
                dtpDateBirth.Value = Convert.ToDateTime("1/1/2020");
                cbSortType.Items.Clear();

                lvStudent.Show();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
                MessageBox.Show("Please enter ID to find which field need to delete.");
            else
            {
                ListViewItem item = FindItem(txtID.Text);
                if (item != null)
                    lvStudent.Items.Remove(item);
                else
                    MessageBox.Show("Cann't find ID " + txtID + " in the list. Plese try again.");

                txtID.Clear();
                txtName.Clear();
                cbSex.Items.Clear();
                mtxtPhoneNum.Clear();
                mtxtMail.Clear();
                dtpDateBirth.Value = DateTime.Now;
                cbSortType.Items.Clear();

                lvStudent.Show();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text)
              || string.IsNullOrEmpty(txtName.Text))
                MessageBox.Show("Information is not enough yet. Please trype all the necessary information.");
            else
            {
                ListViewItem item = new ListViewItem();
                item = FindItem(txtID.Text);

                if (item != null)
                {
                    item.Text = txtID.Text;
                    item.SubItems[0].Text = txtName.Text;
                    item.SubItems[1].Text = cbSex.Text;
                    item.SubItems[2].Text = dtpDateBirth.Text;
                    item.SubItems[3].Text = mtxtMail.Text;
                    item.SubItems[4].Text = mtxtPhoneNum.Text;

                }
                txtID.Clear();
                txtName.Clear();
                cbSex.Items.Clear();
                mtxtMail.Clear();
                mtxtPhoneNum.Clear();
                dtpDateBirth.Value = DateTime.Now;
                cbSortType.Items.Clear();

                lvStudent.Show();
            }
        }
        private void Displaycategory(SqlDataReader reader)
        {
            lvStudent.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["Student_ID"].ToString());
                lvStudent.Items.Add(item);
                item.SubItems.Add(reader["Student_Name"].ToString());
                item.SubItems.Add(reader["Student_Sex"].ToString());
                item.SubItems.Add(reader["Student_DateBirth"].ToString());
                item.SubItems.Add(reader["Student_Email"].ToString());
                item.SubItems.Add(reader["Student_Phone"].ToString());
            }
        }
        private void ManagingStudentForm_Load(object sender, EventArgs e)
        {
            string connectingString = "server = DESKTOP-SFSR5TO\\SQLEXPRESS; Initial Catalog = Projectmanagement[1]; Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectingString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Students";
            sqlConnection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            this.Displaycategory(sqlDataReader);
            sqlConnection.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }

        private void tMenu_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                pnSideBar.Width -= 10;//decrease 10 pixcel each tick of time
                if (pnSideBar.Width == pnSideBar.MinimumSize.Width)
                {
                    menuExpand = false;
                    tMenu.Stop();
                }
            }
            else
            {
                pnSideBar.Width += 10;//Increase 10 pixcel each tick of time
                if (pnSideBar.Width == pnSideBar.MaximumSize.Width)
                {
                    menuExpand = true;
                    tMenu.Stop();
                }
            }
        }


        private void pbMenu_Click(object sender, EventArgs e)
        {
            tMenu.Start();
        }
    }
}
