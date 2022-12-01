using SingleRepositoryArch.Data.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingleRepositoryArch.Data.Models.Management
{
    public class SemesterSchedule : TBaseEntity<string>
    {
        public SemesterSchedule()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        [Display(Name = "Finish Time")]
        public string FinishTime { get; set; }

        [ForeignKey("Semester")]
        public string SemesterId { get; set; }
        public Semester Semester { get; set; }

        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
