using SW.Common.Interfaces.Entities;

namespace SW.Common.Interfaces.Repositories;

public interface IQueryPagedRepository<T> where T : IBaseQueryable 
{
    Task<IEnumerable<T>> GetPaged(T entity);
}