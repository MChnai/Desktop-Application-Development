using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class FinalSubmissions
    {
        public int SubmissionID { get; set; }
        public int ProjectID { get; set; }
        public int SubmitterID { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string FileURL { get; set; }
        public DateTime SubmissionDate { get; set; }
        public virtual Projects Project { get; set; }
        public virtual Models.User Submitter { get; set; }
    }
}
