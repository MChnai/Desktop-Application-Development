using BTN_QLDA_12_.Models.User_Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Admin
{
    public class Notifications
    {
        public int NotificationID { get; set; }
        public int RecipientID { get; set; }
        public string Content { get; set; }
        public string LinkURL { get; set; } 
        public bool IsRead { get; set; } = false;
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public virtual User Recipient { get; set; }
    }
}
