using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_11_.Models
{
    internal class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateBirth { get; set; }
        public string Email {  get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        //Methods
        public Student() { }
        public Student(string id, string name, string gender, DateTime datebirth, string email, string phone, string address)
        {
            this.Address = address;
            this.ID = id;
            this.Name = name;
            this.Gender = gender;
            this.DateBirth = datebirth;
            this.Email = email;
            this.Phone = phone;
        }
    }
}
