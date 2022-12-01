
using SingleRepositoryArch.Core.ApplicationServices.Base;
using SingleRepositoryArch.Core.Interfaces.Base;
using SingleRepositoryArch.Core.Interfaces.Management;
using SingleRepositoryArch.Core.ViewModels.Management;
using SingleRepositoryArch.Data.Models.Management;

namespace SingleRepositoryArch.Core.ApplicationServices.Management
{
    public class TeacherService : BaseService<Teacher>, ITeacherService
    {
        IBaseService<Teacher> baseService;

        public TeacherService(IBaseService<Teacher> _BaseService) : base(_BaseService)
        {
            baseService = _BaseService;
        }

        public override IEnumerable<Teacher> GetAll()
        {
            return new TeacherViewModel() { Teachers = baseService.GetAll().ToList() }.Teachers;
        }

        public override Teacher GetById(object Id)
        {
            return baseService.GetById(Id);
        }

        public override void Add(Teacher entity)
        {
            baseService.Add(entity);
            //base.Add(entity);
        }
       
        public override void Delete(object Id)
        {
            baseService.Delete(Id);
        }

        public override void Update(Teacher entity)
        {
            baseService.Update(entity);
        }

    }
}
