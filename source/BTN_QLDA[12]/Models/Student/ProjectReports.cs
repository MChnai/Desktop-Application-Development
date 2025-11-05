using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class ProjectReports
    {
        public int ReportID { get; set; }
        public int ProjectID { get; set; }
        public int SubmitterID { get; set; }
        public string Title { get; set; }
        public string WorkDone { get; set; }
        public string Difficulties { get; set; }
        public string NextWeekPlan { get; set; }
        public string Notes { get; set; }
        public DateTime SubmissionDate { get; set; }
        public virtual Projects Project { get; set; }
        public virtual User_Role.User Submitter { get; set; }
        public virtual ICollection<ReportFiles> ReportFiles { get; set; }
    }
}
