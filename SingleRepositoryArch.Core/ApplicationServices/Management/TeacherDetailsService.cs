using SingleRepositoryArch.Core.ApplicationServices.Base;
using SingleRepositoryArch.Core.Interfaces.Base;
using SingleRepositoryArch.Core.Interfaces.Management;
using SingleRepositoryArch.Data.Models.Management;

namespace SingleRepositoryArch.Core.ApplicationServices.Management
{
    public class TeacherDetailsService : BaseService<TeacherDetails>, ITeacherDetailsService
    {
        IBaseService<TeacherDetails> baseService;

        public TeacherDetailsService(IBaseService<TeacherDetails> _BaseService) : base(_BaseService)
        {
            baseService = _BaseService;
        }
    }
}
