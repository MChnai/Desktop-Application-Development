using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Student;
using BTN_QLDA_12_.Models.User_Role;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN_QLDA_12_.Forms.Student_Forms
{
    public partial class My_Project_Detail_W_SV3_Detail : Form
    {
        private string selectedFilePath1;
        private string selectedFilePath2;
        private static readonly HttpClient client = new HttpClient();
        private string selectedFilePath = "";
        private const string ApiBaseUrl = "https://localhost:7172/weatherforecast"; 
        ProjectManagement _context;
        UsersModel _Account;
        Projects project;
        public My_Project_Detail_W_SV3_Detail(ProjectManagement _context, UsersModel _Account, Projects projects)
        {
            InitializeComponent();
            this._context = _context;
            this._Account = _Account;
            project = projects;
            LoadProjectGrade();
        }
        private void LoadProjectGrade()
        {
            List<ProjectGrades> grade = _context.ProjectGrades.Where(p => p.ProjectID == project.ProjectID).OrderBy(t => t.CriterionID).ToList();
            ProjectFeedback fb = _context.projectFeedbacks.Where(p => p.ProjectID == project.ProjectID).FirstOrDefault();
            List<FinalSubmissions> fsb = _context.FinalSubmissions.Where(p => p.ProjectID == project.ProjectID && p.SubmitterID == _Account.UserId).ToList();
            if (grade.Count > 0)
            {
                lblCritical1.Text = grade[0].Grade.ToString();
                lblCritical2.Text = grade[1].Grade.ToString();
                lblCritical3.Text = grade[2].Grade.ToString();
                lblGrade.Text = Math.Round(((decimal)grade[0].Grade + (decimal)grade[1].Grade + (decimal)grade[2].Grade)/(decimal)3, 2).ToString();
                if (fb != null)
                    txtFeedback.Text = fb.Content;
                if (fsb.Count > 0)
                {
                    lblFileName1.Text = fsb[0].FileName;
                    lblZip.Text = fsb[1].FileName;
                }
                GetLock();
            }
            pnlSubmitLarge.Visible = true;
            pnlGrade.Visible = false;
        }
        private void GetLock()
        {
            if (lblGrade.Text != "0")
            {
                foreach (var button in pnlRight.Controls)
                    if (button is System.Windows.Forms.Button)
                        ((System.Windows.Forms.Button)button).Enabled = false;
                else if(button is Panel)
                        foreach(var control in ((Panel)button).Controls)
                            if(control is System.Windows.Forms.Button)
                                ((System.Windows.Forms.Button)control).Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn file báo cáo (.docx)";
                dialog.Filter = "Word Documents (*.docx)|*.docx|All files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath1 = dialog.FileName;
                    lblFileName1.Text = Path.GetFileName(selectedFilePath1);
                }
            }
        }
        private async void PushData(string filepath)
        {
            string filePath = filepath;
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("Please select a valid file first.");
                return;
            }

            try
            {
                using (var fileStream = File.OpenRead(filePath))
                using (var streamContent = new StreamContent(fileStream))
                using (var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8080/Uploads/"))
                {
                    request.Content = streamContent;
                    request.Headers.Add("X-File-Name", Path.GetFileName(filePath));
                    HttpResponseMessage response = await client.SendAsync(request);
                    if (response.IsSuccessStatusCode)
                    {
                        return;
                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Upload failed: {ex.Message}");
            }
            finally
            {
                btnSubmit.Enabled = false;
            }
        }
        private async void button3_ClickAsync(object sender, EventArgs e)
        {
                if (string.IsNullOrEmpty(selectedFilePath1) || string.IsNullOrEmpty(selectedFilePath2))
                {
                    MessageBox.Show("Vui lòng chọn đủ cả 2 file trước khi nộp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult result = MessageBox.Show(
                    "Bạn chỉ được nộp bài 1 LẦN DUY NHẤT.\nBạn có chắc chắn muốn nộp bài không?",
                    "XÁC NHẬN NỘP BÀI",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
            using (var formData = new MultipartFormDataContent())
            {
                try
                {
                    byte[] file1Data = File.ReadAllBytes(selectedFilePath1);
                    byte[] file2Data = File.ReadAllBytes(selectedFilePath2);

                    string fileName1 = Path.GetFileName(selectedFilePath1);
                    string fileName2 = Path.GetFileName(selectedFilePath2);

                    FinalSubmissions db = new FinalSubmissions();
                    var submission = new FinalSubmissions
                    {
                        SubmitterID = _Account.UserId,
                        ProjectID = project.ProjectID,
                        SubmissionDate = DateTime.Now,
                        FileURL = selectedFilePath1,

                        FileName = fileName1,
                        FileType = "Report_PDF",
                    };
                    var submission2 = new FinalSubmissions
                    {
                        SubmitterID = _Account.UserId,
                        ProjectID = project.ProjectID,
                        SubmissionDate = DateTime.Now,
                        FileURL = selectedFilePath2,

                        FileName = fileName2,
                        FileType = "Report_PDF",
                    };

                    _context.FinalSubmissions.Add(submission);
                    _context.FinalSubmissions.Add(submission2);
                    _context.SaveChanges();

                    selectedFilePath = selectedFilePath1;
                    PushData(selectedFilePath);
                    selectedFilePath = selectedFilePath2;
                    PushData(selectedFilePath);

                    // Disable buttons to prevent re-submission
                    btnWord.Enabled = false;
                    btnSubmit.Enabled = false;
                    btnZip.Enabled = false;

                    //// Gửi request POST đến API
                    //var response = await client.PostAsync($"{ApiBaseUrl}/api/files/send", formData);

                    //if (response.IsSuccessStatusCode)
                    //{
                    //    MessageBox.Show("Gửi file thành công!");
                    //}
                    //else
                    //{
                    //    // SỬA 2: Giữ "await" ở đây để đọc nội dung lỗi
                    //    MessageBox.Show("Gửi thất bại: " + await response.Content.ReadAsStringAsync());
                    //}
                    // 5. SUCCESS
                    MessageBox.Show("Nộp bài thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }

            }
        }
        private void btnZip_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn file mã nguồn (.zip)";
                dialog.Filter = "Zip Archives (*.zip)|*.zip"; // Filter for .zip

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath2 = dialog.FileName;
                    lblZip.Text = Path.GetFileName(selectedFilePath2);
                }
            }
        }
        private void label14_Click(object sender, EventArgs e)
        {
            lblSubmit.ForeColor = Color.RoyalBlue;
            pnlSubmit.BackColor = Color.RoyalBlue;
            lblResult.ForeColor = Color.Gray;
            pnlResult.BackColor = Color.Gray;
            pnlSubmitLarge.Visible = true;
            pnlGrade.Visible = false;
        }
        private void lblResult_Click(object sender, EventArgs e)
        {
            lblResult.ForeColor = Color.RoyalBlue;
            pnlResult.BackColor = Color.RoyalBlue;
            lblSubmit.ForeColor = Color.Gray;
            pnlSubmit.BackColor = Color.Gray;
            pnlGrade.Visible = true;
            pnlSubmitLarge.Visible = false;
        }
    }
}
