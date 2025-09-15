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
    public partial class frmQLDA : Form
    {
        List<Project> listProjects = new List<Project>();
        public frmQLDA()
        {
            InitializeComponent();
        }

        #region Load form and add data
        private void LoadDataList(SqlDataReader reader)
        {
            while (reader.Read())
            {
                Project project = new Project();
                project.ID = reader["Project_ID"].ToString();
                project.Name = reader["Project_Name"].ToString();
                project.Description = reader["Description"].ToString();
                project.Evalluation = reader["Evaluation_Level"].ToString();
                project.Lecture_Name = reader["lecture_Name"].ToString();
                project.Domain_Name = reader["Domain_Name"].ToString();
                listProjects.Add(project);
            }
        }
        private void Displaycategory(SqlDataReader reader, List<Project> list)
        {
            dtgrvProjects.DataSource = list;
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
        #endregion

        //Project form load
        private void frmQLDA_Load(object sender, EventArgs e)
        {
            SqlDataReader reader = ReadSQL("Select * from Projects");
            LoadDataList(reader);
            Displaycategory(reader, listProjects);
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search by ID, Domain, Instructors,...";
                txtSearch.ForeColor = Color.FromArgb(117, 117, 121);
            }
            btnProjects.Focus();
            reader.Close();
        }

        #region Search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SqlDataReader sqlDataReader = ReadSQL("Select * from Projects");
            if (txtSearch.Text == "Search by ID, Domain, Instructors,...")
            {
                Displaycategory(sqlDataReader, listProjects);
                return;
            }
            List<Project> result = new List<Project>();
            foreach (Project project in listProjects)
            {
                if (project.ID.Contains(txtSearch.Text))
                    result.Add(project);
                else if (project.Name.Contains(txtSearch.Text))
                    result.Add(project);
                else if (project.Lecture_Name.Contains(txtSearch.Text))
                    result.Add(project);
                else if (project.Domain_Name.Contains(txtSearch.Text))
                    result.Add(project);
                else if (project.Evalluation.Contains(txtSearch.Text))
                    result.Add(project);
                else if (project.Description.Contains(txtSearch.Text))
                    result.Add(project);
            }
            this.Displaycategory(sqlDataReader, result);
        }
        #endregion

        #region format biding for search text
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by ID, Domain, Instructors,...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "Search by ID, Domain, Instructors,...";
                txtSearch.ForeColor = Color.FromArgb(117, 117, 121);
            }
        }
        #endregion

        #region View/Edit/Delete buttons
        private Project GetProject(DataGridViewCellEventArgs e, DataGridViewRow row)
        {
            Project project = new Project();
            project.ID = row.Cells[3].Value.ToString();

            return project;
        }
        private void dtgrvProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgrvProjects.Columns["clActions"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgrvProjects.Rows[e.RowIndex];
                Project project = GetProject(e, row);
                ProjectDetail detail = new ProjectDetail();
                detail.Project_Id = project.ID;
                detail.ShowDialog();
            }
            //Still not update on sql
            if (e.ColumnIndex == dtgrvProjects.Columns["clEdit"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgrvProjects.Rows[e.RowIndex];
                Project project = GetProject(e, row);
                ProjectEdit detail = new ProjectEdit();
                detail.Project_Id = project.ID;
                detail.ShowDialog();
            }
            //Still not update on sql
            if (e.ColumnIndex == dtgrvProjects.Columns["clDelete"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgrvProjects.Rows[e.RowIndex];
                Project project = GetProject(e, row);
                listProjects.Remove(project);
                dtgrvProjects.Refresh();
            }
        }
        #endregion

        private void btnLDomains_Click(object sender, EventArgs e)
        {
            new Domains().ShowDialog();
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

        private void button1_Click(object sender, EventArgs e)
        {
            new ProjectAddition().ShowDialog();
        }
    }
}
