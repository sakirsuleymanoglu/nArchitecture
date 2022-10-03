using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories;

public interface IRepository<TEntity> : IQuery<TEntity> where TEntity : class, IEntity, new()
{
    TEntity? Get(Expression<Func<TEntity, bool>> predicate);

    IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                         int index = 0, int size = 10,
                         bool enableTracking = true);

    IPaginate<TEntity> GetListByDynamic(Dynamic.Dynamic dynamic,
                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                  int index = 0, int size = 10, bool enableTracking = true);

    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
}