using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class ProjectMembers
    {
        public int ProjectID { get; set; }
        public int StudentID { get; set; }
        public bool IsGroupLeader { get; set; } = false;
        public virtual Projects Project { get; set; }
        public virtual User_Role.User Student { get; set; }
    }
}
