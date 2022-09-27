namespace Core.Persistence.Repositories;

public interface IQuery<T> where T : class, IEntity, new()
{
    IQueryable<T> Query();
}