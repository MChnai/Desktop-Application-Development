using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class TopicRegistrationsModel
    {
        public int RegistrationID { get; set; }
        public int TopicID { get; set; }
        public int StudentID { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; }
        public string RejectionReason { get; set; }

    }
}
