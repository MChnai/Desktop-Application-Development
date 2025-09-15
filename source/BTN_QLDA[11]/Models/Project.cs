using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_11_.Models
{
    internal class Project
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Lecture_Name { get; set; }
        public string Domain_Name { get; set; }
        public string Evalluation { get; set; }
        public string Description { get; set; }
        public string SchoolYear {  get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public Project() { }
        public Project(string id, string lectureName, string domainName, string name,  string description, string evaluation, string schoolYear)
        {
            this.ID = id;
            this.Name = name;
            this.Lecture_Name = lectureName;
            this.Domain_Name = domainName;
            this.Evalluation = evaluation;
            this.Description = description;
            this.SchoolYear = schoolYear;
        }
    }
}
