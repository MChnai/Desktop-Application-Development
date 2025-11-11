using BTN_QLDA_12_.Models.Lecturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class ProjectsModel
    {
        public int ProjectID { get; set; }
        public int TopicID { get; set; }
        public decimal FinalGrade { get; set; }
        public string FinalComments { get; set; }
        public string GradeStatus { get; set; }
        public byte IsPublicSample { get; set; }
       
    }

}
