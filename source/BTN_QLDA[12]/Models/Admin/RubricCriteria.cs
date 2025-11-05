using BTN_QLDA_12_.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Admin
{
    public class RubricCriteria
    {
        public int CriterionID { get; set; }
        public int RubricID { get; set; }
        public string CriterionName { get; set; }
        public decimal WeightPercentage { get; set; }
        public Rubrics rubrics { get; set; }
        public virtual ICollection<ProjectGrades> ProjectGrades { get; set; }

    }
}
