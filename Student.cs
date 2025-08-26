using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_4_
{
    internal class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public Student() { }
        public Student(int ID, string Name, string Mail)
        {
            this.ID = ID;
            this.Name = Name;
            this.Mail = Mail;
        }
    }
}
