using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class ProjectFeedbackModel
    {
        public int FeedbackID { get; set; }
        public int ProjectID { get; set; }
        public int SenderID { get; set; }
        public string Content { get; set; }
        public string AttachmentFile { get; set; }
        public DateTime FeedbackDate { get; set; }

    }
}
