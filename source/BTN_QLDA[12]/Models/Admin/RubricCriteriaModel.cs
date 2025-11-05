using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Admin
{
    public class RubricCriteriaModel
    {
        public int CriterionID { get; set; }
        public int RubricID { get; set; }
        public string CriterionName { get; set; }
        public decimal WeightPercentage { get; set; }
    }
}
