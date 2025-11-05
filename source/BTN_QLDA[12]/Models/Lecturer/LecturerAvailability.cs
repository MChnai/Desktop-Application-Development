using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BTN_QLDA_12_.Models.Lecturer
{
    public class LecturerAvailability
    {
        public int AvailabilityID { get; set; }
        public int LecturerID { get; set; }
        public int DayOfWeek { get; set; }
        public Timer StartTime { get; set; }
        public Timer EndTime { get; set; }
        public string SlotDuration { get; set; }
        public virtual User_Role.User Lecturer { get; set; }
    }
}
