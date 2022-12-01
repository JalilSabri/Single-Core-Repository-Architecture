using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SingleRepositoryArch.Core.Interfaces.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        public void Add(TEntity entity);

        public void Update(TEntity entity);

        public void Delete(object Id);

        public void Delete(TEntity entity);

        public void Delete(Expression<Func<TEntity, bool>> where);

        public void Delete(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        public TEntity GetById(object Id);

        public IEnumerable<TEntity> GetAll();

        public TEntity GetFirst(Expression<Func<TEntity, bool>> where);

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where = null);

        public IEnumerable<TEntity> GetWithExpressions(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);

        public Task<TEntity> GetByIdAsync(object Id);

        public Task<List<TEntity>> GetAllAsync();

        public Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> where);

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> where = null);

        public void Commit();

        public Task<int> CommitAsync();

    }

}
