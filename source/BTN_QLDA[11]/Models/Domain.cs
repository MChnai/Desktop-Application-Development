using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_11_.Models
{
    internal class Domain
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Domain() { }
        public Domain(string ID, string name)
        {
            this.ID = ID;
            this.Name = name;
        }
    }
}
