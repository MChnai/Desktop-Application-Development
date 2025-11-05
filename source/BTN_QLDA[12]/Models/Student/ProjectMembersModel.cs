using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class ProjectMembersModel
    {
        public int ProjectID { get; set; }
        public int StudentID { get; set; }
        public byte IsGroupLeader { get; set; } = 0;

    }
}
