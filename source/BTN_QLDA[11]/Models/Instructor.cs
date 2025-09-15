using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_11_.Models
{
    internal class Instructor
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Instructor() { }
        public Instructor(string iD, string name, string gender, DateTime dateBirth, string email, string phone)
        {
            ID = iD;
            Name = name;
            Gender = gender;
            DateBirth = dateBirth;
            Email = email;
            Phone = phone;
        }
    }
}
