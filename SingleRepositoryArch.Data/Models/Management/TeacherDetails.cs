using SingleRepositoryArch.Data.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingleRepositoryArch.Data.Models.Management
{
    public class TeacherDetails : TBaseEntity<string>
    {
        public TeacherDetails()
        {
            Id = Guid.NewGuid().ToString();
        }
        public byte? Gender { get; set; }
        public bool? MaritalStatus { get; set; }
        public short ChildernNumber { get; set; }
        public byte Age { get; set; }

        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
