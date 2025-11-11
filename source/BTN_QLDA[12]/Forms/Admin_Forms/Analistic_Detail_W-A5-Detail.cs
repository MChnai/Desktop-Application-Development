using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.Admin;
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

namespace BTN_QLDA_12_.Forms.Admin_Forms
{
    public partial class Analistic_Detail_W_A5_Detail : Form
    {
        public string Period {  get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        ProjectManagement _context;
        public Analistic_Detail_W_A5_Detail(ProjectManagement context)
        {
            InitializeComponent();
            _context = context;
            LoadPeriod();
        }
        private void LoadPeriod()
        {
            List<ProjectPeriods> projectPeriods = new List<ProjectPeriods>();
            projectPeriods = _context.ProjectsPeriods.ToList();
            foreach (var p in projectPeriods)
                cbbPeriod.Items.Add(p.Name);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbbPeriod.Text == string.Empty )
            {
                MessageBox.Show("Hãy chọn đủ thông tin cho bộ lọc");
                return;
            }
            Period = cbbPeriod.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
