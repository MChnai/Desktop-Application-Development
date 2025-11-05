using BTN_QLDA_12_.Models.Admin;
using BTN_QLDA_12_.Models.Lecturer;
using BTN_QLDA_12_.Models.Student;
using BTN_QLDA_12_.Models.User_Role;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BTN_QLDA_12_.Models
{
    public class ProjectManagement : DbContext
    {
        public DbSet<Class> classes {  get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<User> users {  get; set; }
        public DbSet<Announcements> Announcements { get; set; }
        public DbSet<ProjectPeriods> ProjectsPeriods{ get; set; }
        public DbSet<RubricCriteria> RubricCriteria{ get; set; }
        public DbSet<Rubrics> Rubrics{ get; set; }
        public DbSet<Notifications> Notifications{ get; set; }
        public DbSet<FeedbackTemplates> FeedbackTemplates{ get; set; }
        public DbSet<LecturerAvailability> lecturerAvailabilities { get; set; }
        public DbSet<Topics> Topics{ get; set; }
        public DbSet<Appointments> Appointmentss{ get; set; }
        public DbSet<FinalSubmissions> FinalSubmissions{ get; set; }
        public DbSet<ProjectFeedback> projectFeedbacks{ get; set; }
        public DbSet<ProjectGrades> ProjectGrades{ get; set; }
        public DbSet<ProjectMembers> ProjectMembers{ get; set; }
        public DbSet<ProjectReports> ProjectReports{ get; set; }
        public DbSet<Projects> Projects{ get; set; }
        public DbSet<ProjectTasks> ProjectTaskss{ get; set; }
        public DbSet<ReportFiles> ReportFiles{ get; set; }
        public DbSet<TopicRegistrations> TopicRegistrations{ get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Ghi chú:
            // 1. Các ràng buộc CHECK (ví dụ: CHECK (Role IN ...)) và giá trị DEFAULT
            //    (ví dụ: DEFAULT N'Active') không được cấu hình trong OnModelCreating.
            //    - DEFAULT nên được thiết lập trong hàm khởi tạo (constructor) của lớp entity.
            //    - CHECK nên được xử lý bằng cách sửá dụng Enum trong C# hoặc logic validation.
            // 2. Tên entity C# được giả định là số ít (ví dụ: 'User' cho bảng 'Users').

            // --- Bảng Users, Class, Department ---

            modelBuilder.Entity<Class>()
                .ToTable("Class")
                .HasKey(c => c.Name);

            modelBuilder.Entity<Class>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_Class_Name") { IsUnique = true }));


            modelBuilder.Entity<Department>()
                .ToTable("Department")
                .HasKey(d => d.Name);

            modelBuilder.Entity<Department>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_Department_Name") { IsUnique = true }));

            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.UserCode)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_User_UserCode") { IsUnique = true }));

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_User_Email") { IsUnique = true }));

            modelBuilder.Entity<User>().Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<User>().Property(u => u.FullName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Role).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<User>().Property(u => u.Department).IsOptional().HasMaxLength(100); // Đây là cột FK
            modelBuilder.Entity<User>().Property(u => u.ClassName).IsOptional().HasMaxLength(50); // Đây là cột FK
            modelBuilder.Entity<User>().Property(u => u.Status).IsRequired().HasMaxLength(10);

            // Quan hệ User -> Department (dựa trên cột 'Name' không phải PK)
            modelBuilder.Entity<User>()
                .HasOptional(u => u.DepartmentInof) // Giả sử tên navigation prop là DepartmentEntity
                .WithMany(d => d.Users) // Giả sử Department có ICollection<User> Users
                .HasForeignKey(u => u.Department); // Cột FK là 'Department' (NVARCHAR)

            // Quan hệ User -> Class (dựa trên cột 'Name' không phải PK)
            modelBuilder.Entity<User>()
                .HasOptional(u => u.classInfo) // Giả sử tên navigation prop là ClassEntity
                .WithMany(c => c.Users) // Giả sử Class có ICollection<User> Users
                .HasForeignKey(u => u.ClassName);// Cột FK là 'ClassName' (NVARCHAR)

            // --- PHẦN 2: BẢNG QUẢN LÝ (ADMIN) ---

            modelBuilder.Entity<Rubrics>()
                .ToTable("Rubrics")
                .HasKey(r => r.RubricId);

            modelBuilder.Entity<Rubrics>().Property(r => r.Name).IsRequired().HasMaxLength(255);

            // Quan hệ Rubric -> User (Creator)
            modelBuilder.Entity<Rubrics>()
                .HasOptional(r => r.Creator)
                .WithMany(u => u.CreatedRubrics) // Giả sử User có ICollection<Rubric> CreatedRubrics
                .HasForeignKey(r => r.CreatorID);

            modelBuilder.Entity<RubricCriteria>()
                .ToTable("RubricCriteria")
                .HasKey(rc => rc.CriterionID);

            modelBuilder.Entity<RubricCriteria>().Property(rc => rc.CriterionName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<RubricCriteria>().Property(rc => rc.WeightPercentage).IsRequired().HasPrecision(5, 2);

            // Quan hệ RubricCriterion -> Rubric (ON DELETE CASCADE)
            modelBuilder.Entity<RubricCriteria>()
                .HasRequired(rc => rc.rubrics)
                .WithMany(r => r.RubricCriteria) // Giả sử Rubric có ICollection<RubricCriterion> Criteria
                .HasForeignKey(rc => rc.RubricID)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ProjectPeriods>()
                .ToTable("ProjectPeriods")
                .HasKey(pp => pp.ProjectPeriodID);

            modelBuilder.Entity<ProjectPeriods>().Property(pp => pp.Name).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<ProjectPeriods>().Property(pp => pp.StartDate).IsRequired().HasColumnType("date");
            modelBuilder.Entity<ProjectPeriods>().Property(pp => pp.EndDate).IsRequired().HasColumnType("date");
            modelBuilder.Entity<ProjectPeriods>().Property(pp => pp.RegistrationDeadline).IsOptional().HasColumnType("date");
            modelBuilder.Entity<ProjectPeriods>().Property(pp => pp.GradingDeadline).IsOptional().HasColumnType("date");
            modelBuilder.Entity<ProjectPeriods>().Property(pp => pp.Status).IsRequired().HasMaxLength(20);

            // Quan hệ ProjectPeriod -> Rubric (ON DELETE SET NULL)
            modelBuilder.Entity<ProjectPeriods>()
                .HasOptional(pp => pp.rubrics)
                .WithMany(r => r.ProjectPeriods) // Giả sử Rubric có ICollection<ProjectPeriod> ProjectPeriods
                .HasForeignKey(pp => pp.RubricID)
                .WillCascadeOnDelete(false); // EF sẽ không cascade, DB sẽ xử lý SET NULL

            modelBuilder.Entity<Announcements>()
                .ToTable("Announcements")
                .HasKey(a => a.AnnouncementID);

            modelBuilder.Entity<Announcements>().Property(a => a.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Announcements>().Property(a => a.Content).IsRequired().IsMaxLength(); // NVARCHAR(MAX)
            modelBuilder.Entity<Announcements>().Property(a => a.Type).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Announcements>().Property(a => a.TargetRole).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Announcements>().Property(a => a.TargetGroup).IsOptional().HasMaxLength(100);
            modelBuilder.Entity<Announcements>().Property(a => a.ScheduledTime).IsOptional().HasColumnType("datetime");
            modelBuilder.Entity<Announcements>().Property(a => a.SentTime).IsOptional().HasColumnType("datetime");

            // Quan hệ Announcement -> User (Sender)
            modelBuilder.Entity<Announcements>()
                .HasRequired(a => a.sender)
                .WithMany(u => u.SentAnnouncements) // Giả sử User có ICollection<Announcement> Announcements
                .HasForeignKey(a => a.SenderID)
                .WillCascadeOnDelete(false); // Không nên xóa User thì xóa thông báo

            // --- PHẦN 3: BẢNG LUỒNG GIẢNG VIÊN (GV) ---

            modelBuilder.Entity<Topics>()
                .ToTable("Topics")
                .HasKey(t => t.TopicID);

            modelBuilder.Entity<Topics>().Property(t => t.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Topics>().Property(t => t.Description).IsOptional().IsMaxLength();
            modelBuilder.Entity<Topics>().Property(t => t.Requirements).IsOptional().IsMaxLength();
            modelBuilder.Entity<Topics>().Property(t => t.MaxStudents).IsRequired();
            modelBuilder.Entity<Topics>().Property(t => t.Status).IsRequired().HasMaxLength(15);

            // Quan hệ Topic -> ProjectPeriod
            modelBuilder.Entity<Topics>()
                .HasRequired(t => t.ProjectPeriod)
                .WithMany(pp => pp.Topics) // Giả sử ProjectPeriod có ICollection<Topic> Topics
                .HasForeignKey(t => t.ProjectPeriodID)
                .WillCascadeOnDelete(false);

            // Quan hệ Topic -> User (Lecturer)
            modelBuilder.Entity<Topics>()
                .HasRequired(t => t.Lecturer)
                .WithMany(u => u.Topics) // Giả sử User có ICollection<Topic> Topics
                .HasForeignKey(t => t.LecturerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FeedbackTemplates>()
                .ToTable("FeedbackTemplates")
                .HasKey(ft => ft.TemplateID);

            modelBuilder.Entity<FeedbackTemplates>().Property(ft => ft.ShortcutName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<FeedbackTemplates>().Property(ft => ft.Content).IsRequired().IsMaxLength();

            // Quan hệ FeedbackTemplate -> User (Lecturer) (ON DELETE CASCADE)
            modelBuilder.Entity<FeedbackTemplates>()
                .HasRequired(ft => ft.Lecturer)
                .WithMany(u => u.FeedbackTemplates) // Giả sử User có ICollection<FeedbackTemplate> FeedbackTemplates
                .HasForeignKey(ft => ft.LecturerID)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<LecturerAvailability>()
                .ToTable("LecturerAvailability")
                .HasKey(la => la.AvailabilityID);

            //modelBuilder.Entity<LecturerAvailability>().Property(la => la.StartTime).IsRequired().HasColumnType("time");
            //modelBuilder.Entity<LecturerAvailability>().Property(la => la.EndTime).IsRequired().HasColumnType("time");

            // Quan hệ LecturerAvailability -> User (Lecturer) (ON DELETE CASCADE)
            modelBuilder.Entity<LecturerAvailability>()
                .HasRequired(la => la.Lecturer)
                .WithMany(u => u.Availabilities) // Giả sử User có ICollection<LecturerAvailability> Availabilities
                .HasForeignKey(la => la.LecturerID)
                .WillCascadeOnDelete(true);

            // --- PHẦN 4: BẢNG LUỒNG SINH VIÊN & TƯƠNG TÁC ---

            modelBuilder.Entity<TopicRegistrations>()
                .ToTable("TopicRegistrations")
                .HasKey(tr => tr.RegistrationID);

            modelBuilder.Entity<TopicRegistrations>().Property(tr => tr.RegistrationDate).IsRequired();
            modelBuilder.Entity<TopicRegistrations>().Property(tr => tr.Status).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<TopicRegistrations>().Property(tr => tr.RejectionReason).IsOptional().IsMaxLength();

            // Quan hệ TopicRegistration -> Topic
            modelBuilder.Entity<TopicRegistrations>()
                .HasRequired(tr => tr.Topic)
                .WithMany(t => t.TopicRegistrations) // Giả sử Topic có ICollection<TopicRegistration> Registrations
                .HasForeignKey(tr => tr.TopicID)
                .WillCascadeOnDelete(false); // Không nên xóa Topic khi xóa đăng ký

            // Quan hệ TopicRegistration -> User (Student)
            modelBuilder.Entity<TopicRegistrations>()
                .HasRequired(tr => tr.Student)
                .WithMany(u => u.Registrations) // Giả sử User có ICollection<TopicRegistration> Registrations
                .HasForeignKey(tr => tr.StudentID)
                .WillCascadeOnDelete(false); // Không nên xóa User khi xóa đăng ký

            // Ràng buộc UNIQUE(TopicID, StudentID)
            modelBuilder.Entity<TopicRegistrations>()
                .Property(tr => tr.TopicID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_TopicStudent", 1) { IsUnique = true }));

            modelBuilder.Entity<TopicRegistrations>()
                .Property(tr => tr.StudentID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_TopicStudent", 2) { IsUnique = true }));

            modelBuilder.Entity<Projects>()
                .ToTable("Projects")
                .HasKey(p => p.ProjectID);

            // Ràng buộc UNIQUE cho TopicID
            modelBuilder.Entity<Projects>()
                .Property(p => p.TopicID)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_Project_TopicID") { IsUnique = true }));

            modelBuilder.Entity<Projects>().Property(p => p.FinalGrade).IsOptional().HasPrecision(4, 2);
            modelBuilder.Entity<Projects>().Property(p => p.FinalComments).IsOptional().IsMaxLength();
            modelBuilder.Entity<Projects>().Property(p => p.GradeStatus).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Projects>().Property(p => p.IsPublicSample).IsRequired();

            // Quan hệ 1-1: Project -> Topic
            modelBuilder.Entity<Projects>()
                .HasRequired(p => p.Topic)
                .WithOptional(t => t.Project); // Giả sử Topic có 'public virtual Project Project { get; set; }'

            modelBuilder.Entity<ProjectMembers>()
                .ToTable("ProjectMembers")
                .HasKey(pm => new { pm.ProjectID, pm.StudentID }); // Khóa chính phức hợp

            modelBuilder.Entity<ProjectMembers>().Property(pm => pm.IsGroupLeader).IsRequired();

            // Quan hệ ProjectMember -> Project (ON DELETE CASCADE)
            modelBuilder.Entity<ProjectMembers>()
                .HasRequired(pm => pm.Project)
                .WithMany(p => p.ProjectMembers) // Giả sử Project có ICollection<ProjectMember> Members
                .HasForeignKey(pm => pm.ProjectID)
                .WillCascadeOnDelete(true);

            // Quan hệ ProjectMember -> User (Student) (ON DELETE CASCADE)
            modelBuilder.Entity<ProjectMembers>()
                .HasRequired(pm => pm.Student)
                .WithMany(u => u.ProjectMembers) // Giả sử User có ICollection<ProjectMember> ProjectMemberships
                .HasForeignKey(pm => pm.StudentID)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ProjectReports>()
                .ToTable("ProjectReports")
                .HasKey(pr => pr.ReportID);

            modelBuilder.Entity<ProjectReports>().Property(pr => pr.Title).IsOptional().HasMaxLength(255);
            modelBuilder.Entity<ProjectReports>().Property(pr => pr.WorkDone).IsOptional().IsMaxLength();
            modelBuilder.Entity<ProjectReports>().Property(pr => pr.Difficulties).IsOptional().IsMaxLength();
            modelBuilder.Entity<ProjectReports>().Property(pr => pr.NextWeekPlan).IsOptional().IsMaxLength();
            modelBuilder.Entity<ProjectReports>().Property(pr => pr.Notes).IsOptional().IsMaxLength();
            modelBuilder.Entity<ProjectReports>().Property(pr => pr.SubmissionDate).IsRequired();

            // Quan hệ ProjectReport -> Project (ON DELETE CASCADE)
            modelBuilder.Entity<ProjectReports>()
                .HasRequired(pr => pr.Project)
                .WithMany(p => p.ProjectReports) // Giả sử Project có ICollection<ProjectReport> Reports
                .HasForeignKey(pr => pr.ProjectID)
                .WillCascadeOnDelete(true);

            // Quan hệ ProjectReport -> User (Submitter)
            modelBuilder.Entity<ProjectReports>()
                .HasRequired(pr => pr.Submitter)
                .WithMany(u => u.ProjectReports) // Giả sử User có ICollection<ProjectReport> SubmittedReports
                .HasForeignKey(pr => pr.SubmitterID)
                .WillCascadeOnDelete(false); // Không cascade khi xóa user

            modelBuilder.Entity<ReportFiles>()
                .ToTable("ReportFiles")
                .HasKey(rf => rf.FileID);

            modelBuilder.Entity<ReportFiles>().Property(rf => rf.FileName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<ReportFiles>().Property(rf => rf.FileURL).IsRequired().HasMaxLength(255);

            // Quan hệ ReportFile -> ProjectReport (ON DELETE CASCADE)
            modelBuilder.Entity<ReportFiles>()
                .HasRequired(rf => rf.ProjectReport)
                .WithMany(pr => pr.ReportFiles) // Giả sử ProjectReport có ICollection<ReportFile> Files
                .HasForeignKey(rf => rf.ReportID)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<ProjectFeedback>()
                .ToTable("ProjectFeedback")
                .HasKey(pf => pf.FeedbackID);

            modelBuilder.Entity<ProjectFeedback>().Property(pf => pf.Content).IsRequired().IsMaxLength();
            modelBuilder.Entity<ProjectFeedback>().Property(pf => pf.AttachmentFile).IsOptional().HasMaxLength(255);
            modelBuilder.Entity<ProjectFeedback>().Property(pf => pf.FeedbackDate).IsRequired();

            // Quan hệ ProjectFeedback -> Project (ON DELETE CASCADE)
            modelBuilder.Entity<ProjectFeedback>()
                .HasRequired(pf => pf.Project)
                .WithMany(p => p.ProjectFeedbacks) // Giả sử Project có ICollection<ProjectFeedback> Feedback
                .HasForeignKey(pf => pf.ProjectID)
                .WillCascadeOnDelete(true);

            // Quan hệ ProjectFeedback -> User (Sender)
            modelBuilder.Entity<ProjectFeedback>()
                .HasRequired(pf => pf.Sender)
                .WithMany(u => u.ProjectFeedbacks) // Giả sử User có ICollection<ProjectFeedback> SentFeedback
                .HasForeignKey(pf => pf.SenderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FinalSubmissions>()
                .ToTable("FinalSubmissions")
                .HasKey(fs => fs.SubmissionID);

            modelBuilder.Entity<FinalSubmissions>().Property(fs => fs.FileType).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<FinalSubmissions>().Property(fs => fs.FileName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<FinalSubmissions>().Property(fs => fs.FileURL).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<FinalSubmissions>().Property(fs => fs.SubmissionDate).IsRequired();

            // Quan hệ FinalSubmission -> Project
            modelBuilder.Entity<FinalSubmissions>()
                .HasRequired(fs => fs.Project)
                .WithMany(p => p.FinalSubmissions) // Giả sử Project có ICollection<FinalSubmission> FinalSubmissions
                .HasForeignKey(fs => fs.ProjectID)
                .WillCascadeOnDelete(false);

            // Quan hệ FinalSubmission -> User (Submitter)
            modelBuilder.Entity<FinalSubmissions>()
                .HasRequired(fs => fs.Submitter)
                .WithMany(u => u.FinalSubmissions) // Giả sử User có ICollection<FinalSubmission> FinalSubmissions
                .HasForeignKey(fs => fs.SubmitterID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectGrades>()
                .ToTable("ProjectGrades")
                .HasKey(pg => pg.ProjectGradeID);

            modelBuilder.Entity<ProjectGrades>().Property(pg => pg.Grade).IsRequired().HasPrecision(4, 2);

            // Quan hệ ProjectGrades -> Project (ON DELETE CASCADE)
            modelBuilder.Entity<ProjectGrades>()
                .HasRequired(pg => pg.Project)
                .WithMany(p => p.ProjectGrades) // Giả sử Project có ICollection<ProjectGrades> Grades
                .HasForeignKey(pg => pg.ProjectID)
                .WillCascadeOnDelete(true);

            // Quan hệ ProjectGrades -> RubricCriterion (ON DELETE CASCADE)
            modelBuilder.Entity<ProjectGrades>()
                .HasRequired(pg => pg.RubricCriterion)
                .WithMany(rc => rc.ProjectGrades) // Giả sử RubricCriterion có ICollection<ProjectGrades> ProjectGradess
                .HasForeignKey(pg => pg.CriterionID)
                .WillCascadeOnDelete(true);

            // Ràng buộc UNIQUE(ProjectID, CriterionID)
            modelBuilder.Entity<ProjectGrades>()
                .Property(pg => pg.ProjectID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_ProjectGrades_ProjectCriterion", 1) { IsUnique = true }));

            modelBuilder.Entity<ProjectGrades>()
                .Property(pg => pg.CriterionID)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("UQ_ProjectGrades_ProjectCriterion", 2) { IsUnique = true }));

            modelBuilder.Entity<ProjectTasks>()
                .ToTable("ProjectTaskss")
                .HasKey(pt => pt.TaskID);

            modelBuilder.Entity<ProjectTasks>().Property(pt => pt.TaskName).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<ProjectTasks>().Property(pt => pt.DueDate).IsOptional().HasColumnType("date");
            modelBuilder.Entity<ProjectTasks>().Property(pt => pt.IsCompleted).IsRequired();

            // Quan hệ ProjectTasks -> Project (ON DELETE CASCADE)
            modelBuilder.Entity<ProjectTasks>()
                .HasRequired(pt => pt.Project)
                .WithMany(p => p.ProjectTasks) // Giả sử Project có ICollection<ProjectTasks> Tasks
                .HasForeignKey(pt => pt.ProjectID)
                .WillCascadeOnDelete(true);

            // Quan hệ ProjectTasks -> User (Creator)
            //modelBuilder.Entity<ProjectTasks>()
            //    .HasRequired(pt => pt.Creator)
            //    .WithMany(u => u.ProjectTasks) // Giả sử User có ICollection<ProjectTasks> CreatedTasks
            //    .HasForeignKey(pt => pt.CreatorID)
            //    .WillCascadeOnDelete(false);

            // Quan hệ ProjectTasks -> User (AssignedTo) (ON DELETE SET NULL)
            modelBuilder.Entity<ProjectTasks>()
                .HasOptional(pt => pt.AssignedTo)
                .WithMany(u => u.ProjectTasks) // Giả sử User có ICollection<ProjectTasks> AssignedTasks
                .HasForeignKey(pt => pt.AssignedToID)
                .WillCascadeOnDelete(false); // DB sẽ xử lý SET NULL

            modelBuilder.Entity<Appointments>()
                .ToTable("Appointments")
                .HasKey(a => a.AppointmentID);

            modelBuilder.Entity<Appointments>().Property(a => a.StartTime).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Appointments>().Property(a => a.EndTime).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Appointments>().Property(a => a.Status).IsRequired().HasMaxLength(10);

            //// Quan hệ Appointments -> User (Lecturer)
            //modelBuilder.Entity<Appointments>()
            //    .HasRequired(a => a.Lecturer)
            //    .WithMany(u => u.Appointments) // Giả sử User có ICollection<Appointments> LecturerAppointments
            //    .HasForeignKey(a => a.LecturerID)
            //    .WillCascadeOnDelete(false);

            //// Quan hệ Appointments -> User (Student)
            //modelBuilder.Entity<Appointments>()
            //    .HasRequired(a => a.Student)
            //    .WithMany(u => u.Appointments) // Giả sử User có ICollection<Appointments> StudentAppointmentss
            //    .HasForeignKey(a => a.StudentID)
            //    .WillCascadeOnDelete(false); // Cần WillCascadeOnDelete(false) để tránh lỗi multiple cascade paths

            modelBuilder.Entity<Notifications>()
                .ToTable("Notifications")
                .HasKey(n => n.NotificationID);

            modelBuilder.Entity<Notifications>().Property(n => n.Content).IsRequired().IsMaxLength();
            modelBuilder.Entity<Notifications>().Property(n => n.LinkURL).IsOptional().HasMaxLength(255);
            modelBuilder.Entity<Notifications>().Property(n => n.IsRead).IsRequired();
            modelBuilder.Entity<Notifications>().Property(n => n.Timestamp).IsRequired();

            // Quan hệ Notifications -> User (Recipient) (ON DELETE CASCADE)
            modelBuilder.Entity<Notifications>()
                .HasRequired(n => n.Recipient)
                .WithMany(u => u.Notifications) // Giả sử User có ICollection<Notifications> Notificationss
                .HasForeignKey(n => n.RecipientID)
                .WillCascadeOnDelete(true);

            // Gọi phương thức base cuối cùng
            base.OnModelCreating(modelBuilder);
        }
    }
}
