using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace BTN_QLDA_4_
{
    public partial class ManagingFieldsForm : Form
    {
        bool menuExpand = false;
        public ManagingFieldsForm()
        {
            InitializeComponent();
        }

        #region Others
        private void Displaycategory(SqlDataReader reader)
        {
            lvField.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["Domain_ID"].ToString());
                lvField.Items.Add(item);
                item.SubItems.Add(reader["Domain_Name"].ToString());
                item.SubItems.Add(reader["Note"].ToString());
            }
        }
        private void ManagingFieldsForm_Load(object sender, EventArgs e)
        {
            string connectingString = "server = DESKTOP-SFSR5TO\\SQLEXPRESS; Initial Catalog = Projectmanagement[1]; Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(connectingString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Domains";
            sqlConnection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            this.Displaycategory(sqlDataReader);
            sqlConnection.Close();

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private ListViewItem FindItem(string id)
        {
            if (lvField == null)
                return new ListViewItem();
            foreach (ListViewItem f in lvField.Items)
            {
                if (f.Text == txtID.Text)
                    return f;
            }
            return null;
        }
        private bool Check_Empty()
        {
            return lvField.Items.Count == 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Check_Empty())
            {
                ListViewItem item = new ListViewItem();
                item.Text = txtID.Text;
                item.SubItems.Add(txtName.Text);
                
                txtID.Clear();
                txtName.Clear();
                cbSortType.ResetText();
            }
            else
            {
                if (string.IsNullOrEmpty(txtID.Text)
                    || string.IsNullOrEmpty(txtName.Text))
                    MessageBox.Show("Information is not enough yet. Please trype all the necessary information.");
                else if (FindItem(txtID.Text) != null)
                    MessageBox.Show("The ID you type has been used. Please enter another ID that suitable.");
                else
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = txtID.Text;
                    item.SubItems.Add(txtName.Text);
                    lvField.Items.Add(item);
                }
                txtID.Clear();
                txtName.Clear();
                cbSortType.ResetText();
            }
            lvField.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
                MessageBox.Show("Please enter ID to find which field need to delete.");
            else if (FindItem(txtID.Text) == null)
                MessageBox.Show("The ID you type has been used. Please enter another ID that suitable.");
            else
            {
                ListViewItem item = new ListViewItem();
                item.Text = txtID.Text;

                ListViewItem itemDelete = new ListViewItem();
                foreach (ListViewItem lvi in lvField.Items)
                    if (lvi.Text == txtID.Text)
                    {
                        lvField.Items.Remove(lvi);
                        break;
                    }
            }
            txtID.Clear();
            txtName.Clear();
            cbSortType.ResetText();

            lvField.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Check_Empty())
            {
                ListViewItem item = new ListViewItem();
                item.Text = txtID.Text;
                item.SubItems.Add(txtName.Text);
                lvField.Items.Add(item);
                txtID.Clear();
                txtName.Clear();
                cbSortType.ResetText();
            }
            else
            {
                if (string.IsNullOrEmpty(txtID.Text)
              || string.IsNullOrEmpty(txtName.Text))
                    MessageBox.Show("Information is not enough yet. Please trype all the necessary information.");
                else if (FindItem(txtID.Text) == null)
                    MessageBox.Show("The ID you type has been used. Please enter another ID that suitable.");
                else
                {
                    foreach (ListViewItem lvi in lvField.Items)
                        if (lvi.Text == txtID.Text)
                        {
                            lvi.Text = txtID.Text;
                            lvi.SubItems[1].Text = txtName.Text;
                            break;
                        }
                }
                txtID.Clear();
                txtName.Clear();
                cbSortType.ResetText();
            }
            lvField.Show();
        }

        private void pbBack_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
            this.Hide();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pbMenu_Click(object sender, EventArgs e)
        {
            tMenu.Start();
        }

        private void tMenu_Tick_1(object sender, EventArgs e)
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
    }
}
