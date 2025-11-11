using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.Student;
using BTN_QLDA_12_.Models.User_Role;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;
using BTN_QLDA_12_.Models.Admin;
using DocumentFormat.OpenXml.Drawing;

namespace BTN_QLDA_12_.Forms
{
    public partial class Reporting_Analytics_W_A5 : Form
    {
        private bool menuExpand = false;
        ProjectManagement _context;
        UsersModel _Account;
        private string _period {  get; set; }
        public Reporting_Analytics_W_A5(ProjectManagement context, UsersModel account)
        {
            InitializeComponent();
            _context = context;
            _Account = account;
            lblAccountName.Text = _Account.FullName;
            LoadProjectRatioChart();
            LoadGradeChart();
        }
        private void LoadProjectRatioChart()
        {
            decimal ExcellentRatio = 0;
            decimal GoodRatio = 0;
            decimal FailedRatio = 0;

            ExcellentRatio = _context.ProjectGrades
                .Count(a => a.Grade >= (decimal)8.5);

            GoodRatio = _context.ProjectGrades
                    .Count(a => a.Grade >= (decimal)7 && a.Grade < (decimal)8.5);

            FailedRatio =  _context.ProjectGrades
                    .Count(a => a.Grade < (decimal)7);

            decimal total = ExcellentRatio + GoodRatio + FailedRatio;
            decimal Excellent = Math.Round(ExcellentRatio / total * 100, 2);
            decimal Good = Math.Round(GoodRatio / total * 100, 2);
            decimal Fail = Math.Round(FailedRatio / total * 100, 2);
                       

            chartProjectRatio.Titles.Clear();
            chartProjectRatio.Series.Clear();
            chartProjectRatio.Legends.Clear();

            Series pieSeries = new Series("RatioProject");
            pieSeries.ChartType = SeriesChartType.Pie;
            pieSeries.Points.AddXY("Xuất sắc: " + Excellent, ExcellentRatio);
            pieSeries.Points.AddXY("Tốt: " + Good, GoodRatio);
            pieSeries.Points.AddXY("Khá: " + Fail, FailedRatio);

            chartProjectRatio.Legends.Add(new Legend("ProjectLegend"));            
            chartProjectRatio.Legends[0].Title = "Tỉ lệ";
            chartProjectRatio.Legends[0].Docking = Docking.Right;

            chartProjectRatio.Series.Add(pieSeries);
        }
        private void LoadGradeChart()
        {
            List<decimal> grades = _context.ProjectGrades
                                        .Distinct()
                                        .Select(g => g.Grade).ToList();
            Series pieSeries = new Series("RatioProject");
            pieSeries.ChartType = SeriesChartType.Pie;
            foreach (decimal grade in grades)
            {
                int amount = _context.ProjectGrades
                                .Count(g => g.Grade == grade);
                pieSeries.Points.AddXY(grade + ":" + amount, amount);
            }
                       

            chartGrade.Titles.Clear();
            chartGrade.Series.Clear();
            chartGrade.Legends.Clear();

            chartGrade.Legends.Add(new Legend("ProjectLegend"));            
            chartGrade.Legends[0].Title = "Tỉ lệ";
            chartGrade.Legends[0].Docking = Docking.Right;

            chartGrade.Series.Add(pieSeries);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            using (var analisticDetail = new Forms.Admin_Forms.Analistic_Detail_W_A5_Detail(_context))
            {
                DialogResult result = analisticDetail.ShowDialog();
                if (result == DialogResult.OK)
                    _period = analisticDetail.Period;
            }
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            tmSideBar.Start();
        }
        private void tmSideBar_Tick(object sender, EventArgs e)
        {
            if (menuExpand)
            {
                pnSideBar.Width -= 10;//decrease 10 pixcel each tick of time        
                var X = pictureBox12.Location.X - 10;
                pictureBox12.Location = new System.Drawing.Point(X, pictureBox12.Location.Y);
                if (pnSideBar.Width == pnSideBar.MinimumSize.Width)
                {
                    menuExpand = false;
                    tmSideBar.Stop();
                }
            }
            else
            {
                pnSideBar.Width += 10;//Increase 10 pixcel each tick of time
                var X = pictureBox12.Location.X + 10;
                pictureBox12.Location = new System.Drawing.Point(X, pictureBox12.Location.Y);
                if (pnSideBar.Width == pnSideBar.MaximumSize.Width)
                {
                    menuExpand = true;
                    tmSideBar.Stop();
                }
            }
        }
        private List<List<string>> ReportStudentGrade(int periodID)
        {
            List<ProjectGrades> grades = new List<ProjectGrades>();
            List<User> student = new List<User>();
            List<ProjectMembers> members = new List<ProjectMembers>();
            List<Projects> projects = new List<Projects>();
            List<Topics> topics = new List<Topics>();
            List<List<string>> result = new List<List<string>>();

            grades = _context.ProjectGrades.ToList();
            student = _context.users
                  .Where(u => u.Role == RoleAccount.Student.ToString())
                  .ToList();
            members = _context.ProjectMembers.ToList();
            projects = _context.Projects.ToList();
            topics = _context.Topics.ToList();

            foreach (var stu in student)
            {
                List<string> item = new List<string>();
                foreach (var member in members)
                    if (member.StudentID == stu.UserId)
                        foreach (var pro in projects)
                            if (pro.ProjectID == member.ProjectID)
                                foreach (var grade in grades)
                                    if (grade.ProjectID == member.ProjectID)
                                        foreach (var p in topics)
                                            if (p.TopicID == pro.TopicID && p.ProjectPeriodID == periodID)
                                            {
                                                item = new List<string>();
                                                item.Add(stu.FullName);
                                                item.Add(stu.UserCode);
                                                item.Add(p.Title);
                                                item.Add(grade.Grade.ToString());
                                                result.Add(item);
                                            }
            }
            return result;
        }
        private List<List<string>> ReportLectureStudent(int period)
        {
            List<User> lecturer = new List<User>();
            List<User> student = new List<User>();
            List<Topics> topics = new List<Topics>();
            List<ProjectMembers> members = new List<ProjectMembers>();
            List<Projects> projects = new List<Projects>();
            List<List<string>> result = new List<List<string>>();

            lecturer = _context.users
                            .Where(u => u.Role == RoleAccount.Lecturer.ToString()).ToList();
            student = _context.users
                            .Where(u => u.Role == RoleAccount.Student.ToString()).ToList();
            topics = _context.Topics.ToList();
            members = _context.ProjectMembers.ToList();
            projects = _context.Projects.ToList();

            foreach (var lec in lecturer)
            {
                List<string> item = new List<string>();
                foreach (var top in topics)
                    if (top.LecturerID == lec.UserId)
                        foreach (var pro in projects)
                            if (pro.TopicID == top.TopicID && top.ProjectPeriodID == period)
                                foreach (var mem in members)
                                    if (mem.ProjectID == pro.ProjectID)
                                        foreach (var stu in student)
                                            if (stu.UserId == mem.StudentID)
                                            {
                                                item.Add(lec.UserId.ToString());
                                                item.Add(lec.FullName.ToString());
                                                item.Add(stu.UserId.ToString());
                                                item.Add(stu.FullName.ToString());
                                                item.Add(top.Title);
                                                result.Add(item);
                                            }
            }
            return result;
        }
        private int GetPeriodID()
        {
            List<ProjectPeriods> period = new List<ProjectPeriods>();
            period = _context.ProjectsPeriods
                .Where(p => p.Name == _period)
                .ToList();
            return Convert.ToInt32(period[0].ProjectPeriodID);                        
        }
        private void exportExcel(List<List<string>> list)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1"); 
                //DataTable dt = ConvertDataTable(list);
                worksheet.Cell("A1").InsertTable(list, "List<List<string>>", true);
                worksheet.Columns().AdjustToContents();
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Chọn nơi lưu tệp Excel";
                    saveFileDialog.Filter = "Excel Workbooks (*.xlsx)|*.xlsx";
                    saveFileDialog.DefaultExt = "xlsx";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.FileName = $"BaoCao_{DateTime.Now:yyyyMMdd}.xlsx"; 
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        try
                        {
                            workbook.SaveAs(filePath);

                            MessageBox.Show("Xuất tệp Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Đã xảy ra lỗi khi lưu tệp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            List<List<string>> result = new List<List<string>>();
            switch (cbbFilter.SelectedIndex)
            {
                case 0:
                    result = ReportStudentGrade(GetPeriodID());
                    break;
                case 1:
                    result = ReportLectureStudent(GetPeriodID());
                    break;
                default:
                    break;
            }
            if (result.Count > 0)
                exportExcel(result);
        }

        private void pnlDashboard_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.DashboardAdmin_W_A1(_context, _Account);
            PeriodManagement.ShowDialog();
            this.Close();
        }

        private void pnlProjects_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.ProjectPeriodManagement_W_A2(_context, _Account);
            PeriodManagement.ShowDialog();
            this.Close();
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.User_Management_W_A3(_context, _Account);
            PeriodManagement.ShowDialog();
            this.Close();
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
            var PeriodManagement = new Forms.Global_Announcements_W_A4(_context, _Account);
            PeriodManagement.ShowDialog();
            this.Close();
        }

        private void panel4_DoubleClick(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muón đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                Application.Restart();
                this.Close();
            }
        }
    }
}
