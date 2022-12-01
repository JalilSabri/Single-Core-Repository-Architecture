using SingleRepositoryArch.Core.ApplicationServices.Base;
using SingleRepositoryArch.Core.Interfaces.Base;
using SingleRepositoryArch.Core.Interfaces.Management;
using SingleRepositoryArch.Data.Models.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleRepositoryArch.Core.ApplicationServices.Management
{
    public class SemesterService : BaseService<Semester>, ISemesterService
    {
        public SemesterService(IBaseRepository<Semester> _BaseRepository) : base(_BaseRepository)
        {
        }
    }
}
