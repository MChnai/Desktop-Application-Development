using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTN_QLDA_12_.Models.Lecturer;

namespace BTN_QLDA_12_.Models.Admin
{
    public class ProjectPeriods
    {
        public int ProjectPeriodID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public DateTime GradingDeadline { get; set; }
        public string Status { get; set; }
        public int? RubricID { get; set; }
        public Rubrics rubrics { get; set; }
        public virtual ICollection<Topics> Topics { get; set; }
    }
    public enum PeriodStatus
    {
        Đang_mở_đăng_ký,
        Đang_thực_hiện,
        Đã_đóng,
        Chưa_mở
    }
}
