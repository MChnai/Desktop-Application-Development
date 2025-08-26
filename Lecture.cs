using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_4_
{
    internal class Lecture
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Mail  { get; set; }
        public string PhoneNum { get; set; }
        public DateTime DateBirthh { get; set; }
        public Lecture() { }
        public Lecture(string id, string Name, string Mail,  string PhoneNum, DateTime DateBirthh)
        {
            this.ID = id;
            this.Name = Name;
            this.Mail = Mail;
            this.PhoneNum = PhoneNum;
            this.DateBirthh = DateBirthh;
        }
    }
}
