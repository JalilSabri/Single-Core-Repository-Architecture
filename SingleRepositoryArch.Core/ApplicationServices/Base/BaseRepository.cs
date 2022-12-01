using Microsoft.EntityFrameworkCore;
using SingleRepositoryArch.Core.Interfaces.Base;
using SingleRepositoryArch.Infra.Data;
using System.Linq.Expressions;

namespace SingleRepositoryArch.Core.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal readonly SingleRepoContext demodbContext;

        internal DbSet<TEntity> dbSet;

        public BaseRepository(SingleRepoContext _demodbContext)
        {
            demodbContext = _demodbContext;
            dbSet = demodbContext.Set<TEntity>();
        }

        public TEntity GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            return query.ToList();
        }

        public IEnumerable<TEntity> GetWithExpressions(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            //string includeProperties = ""
            //foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //{
            //    query = query.Include(includeProperty);
            //}

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public async Task<TEntity> GetByIdAsync(object Id)
        {
            return await dbSet.FindAsync(Id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> where)
        {
            return await dbSet.Where(where).FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            return await query.ToListAsync();
        }

        // if parameter is not empty, method should be override and use lambda expression
        //public  IEnumerable<TEntity> GetByFilter(string parameter)
        //{
        //    if (parameter.Equals(string.Empty))
        //        dbSet.AsEnumerable();
        //}

        public void Add(TEntity entity)
        {
            demodbContext.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentException("Entity is null");
            demodbContext.Attach(entity);
            demodbContext.Entry(entity).State = EntityState.Modified;

            #region .:| Manual Modifing -> Concurrency Issue |:.

            //demodbContext.Entry(entity).Members.Select(ent =>
            //{
            //    var entityName = ent.Metadata.Name;
            //    string entityFullName = ent.Metadata.ClrType.FullName;
            //    if (ent is Microsoft.EntityFrameworkCore.ChangeTracking.ReferenceEntry)
            //    {
            //        demodbContext.Attach(((Microsoft.EntityFrameworkCore.ChangeTracking.ReferenceEntry)ent).TargetEntry.Entity);
            //        ((Microsoft.EntityFrameworkCore.ChangeTracking.ReferenceEntry)ent).TargetEntry.State = EntityState.Modified;
            //    }
            //    return ent;
            //}).ToList();

            #endregion
        }

        public void Delete(object id)
        {
            var entity = GetById(id);
            if (entity == null) throw new Exception("Entity is not found");
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            if (demodbContext.Entry(entity).State == EntityState.Detached)
                dbSet.Attach(entity);
            dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> lstEntities = GetList(where);
            foreach (TEntity ent in lstEntities)
                dbSet.Remove(ent);
        }

        public void Delete(Expression<Func<TEntity, bool>> where = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            //this method must be corrected and completed, it doesn't work correctly.
            IQueryable<TEntity> query = dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            var lstEntities = query.ToList();
            foreach (TEntity ent in lstEntities)
                dbSet.Remove(ent);
        }

        public void Commit()
        {
            demodbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return demodbContext.SaveChangesAsync();
        }

    }
}
