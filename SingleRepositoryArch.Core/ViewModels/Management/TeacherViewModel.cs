using SingleRepositoryArch.Data.Models.Management;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SingleRepositoryArch.Core.ViewModels.Management
{
    public class TeacherViewModel
    {

        #region .:| Model Members |:.

        public string Id { get; set; }

        [DisplayName("Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last name")]
        [DisplayName("Family")]
        public string LastName { get; set; }

        [DisplayName("Gender")]
        public byte? Gender { get; set; }

        [DisplayName("Marital Status")]
        public bool? MaritalStatus { get; set; }

        [DisplayName("Childern Number")]
        //[Phone]
        public short ChildernNumber { get; set; }

        [DisplayName("Age")]
        public byte Age { get; set; }

        #endregion

        #region .:| Extended |:.

        public TeacherViewModel(Teacher teacher)
        {
            Id = teacher.Id;
            FirstName = teacher.FirstName;
            LastName = teacher.LastName;
        }
        public TeacherViewModel()
        {

        }

        public MaritalStatusList MaritalStatusSelected { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }

        #endregion

    }

    

    public enum MaritalStatusList : byte
    {
        NoSelected = 0,
        Single = 1,
        Marrid = 2
    }
}
