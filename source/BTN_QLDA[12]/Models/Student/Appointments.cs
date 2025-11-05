using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTN_QLDA_12_.Models.User_Role;

namespace BTN_QLDA_12_.Models.Student
{
    public class Appointments
    {
        public int AppointmentID { get; set; }
        public int LecturerID { get; set; }
        public int StudentID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public virtual User Lecturer { get; set; } = null;
        public virtual User Student { get; set; } = null;
    }
    public enum AppointmentStatus
    {
        Booked,
        Cancelled
    }
}
