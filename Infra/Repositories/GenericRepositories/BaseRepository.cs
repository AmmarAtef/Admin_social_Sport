using Microsoft.EntityFrameworkCore;
using Sports_Admin_Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Sports_Admin_Core.Entities;
using Infra.EntityConfigurations;
using Sports_Admin_Core.Entities.BaseEntities;
using Infra.Data_Identity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Sports_Admin_Core.IRepositories.GenericRepository;

public class BaseRepository<TKey, T> : IRepository<TKey, T> where T: BaseEntity<TKey>
                                                            where TKey: struct
{
    protected readonly AdminSportsContext _dbContext;
    protected readonly DbSet<T> _dbSet;
    

    public DbSet<T> DbSet()
    {
        return _dbSet;
    }

    public BaseRepository(AdminSportsContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<T> CreateOneAsync(T entity)
    {
        var created = await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return created.Entity;
    }
    
    public T CreateOne(T entity)
    {
        var created = _dbSet.Add(entity);
        _dbContext.SaveChanges();
        return created.Entity;
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression);
    }
    
    public IEnumerable<T> Find(Expression<Func<T, bool>> expression, int totalRecordsToReturn)
    {
        return _dbSet.Where(expression).OrderBy(x => x.Id).Take(totalRecordsToReturn);
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression,  params string[] propertySelectors)
    {
        var result = _dbSet.Where(expression);
        
        foreach (var property in propertySelectors)
            result = result.Include(property).AsSplitQuery();
        

        return result;
    }

    public T UpdateOne(T entity)
    {
        var res = _dbSet.Update(entity);
        _dbContext.SaveChanges();
        return res.Entity;
    }

    public void UpdateRange(List<T> entities)
    {
        _dbSet.UpdateRange(entities);
        _dbContext.SaveChanges();
    }

    public void Free()
    {
        _dbSet.RemoveRange(_dbSet);
        _dbContext.SaveChanges();
    }

    public int DeleteAllWhere(Expression<Func<T, bool>> expression)
    {
        var entities = Find(expression);
        var count = entities.Count();
        _dbSet.RemoveRange(entities);
        _dbContext.SaveChanges();
        return count;
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.AsNoTracking();
    }
    public IQueryable<TEntity> GetAllWthOutDeleted<TEntity>() where TEntity : T,IFullAuditedEntity
    {
        return Queryable.Where((IQueryable<TEntity>)_dbSet.AsNoTracking(), entity => entity.IsDeleted == false);
    }
    public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] navigationPropertyPaths)
    {

        var query = _dbSet.AsNoTracking();
        if(navigationPropertyPaths!=null)
        {
            foreach (var navigationpath in navigationPropertyPaths)
            {
              query=  query.Include(navigationpath);
            }
        }
        return query;
    }
    public IQueryable<T> FindIncluding(Expression<Func<T, bool>> Find, params Expression<Func<T, object>>[] navigationPropertyPaths)
    {
        var query = _dbSet.AsNoTracking();
        if (Find != null)
            query = query.Where(Find);
        if (navigationPropertyPaths != null)
        {
            foreach (var navigationpath in navigationPropertyPaths)
            {
                query = query.Include(navigationpath);
            }
        }
        return query;
    }
    public T UpdateModifedProperties(T entity)
    {
        object[] keys = GetKeys(entity);
        T OrignalEntity = _dbSet.Find(keys);
        if(OrignalEntity!=null)
         _dbContext.Entry(OrignalEntity).CurrentValues.SetValues(entity);
        _dbContext.SaveChanges();
        return OrignalEntity;
    }
    private string[] GetKeyNames(DbContext Odbcontext)
    {

        string[] keyNames = Odbcontext.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
        .Select(x => x.Name).ToArray();
        return keyNames;
    }
    private object[] GetKeys(T entity)
    {
        var keyNames = GetKeyNames(_dbContext);
        Type type = typeof(T);

        object[] keys = new object[keyNames.Length];
        for (int i = 0; i < keyNames.Length; i++)
        {
            keys[i] = type.GetProperty(keyNames[i]).GetValue(entity, null);
        }
        return keys;
    }

    public IQueryable<T> GetAllIncluding(Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
    {
        var query = _dbSet.AsNoTracking();
        if (include != null)
            query = include(query);

        return query;
    }

    public IQueryable<T> FindIncluding(Expression<Func<T, bool>> Find, Func<IQueryable<T>, IIncludableQueryable<T, object>> include, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        var query = _dbSet.AsNoTracking();
        if (Find != null)
         query=query.Where(Find);
        if(include!=null)
            query = include(query);

        return query;
    }

    public T SoftDelete(T entity) 
    {
        if (entity is IFullAuditedEntity)
        {
            object[] keys = GetKeys(entity);
            T OrignalEntity = _dbSet.Find(keys);
            (OrignalEntity as IFullAuditedEntity).IsDeleted = true;
           var DeletedEntity= UpdateModifedProperties(OrignalEntity);
            return DeletedEntity;
        }
        else
            throw new InvalidOperationException(" you Cannot excute SoftDelete for Entity need to  Implement IFullAuditedEntity");



    }

    public bool HardDelete(T entity)
    {
        object[] keys = GetKeys(entity);
        T OrignalEntity = _dbSet.Find(keys);
        _dbSet.Remove(OrignalEntity);
        _dbContext.SaveChanges();
        return true;
    }
}
