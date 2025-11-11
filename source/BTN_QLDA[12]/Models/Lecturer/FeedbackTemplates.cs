using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Lecturer
{
    public class FeedbackTemplates
    {
        public int TemplateID { get; set; }
        public int LecturerID { get; set; }
        public string ShortcutName { get; set; }
        public string Content { get; set; }
        public virtual User Lecturer { get; set; }
    }
}
