using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class ProjectTasksModel
    {
        public int TaskID { get; set; }
        public int ProjectID { get; set; }
        public int CreatorID { get; set; }
        public int AssignedToID { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public byte IsCompleted { get; set; }

    }
}
