using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class ProjectGrades
    {
        public int ProjectGradeID { get; set; }
        public int ProjectID { get; set; }
        public int CriterionID { get; set; }
        public decimal Grade { get; set; }
        public virtual Projects Project { get; set; }
        public virtual Admin.RubricCriteria RubricCriterion { get; set; }
    }
}
