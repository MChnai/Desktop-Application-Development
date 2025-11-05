using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class AppointmentsModel
    {
        public int AppointmentID { get; set; }
        public int LecturerID { get; set; }
        public int StudentID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }

    }
}
