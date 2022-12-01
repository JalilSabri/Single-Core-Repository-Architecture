using SingleRepositoryArch.Core.ApplicationServices.Base;
using SingleRepositoryArch.Core.Interfaces.Base;
using SingleRepositoryArch.Core.Interfaces.Management;
using SingleRepositoryArch.Data.Models.Management;

namespace SingleRepositoryArch.Core.ApplicationServices.Management
{
    public class SemesterScheduleService : BaseService<SemesterSchedule>, ISemesterScheduleService
    {
        public SemesterScheduleService(IBaseRepository<SemesterSchedule> _BaseRepository) : base(_BaseRepository)
        {
        }
    }
}
