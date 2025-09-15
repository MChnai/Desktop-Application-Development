using BTN_QLDA_11_.Models;
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

namespace BTN_QLDA_11_.Forms
{
    public partial class Domains : Form
    {
        List<Domain> listDomain = new List<Domain>();
        public Domains()
        {
            InitializeComponent();
        }
        #region Load data 
        private void LoadDataList(SqlDataReader reader)
        {
            Domain domain;
            while (reader.Read())
            {
                domain = new Domain();
                domain.ID = reader["Domain_ID"].ToString();
                domain.Name = reader["Domain_Name"].ToString();
                listDomain.Add(domain);
            }
        }
        private SqlDataReader ReadSQL(string command)
        {
            string source = "server = DESKTOP-SFSR5TO\\SQLEXPRESS; Initial Catalog = ProjectManagement3; Integrated Security=true";
            SqlConnection sqlConnection = new SqlConnection(source);
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = command;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            return reader;
        }
        private void CreateButtons()
        {
            Button button;
            foreach (Domain domain in listDomain)
            {
                button = new Button();
                button.Name = "btn" + domain.Name;
                button.Text = domain.Name;
                button.Size = new Size(880, 50);
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.White;
                button.Font = new System.Drawing.Font("Roboto", 14, System.Drawing.FontStyle.Bold);
                button.Click += Button_Click;
                pnlButtons.Controls.Add(button);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                DomainDetail domain = new DomainDetail();
                domain.Domain_Name = clickedButton.Text;
                domain.ShowDialog();
                this.Close();
            }
        }
        private void Domain_Load(object sender, EventArgs e)
        {
            btnDomain.Focus();
            SqlDataReader reader = ReadSQL("Select * from Domain");
            LoadDataList(reader);
            CreateButtons();
            reader.Close();
        }
        #endregion

        #region Open other form
        private void btnDomain_Click(object sender, EventArgs e)
        {
            new Domains().ShowDialog();
            this.Close();
        }
        private void btnProjects_Click(object sender, EventArgs e)
        {
            new Forms.frmQLDA().ShowDialog();
            this.Close();
        }
        private void btnStudents_Click(object sender, EventArgs e)
        {
            new Students().ShowDialog();
            this.Close();
        }
        private void btnInstructors_Click(object sender, EventArgs e)
        {
            new Instructors().ShowDialog();
            this.Close();
        }
        #endregion
    }
}
