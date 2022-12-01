
namespace SingleRepositoryArch.Core.Interfaces.Base
{
    public interface IBaseService<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        
    }
}
