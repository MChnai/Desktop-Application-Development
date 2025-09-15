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
    public partial class Instructors : Form
    {
        List<Instructor> instructors = new List<Instructor>();
        public Instructors()
        {
            InitializeComponent();
        }

        #region Load data
        private void LoadDataList(SqlDataReader reader)
        {
            Instructor instructor;
            while (reader.Read())
            {
                instructor = new Instructor();
                instructor.ID = reader["Lecture_ID"].ToString();
                instructor.Name = reader["Lecture_Name"].ToString();
                instructors.Add(instructor);
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
            foreach (Instructor instructor in instructors)
            {
                button = new Button();
                button.Name = "btn" + instructor.ID;
                button.Text = instructor.ID + "_" + instructor.Name;
                button.Size = new Size(868, 50);
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.White;
                button.Font = new System.Drawing.Font("Roboto", 14, System.Drawing.FontStyle.Bold);
                button.Click += Button_Click;
                pnlButtons.Controls.Add(button);
            }
        }
        private string GetName(string Id_Name)
        {
            string[] result = Id_Name.Split('_');
            return result[1];
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                InstructorDetail instructorDetail = new InstructorDetail();
                instructorDetail.Instructor_Name = GetName(clickedButton.Text);
                instructorDetail.ShowDialog();
                this.Close();
            }
        }
        private void Instructors_Load(object sender, EventArgs e)
        {
            btnStudents.Focus();
            SqlDataReader reader = ReadSQL("Select * from Projects");
            LoadDataList(reader);
            CreateButtons();
            reader.Close();
        }
        #endregion

        #region Open other forms
        private void btnProjects_Click(object sender, EventArgs e)
        {
            new Forms.frmQLDA().ShowDialog();
            this.Close();
        }
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
        #endregion
    }
}
