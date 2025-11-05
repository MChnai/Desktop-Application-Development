using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Lecturer
{
    public class TopicsModel
    {
        public int TopicID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public int ProjectPeriodID { get; set; }
        public int LecturerID { get; set; }
        public int MaxStudents { get; set; }
        public string Status { get; set; }
    }

}
