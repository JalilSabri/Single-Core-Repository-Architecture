using SingleRepositoryArch.Core.Interfaces.Base;
using System.Linq.Expressions;

namespace SingleRepositoryArch.Core.ApplicationServices.Base
{

    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {

        IBaseRepository<TEntity> baseRepository;

        public BaseService(IBaseRepository<TEntity> _BaseRepository)
        {
            baseRepository = _BaseRepository;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return baseRepository.GetAll();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            return baseRepository.GetAllAsync();
        }

        public virtual TEntity GetById(object Id)
        {
            return baseRepository.GetById(Id);
        }

        public virtual Task<TEntity> GetByIdAsync(object Id)
        {
            return baseRepository.GetByIdAsync(Id);
        }

        public virtual TEntity GetFirst(Expression<Func<TEntity, bool>> where)
        {
            return baseRepository.GetFirst(where);
        }

        public IEnumerable<TEntity> GetWithExpressions(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            return baseRepository.GetWithExpressions(where, orderBy, includes);
        }

        public virtual Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> where)
        {
            return baseRepository.GetFirstAsync(where);
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where = null)
        {
            return baseRepository.GetList(where);
        }

        public virtual Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> where = null)
        {
            return baseRepository.GetListAsync(where);
        }

        public virtual void Add(TEntity entity)
        {
            baseRepository.Add(entity);
            Commit();
        }

        public virtual void Update(TEntity entity)
        {
            baseRepository.Update(entity);
            Commit();
        }

        public virtual void Delete(object Id)
        {
            baseRepository.Delete(Id);
            Commit();
        }

        public virtual void Delete(TEntity entity)
        {
            baseRepository.Delete(entity);
            Commit();
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            baseRepository.Delete(where);
            Commit();
        }

        public void Commit()
        {
            baseRepository.Commit();
        }

        public Task<int> CommitAsync()
        {
            return baseRepository.CommitAsync();
        }

        public void Delete(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            baseRepository.Delete(where, orderBy, includes);
            Commit();
        }

        #region Dispose

        //It needs to research that classes are inherited from this class , should inherit from IDisposable and then Implement :
        //protected bool disposed = false;
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        db.Dispose();
        //    }

        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        #endregion

    }
}
