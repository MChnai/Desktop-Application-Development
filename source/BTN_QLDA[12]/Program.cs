using BTN_QLDA_12_.Forms;
using BTN_QLDA_12_.Models;
using BTN_QLDA_12_.Models.User_Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTN_QLDA_12_
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ProjectManagement content = new ProjectManagement();

            UsersModel logInAccount = null;          
            using (var logInForm = new Login_W1(content))
            {
                if (logInForm.ShowDialog() == DialogResult.OK)
                {
                    logInAccount = logInForm.LoggedInAccount;
                }
            }
            if (logInAccount == null)
            {
                return;
            }
            if(logInAccount.Role == RoleAccount.Admin.ToString()) 
                Application.Run(new Forms.DashboardAdmin_W_A1(content, logInAccount));
            else if(logInAccount.Role == RoleAccount.Lecturer.ToString())
                Application.Run(new Forms.Lecturer_Dashboard_W_GV1(content, logInAccount));
            else
                Application.Run(new Forms.Student_Forms.Student_Dashboard_W_SV1(content, logInAccount));
        }
    }
}
