using SingleRepositoryArch.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SingleRepositoryArch.Data.Models.Management
{
    public class Teacher : TBaseEntity<string>
    {
        public Teacher()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        public virtual TeacherDetails TeacherDetails { get; set; }
    }
}
