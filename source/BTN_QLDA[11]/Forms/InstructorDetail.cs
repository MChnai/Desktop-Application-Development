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
    public partial class InstructorDetail : Form
    {
        List<Project> listProjects = new List<Project>();
        List<Project> result = new List<Project>();
        public string Instructor_Name {  get; set; }

        #region Load data
        public InstructorDetail()
        {
            InitializeComponent();
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
        private void GetResult()
        {
            foreach(Project project in listProjects) 
                if(project.Lecture_Name == Instructor_Name)
                    result.Add(project);
        }
        private void InstructorDetail_Load(object sender, EventArgs e)
        {
            SqlDataReader reader = ReadSQL("Select * from Projects");
            LoadDataList(reader);
            GetResult();
            dtgrvProjects.DataSource = result;
        }
        #endregion

        #region Open other forms
        private void btnProjects_Click(object sender, EventArgs e)
        {
            new Forms.frmQLDA().ShowDialog();
            this.Close();
        }
        private void btnDomain_Click(object sender, EventArgs e)
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
        #endregion
    }
}
