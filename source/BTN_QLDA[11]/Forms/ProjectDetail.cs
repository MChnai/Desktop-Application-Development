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
    public partial class ProjectDetail : Form
    {
        public string Project_Id = string.Empty;
        private Project project = new Project();
        List<Project> listProjects = new List<Project>();
        public ProjectDetail()
        {
            InitializeComponent();
        }
        

        private Project GetProject()
        {
            foreach (Project project in listProjects) 
                if(project.ID.Equals(this.Project_Id))
                    return project;
            return null;
        }
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
        private void ProjectDetail_Load(object sender, EventArgs e)
        {
            SqlDataReader reader = ReadSQL("Select * from Projects");
            LoadDataList(reader);
            project = GetProject();
            if(project == null) 
                return;
            txtID.Text = project.ID.ToString();
            txtProjectName.Text = project.Name.ToString();
            txtDomain.Text = project.Domain_Name.ToString();
            txtEvaluation.Text = project.Evalluation.ToString();
            txtIntrsuctor.Text = project.Lecture_Name.ToString();
            txtDetail.Text = project.Description.ToString();
            reader.Close();
            //txtSchoolYear.Text = project.SchoolYear.ToString();
            //txtStudents.Text = project.Students.ToString();
        }
    }
}
