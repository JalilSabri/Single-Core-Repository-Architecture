using SingleRepositoryArch.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SingleRepositoryArch.Data.Models.Management
{
    public class Semester : TBaseEntity<string>
    {
        public Semester()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Finish Date")]
        public DateTime FinishDate { get; set; }
        public short Capacity { get; set; }

        public ICollection<SemesterSchedule> SemesterSchedules { get; set; }
    }
}
