using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;

namespace BTN_QLDA_12_.Forms.Admin_Forms
{
    public partial class ProjectPeriodDetail_W_A2_Detail : Form
    {
        ProjectManagement _context;
        List<Rubrics> list;
        public ProjectPeriodDetail_W_A2_Detail(ProjectManagement context)
        {
            InitializeComponent();
            _context = context;
            GetRubbic();
        }
        private void GetRubbic()
        {
            list = new List<Rubrics>();
            list = _context.Rubrics.ToList();
            foreach(Rubrics rubric in list)
                cbbRubrics.Items.Add(rubric.Name);
        }
        private int GetRubicID(string name)
        {
            Rubrics item = list.Find(r => r.Name == name);
            return item.RubricId;
        }
        private void SaveNewPeriod()
        {
            int rubricID = GetRubicID(cbbRubrics.Text);
            string periodName = txtName.Text;
            string status = cbbStatus.Text;
            DateTime dateStart = dtpdateStart.Value;
            DateTime dateEnd = dtpDateEnd.Value;
            DateTime dateEndSign = dtpDateEndSign.Value;
            DateTime dateEndGrading = dtpDateEndGrading.Value;

            var period = new ProjectPeriods
            {
                Name = periodName,
                StartDate = dateStart,
                EndDate = dateEnd,
                RegistrationDeadline = dateEndSign,
                GradingDeadline = dateEndGrading,
                Status = status,
                RubricID = rubricID,
            };

            _context.ProjectsPeriods.Add(period);
            _context.SaveChanges();

            MessageBox.Show("Đã thêm đợt đò án mới thành công");
        }
        private bool CheckInfo()
        {
            if(txtName.Text == string.Empty ||
                cbbStatus.Text == string.Empty ||
                cbbRubrics.Text == string.Empty ||
                dtpdateStart.Value > dtpDateEnd.Value ||
                dtpDateEndSign.Value > dtpDateEndGrading.Value ||
                dtpDateEnd.Value < dtpDateEndSign.Value)
            {
                MessageBox.Show("Thông tin không hợp lý!!! Vui lòng kiểm tra lại.");
                return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(!CheckInfo()) 
                { return; }
            SaveNewPeriod();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
