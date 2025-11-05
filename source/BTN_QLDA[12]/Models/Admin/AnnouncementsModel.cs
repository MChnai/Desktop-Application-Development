using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Admin
{
    public class AnnouncementsModel
    {
        public int AnnouncementID { get; set; }
        public int SenderID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public string TargetRole { get; set; }
        public string TargetGroup { get; set; }
        public DateTime ScheduledTime { get; set; }
        public DateTime SentTime { get; set; }
    }
}
