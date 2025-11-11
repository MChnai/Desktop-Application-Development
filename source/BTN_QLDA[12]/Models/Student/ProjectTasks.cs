using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class ProjectTasks
    {
        public int TaskID { get; set; }
        public int ProjectID { get; set; }
        [ForeignKey("Creator")]
        public int CreatorID { get; set; }
        public int? AssignedToID { get; set; }
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public virtual Projects Project { get; set; }
        public virtual BTN_QLDA_12_.Models.User Creator { get; set; }
        public virtual BTN_QLDA_12_.Models.User AssignedTo { get; set; }
    }
}
