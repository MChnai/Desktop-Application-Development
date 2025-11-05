using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Admin
{
    public class ProjectPeriodsModel
    {
        public int ProjectPeriodID { get; set; }
        public string ProjectPeriodName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public DateTime GradingDeadline { get; set; }
        public string Status { get; set; }
        public int RubricID { get; set; }
    }
}
