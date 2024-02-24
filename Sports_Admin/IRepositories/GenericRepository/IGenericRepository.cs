using Microsoft.EntityFrameworkCore.Query;
using Sports_Admin_Core.Entities.BaseEntities;
using System.Linq.Expressions;

namespace Sports_Admin_Core.IRepositories.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {

        Task<T> CreateOneAsync(T entity);
        T CreateOne(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression, params string[] propertySelectors);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression, int totalRecordsToReturn);
        T UpdateOne(T entity);
        void UpdateRange(List<T> entities);
        void Free();
        IQueryable<T> GetAll();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] navigationPropertyPaths);
        IQueryable<TEntity> GetAllWthOutDeleted<TEntity>() where TEntity : T, IFullAuditedEntity;

        IQueryable<T> GetAllIncluding(Func<IQueryable<T>, IIncludableQueryable<T, object>> include);
        IQueryable<T> FindIncluding(Expression<Func<T, bool>> Find, params Expression<Func<T, object>>[] navigationPropertyPaths);
        IQueryable<T> FindIncluding(Expression<Func<T, bool>> Find, Func<IQueryable<T>, IIncludableQueryable<T, object>> include, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        T UpdateModifedProperties(T entity);
        T SoftDelete(T entity);
        bool HardDelete(T entity);
        int DeleteAllWhere(Expression<Func<T, bool>> expression);
    }
}
