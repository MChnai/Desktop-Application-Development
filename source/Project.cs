using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_4_
{
    internal class Project
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        public string Lecture_ID { get; set; }
        public string Lecture_Name { get; set; }
        public string Stdent_ID { get; set; }
        public string Stdent_Name { get; set; }
        public int Field_ID {  get; set; }
        public Project() { }
        public Project(int iD, string name, string lecture_ID, string lecture_Name, string stdent_ID, string stdent_Name, int field_ID)
        {
            ID = iD;
            Name = name;
            Lecture_ID = lecture_ID;
            Lecture_Name = lecture_Name;
            Stdent_ID = stdent_ID;
            Stdent_Name = stdent_Name;
            Field_ID = field_ID;
        }
    }
}
