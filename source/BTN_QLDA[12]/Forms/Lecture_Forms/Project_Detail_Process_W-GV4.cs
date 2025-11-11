using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.Student;
using BTN_QLDA_12_.Models.User_Role;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN_QLDA_12_.Forms.Lecture_Forms
{
    public partial class Project_Detail_Process_W_GV4 : Form
    {
        ProjectManagement _context;
        UsersModel _Account;
        Projects _projects;
        List<ProjectMembers> members;
        private static readonly HttpClient client = new HttpClient();
        public Project_Detail_Process_W_GV4(ProjectManagement context, UsersModel account, Projects pro)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            _projects = pro;
            lblAccountName.Text = _Account.FullName;
            LoadProjectInfo();
            LoadGrade();
            LoadFile();
        }
        private void LoadProjectInfo()
        {
            Topics top = _context.Topics
                            .Where(t => t.TopicID == _projects.TopicID)
                            .FirstOrDefault();  
            ProjectMembers leader = _context.ProjectMembers
                            .Where(m => m.ProjectID == _projects.ProjectID)
                            .FirstOrDefault();
            members = _context.ProjectMembers
                            .Where(m => m.ProjectID == _projects.ProjectID)
                            .ToList(); 
            User lead = _context.users.Where(u => u.UserId == leader.StudentID).FirstOrDefault();
            if(top != null)
            {
                lblTopicName.Text = top.Title;
                lblStudentName.Text = lead.FullName;
                lblStudentMail.Text = lead.Email;
            }
        }
        private void LoadGrade()
        {
            List<ProjectGrades> grade = _context.ProjectGrades
                                            .Where(g => g.ProjectID == _projects.ProjectID)
                                            .ToList();
            ProjectFeedback fb = _context.projectFeedbacks
                                    .Where(f => f.ProjectID == _projects.ProjectID)
                                    .FirstOrDefault();
            if(grade.Count > 0)
            {
                nudReportGrade.Text = grade[0].Grade.ToString();
                nudCodeGrade.Text = grade[1].Grade.ToString();
                nudAttitudeGrade.Text = grade[2].Grade.ToString();

                nudAttitudeGrade.Enabled = false;
                nudCodeGrade.Enabled = false;
                nudReportGrade.Enabled = false;
                btnSubmit.Enabled = false;
                txtFeddback.Enabled = false;
                lblFinalGrade.Text = (Math.Round(((grade[0].Grade + grade[1].Grade + grade[2].Grade) / 3), 2)).ToString();
                if(fb != null) 
                    txtFeddback.Text = fb.Content;
            }
        }
        private async void LoadFile()
        {
            string serverUrl = "http://localhost:8080/Uploads/";

            try
            {
                HttpResponseMessage response = await client.GetAsync(serverUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    var fileList = System.Text.Json.JsonSerializer.Deserialize<List<string>>(jsonResponse);
                    lstFileView.Items.Clear();
                    if (fileList != null && fileList.Count > 0)
                    {
                        foreach (string fileName in fileList)
                        {
                            foreach (var m in members)
                            {
                                User user = _context.users.Where(u => u.UserId == m.StudentID).FirstOrDefault();
                                if (fileName.Contains(user.UserCode))
                                    lstFileView.Items.Add(fileName);
                            }
                        }
                        if (lstFileView.SelectedText != null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No files found on server.");
                    }
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Request failed: {ex.Message}");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFeddback.Text))
            {
                MessageBox.Show("Phần nhận xét vẫn đang trống. Vui lòng nhập nhận xét.");
                return;
            }
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn nộp điểm?\n\nĐiểm tổng kết: {lblFinalGrade.Text:F2}",
                "Xác nhận nộp điểm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
            {
                return;
            }
            btnSubmit.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                var g1 = _context.ProjectGrades
                            .Where(g => g.ProjectID == _projects.ProjectID && g.CriterionID == 1)
                            .FirstOrDefault();
                if (g1 != null)
                    g1.Grade = nudReportGrade.Value;
                else
                    _context.ProjectGrades.Add(new ProjectGrades { ProjectID = _projects.ProjectID, CriterionID = 1, Grade = nudReportGrade.Value });

                var g2 = _context.ProjectGrades
                            .Where(g => g.ProjectID == _projects.ProjectID && g.CriterionID == 2)
                            .FirstOrDefault();
                if (g2 != null)
                    g2.Grade = nudCodeGrade.Value;
                else
                    _context.ProjectGrades.Add(new ProjectGrades { ProjectID = _projects.ProjectID, CriterionID = 2, Grade = nudCodeGrade.Value }); // Thêm mới

                var g3 = _context.ProjectGrades.FirstOrDefault(
                    g => g.ProjectID == _projects.ProjectID && g.CriterionID == 3);
                if (g3 != null)
                    g3.Grade = nudAttitudeGrade.Value;
                else
                    _context.ProjectGrades.Add(new ProjectGrades { ProjectID = _projects.ProjectID, CriterionID = 3, Grade = nudAttitudeGrade.Value }); // Thêm mới

                var fb = _context.projectFeedbacks.FirstOrDefault(
                    f => f.ProjectID == _projects.ProjectID);

                if (fb != null)
                {
                    fb.Content = txtFeddback.Text;
                    fb.FeedbackDate = DateTime.Now;
                    fb.SenderID = _Account.UserId;
                }
                else
                {
                    _context.projectFeedbacks.Add(new ProjectFeedback
                    {
                        ProjectID = _projects.ProjectID,
                        SenderID = _Account.UserId,
                        Content = txtFeddback.Text,
                        FeedbackDate = DateTime.Now,
                        AttachmentFile = null,
                    });
                }
                var project = _context.ProjectMembers.Where(p => p.ProjectID == _projects.ProjectID).ToList();
                if (project != null)
                {
                    foreach (var item in project)
                    {
                        _context.Notifications.Add(new Notifications
                        {
                            RecipientID = item.StudentID,
                            Content = "Giảng viên vừa chấm điểm đồ án của bạn.",
                            LinkURL = $"/project/grades/{_projects.ProjectID}",
                            IsRead = false,
                            Timestamp = DateTime.Now
                        });
                        _context.SaveChanges();
                    }
                }

                MessageBox.Show("Đã nộp điểm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu vào cơ sở dữ liệu.\n" + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            string serverUrl = "http://localhost:8080/Uploads/";

            try
            {
                HttpResponseMessage response = await client.GetAsync(serverUrl);

                if (response.IsSuccessStatusCode)
                {

                    string selectedFileName = lstFileView.SelectedItem.ToString();
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.FileName = selectedFileName; 
                        sfd.Filter = "All files (*.*)|*.*";
                        sfd.Title = "Save File As...";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string savePath = sfd.FileName;

                            try
                            {
                                string fileUrl = $"http://localhost:8080/Uploads/{selectedFileName}";
                                response = await client.GetAsync(fileUrl);

                                if (response.IsSuccessStatusCode)
                                {
                                    using (Stream fileStream = await response.Content.ReadAsStreamAsync())
                                    using (FileStream localFileStream = File.Create(savePath))
                                    {
                                        await fileStream.CopyToAsync(localFileStream);
                                    }
                                    MessageBox.Show($"File saved successfully: {savePath}");
                                }
                                else
                                {
                                    MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Download failed: {ex.Message}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Download cancelled.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No files found on server.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Request failed: {ex.Message}");
            }

        }
        private void LoadFinalGrade()
        {
            decimal reportGrade = nudReportGrade.Value * 40 / 100;
            decimal CodeGrade = nudCodeGrade.Value * 50 / 100;
            decimal attitudeGrade = nudAttitudeGrade.Value * 10 / 100;

            lblFinalGrade.Text = (reportGrade + CodeGrade + attitudeGrade).ToString("F2");
        }
        private void nudReportGrade_ValueChanged(object sender, EventArgs e)
        {
            LoadFinalGrade();
        }
    }
}
