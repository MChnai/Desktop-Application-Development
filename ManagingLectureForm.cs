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

namespace BTN_QLDA_4_
{
    public partial class ManagingLectureForm : Form
    {
        bool menuExpand = false;
        public ManagingLectureForm()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private ListViewItem FindItem(string id)
        {
            int count = 0;
            foreach (ListViewItem lvi in lvLecture.Items)
            {
                if (lvi.Text == txtID.Text)
                    return lvi;
                count++;
            }
            if (count == 0)
                return new ListViewItem();
            return null;
        }
        private bool Check_Empty()
        {
            return lvLecture.Items.Count == 0;
        }

        #region Others
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Connect to SQL
        private void Displaycategory(SqlDataReader reader)
        {
            lvLecture.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["Lecture_ID"].ToString());
                lvLecture.Items.Add(item);
                item.SubItems.Add(reader["Lecture_Name"].ToString());
                item.SubItems.Add(reader["Lecture_Sex"].ToString());
                item.SubItems.Add(reader["Lecture_DateBirth"].ToString());
                item.SubItems.Add(reader["Lecture_Email"].ToString());
                item.SubItems.Add(reader["Lecture_Phone"].ToString());
            }
        }
        private void ManagingLectureForm_Load(object sender, EventArgs e)
        {
            string connectingString = "server = DESKTOP-SFSR5TO\\SQLEXPRESS; Initial Catalog = Projectmanagement[1]; Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectingString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Lectures";
            sqlConnection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            this.Displaycategory(sqlDataReader);
            sqlConnection.Close();
        }
        #endregion
        //Addition method
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
                lvLecture.Items.Add(item);

                txtID.Clear();
                txtName.Clear();
                cbSex.Items.Clear();
                mtxtPhoneNum.Clear();
                mtxtMail.Clear();
                dtpDateBirth.Value = DateTime.Now;
                cbSortType.Items.Clear();

                lvLecture.Show();
            }
        }
        //Delete method
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
                MessageBox.Show("Please enter ID to find which field need to delete.");
            else
            {
                ListViewItem item = FindItem(txtID.Text);
                if (item != null)
                    lvLecture.Items.Remove(item);
                else
                    MessageBox.Show("Cann't find ID " + txtID + " in the list. Plese try again.");

                txtID.Clear();
                txtName.Clear();
                cbSex.Items.Clear();
                mtxtPhoneNum.Clear();
                mtxtMail.Clear();
                dtpDateBirth.Value = DateTime.Now;
                cbSortType.Items.Clear();

                lvLecture.Show();
            }
        }
        //Edit method
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
                dtpDateBirth.Value = Convert.ToDateTime("1/1/2020");
                cbSortType.Items.Clear();

                lvLecture.Show();
            }
        }

        private void pbBack_Click(object sender, EventArgs e)
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
