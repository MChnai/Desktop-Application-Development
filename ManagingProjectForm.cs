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
    public partial class ManagingProjectForm : Form
    {
        bool menuExpand = false;
        public ManagingProjectForm()
        {
            InitializeComponent();
        }

        #region Others
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProjectID.Text)
               || string.IsNullOrEmpty(txtProjectName.Text)
               || string.IsNullOrEmpty(txtDescription.Text)
               || string.IsNullOrEmpty(txtEvaluation.Text)
               || string.IsNullOrEmpty(cbLectureName.Text)
               || string.IsNullOrEmpty(cbFieldName.Text))
                MessageBox.Show("Information is not enough yet. Please trype all the necessary information.");
            else
            {
                ListViewItem item = new ListViewItem();
                item.Text = txtProjectID.Text;
                item.SubItems.Add(txtProjectName.Text);
                item.SubItems.Add(txtDescription.Text);
                item.SubItems.Add(txtEvaluation.Text);
                item.SubItems.Add(cbLectureName.Text);
                item.SubItems.Add(cbFieldName.Text);
                lvProject.Items.Add(item);

                txtProjectID.Clear();
                txtProjectName.Clear();
                txtDescription.Clear();
                txtEvaluation.Clear();
                cbLectureName.Items.Clear();
                cbFieldName.Items.Clear();
                cbSortType.ResetText();

                lvProject.Show();
            }
        }
        private ListViewItem FindItem(string id)
        {
            foreach (ListViewItem lvi in lvProject.Items)
                if (lvi.Text == txtProjectID.Text)
                    return lvi;
            return null;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProjectID.Text))
                MessageBox.Show("Please enter ID to find which field need to delete.");
            else
            {
                ListViewItem item = FindItem(txtProjectID.Text);
                if (item != null)
                    lvProject.Items.Remove(item);
                else
                    MessageBox.Show("Cann't find ID " + txtProjectID + " in the list. Plese try again.");

                txtProjectID.Clear();
                txtProjectName.Clear();
                txtDescription.Clear();
                txtEvaluation.Clear();
                cbLectureName.Items.Clear();
                cbFieldName.Items.Clear();
                cbSortType.ResetText();

                lvProject.Show();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProjectID.Text)
            || string.IsNullOrEmpty(txtProjectName.Text))
                MessageBox.Show("Information is not enough yet. Please trype all the necessary information.");
            else
            {
                ListViewItem item = new ListViewItem();
                item = FindItem(txtProjectID.Text);

                if (item != null)
                {
                    item.Text = txtProjectID.Text;
                    item.SubItems[0].Text = txtProjectName.Text;
                    item.SubItems[1].Text = txtDescription.Text;
                    item.SubItems[2].Text = txtEvaluation.Text;
                    item.SubItems[3].Text = cbLectureName.Text;
                    item.SubItems[4].Text = cbFieldName.Text;
                    item.SubItems[6].Text = cbSortType.Text;

                }
                txtProjectID.Clear();
                txtProjectName.Clear();
                txtDescription.Clear();
                txtEvaluation.Clear();
                cbLectureName.Items.Clear();
                cbFieldName.Items.Clear();
                cbSortType.Items.Clear();

                lvProject.Show();
            }
        }
        private void Displaycategory(SqlDataReader reader)
        {
            lvProject.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["Topic_ID"].ToString());
                lvProject.Items.Add(item);
                item.SubItems.Add(reader["Topic_Name"].ToString());
                item.SubItems.Add(reader["Description"].ToString());
                item.SubItems.Add(reader["Evaluation_Level"].ToString());
                item.SubItems.Add(reader["Lecture_ID"].ToString());
                item.SubItems.Add(reader["Domain_ID"].ToString());
            }
        }
        private void ManagingProjectForm_Load(object sender, EventArgs e)
        {
            string connectingString = "server = DESKTOP-SFSR5TO\\SQLEXPRESS; Initial Catalog = Projectmanagement[1]; Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectingString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Topics";
            sqlConnection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            this.Displaycategory(sqlDataReader);
            sqlConnection.Close();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
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

        private void pnSideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbMenu_Click(object sender, EventArgs e)
        {
            tMenu.Start();
        }
    }
}
