using BTN_QLDA_12_.Models.Lecturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class TopicRegistrations
    {
        public int RegistrationID { get; set; }
        public int TopicID { get; set; }
        public int StudentID { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
        public string RejectionReason { get; set; }
        public virtual Topics Topic { get; set; }
        public virtual User Student { get; set; }
    }
    public enum TopicRegistrationsStatus
    {
        Pending,
        Approved,
        Rejected
    }
}
