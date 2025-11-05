using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTN_QLDA_12_.Models.User_Role;

namespace BTN_QLDA_12_.Models.Admin
{
    public class Rubrics
    {
        public int RubricId { get; set; }
        public string Name { get; set; }
        public int? CreatorID { get; set; }
        public User Creator { get; set; }
        public virtual ICollection<RubricCriteria> RubricCriteria { get; set; }
        public virtual ICollection<ProjectPeriods> ProjectPeriods { get; set; }
    }
}
