namespace Core.Persistence.Repositories;

public interface IQuery<TEntity> where TEntity : class, IEntity, new()
{
    IQueryable<TEntity> Query();
}