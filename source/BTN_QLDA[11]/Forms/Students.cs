using BTN_QLDA_11_.Models;
using BTN_QLDA_11_.Forms;
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
    public partial class Students : Form
    {
        private List<Student> studentList = new List<Student>();
        public Students()
        {
            InitializeComponent();
        }
        #region Load data
        private void LoadDataList(SqlDataReader reader)
        {
            Student student;
            while (reader.Read())
            {
                student = new Student();
                student.ID = reader["Student_ID"].ToString();
                student.Name = reader["Student_Name"].ToString();
                studentList.Add(student);
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
            foreach (Student student in studentList)
            {
                button = new Button();
                button.Name = "btn" + student.ID;
                button.Text = student.ID + "_" + student.Name;
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
                StudentDetail studentDetail = new StudentDetail();
                studentDetail.Name = GetName(clickedButton.Text);
                studentDetail.ShowDialog();
                this.Close();
            }
        }
        private void Students_Load(object sender, EventArgs e)
        {
            btnStudents.Focus();
            SqlDataReader reader = ReadSQL("Select * from Students");
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
