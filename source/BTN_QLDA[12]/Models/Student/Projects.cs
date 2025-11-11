using BTN_QLDA_12_.Models.Lecturer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models.Student
{
    public class Projects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }
        public int TopicID { get; set; }
        public decimal? FinalGrade { get; set; } = 0;
        public string FinalComments { get; set; }
        public string GradeStatus { get; set; }
        public bool IsPublicSample { get; set; } = false;
        public virtual Topics Topic { get; set; }
        public virtual ICollection<ProjectMembers> ProjectMembers { get; set; }
        public virtual ICollection<ProjectReports> ProjectReports { get; set; }
        public virtual ICollection<ProjectFeedback> ProjectFeedbacks { get; set; }
        public virtual ICollection<FinalSubmissions> FinalSubmissions { get; set; }
        public virtual ICollection<ProjectGrades> ProjectGrades { get; set; }
        public virtual ICollection<ProjectTasks> ProjectTasks { get; set; }
    }
    public enum ProjectGradeStatus
    {
        Draft,
        Submitted
    }
}
