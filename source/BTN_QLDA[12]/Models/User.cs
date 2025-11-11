using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.Student;
using BTN_QLDA_12_.Models.User_Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserCode { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string ClassName { get; set; }
        public string Status { get; set; }
        public double? GPA { get; set; } = 0;
        public virtual Department DepartmentInof { get; set; }
        public virtual Class classInfo { get; set; }
        public virtual ICollection<Rubrics> CreatedRubrics { get; set; }
        public virtual ICollection<Announcements> SentAnnouncements { get; set; }
        public virtual ICollection<Notifications> Notifications { get; set; }
        public virtual ICollection<Topics> Topics { get; set; }
        public virtual ICollection<FeedbackTemplates> FeedbackTemplates { get; set; }
        public virtual ICollection<LecturerAvailability> Availabilities { get; set; }
        public virtual ICollection<TopicRegistrations> Registrations { get; set; }
        public virtual ICollection<ProjectMembers> ProjectMembers { get; set; }
        public virtual ICollection<ProjectReports> ProjectReports { get; set; }
        public virtual ICollection<ProjectFeedback> ProjectFeedbacks { get; set; }
        public virtual ICollection<FinalSubmissions> FinalSubmissions { get; set; }
        public virtual ICollection<ProjectTasks> ProjectTasks { get; set; }
        public virtual ICollection<Appointments> Appointments { get; set; }
    }
    public enum RoleAccount
    {
        Admin,
        Lecturer,
        Student
    }
    public enum StatusType
    {
        Active,
        Locked
    }
}
