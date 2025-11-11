using BTN_QLDA_12_.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Lecturer
{
    public class Topics
    {
        public int TopicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public int ProjectPeriodID { get; set; }
        public int LecturerID { get; set; }
        public int MaxStudents { get; set; }
        public string Status { get; set; }
        public virtual Admin.ProjectPeriods ProjectPeriod { get; set; }
        public virtual User Lecturer { get; set; }
        public virtual ICollection<TopicRegistrations> TopicRegistrations { get; set; }
        public virtual ICollection<Projects> Project { get; set; } // 1-1
    }
    public enum TopicStatus
    {
        Còn_trống,
        Chờ_duyệt,
        Đã_đủ
    }
}
