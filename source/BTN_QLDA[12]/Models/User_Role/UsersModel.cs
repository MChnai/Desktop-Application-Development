using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.User_Role
{
    public class UsersModel
    {
        public int UserId {  get; set; }
        public string UserCode { get; set; }
        public string Mail {  get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Role {  get; set; }
        public string Department { get; set; }
        public string ClassName { get; set; }
        public double? GPA { get; set; } = 0;
    }
}
