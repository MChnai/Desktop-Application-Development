using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Admin
{
    public class NotificationsModel
    {
        public int NotificationID {  get; set; }
        public int RecipientID { get; set; }
        public string Content {  get; set; }
        public string LinkURL { get; set; }
        public byte IsRead { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
