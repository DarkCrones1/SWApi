using System.Linq.Expressions;
using SW.Common.Interfaces.Entities;
using SW.Common.QueryFilters;

namespace SW.Common.Interfaces.Repositories;

public interface IQueryRepository<T>  : IQueryExpresionFilterRepository<T>, IFirstOrDefaultRepository<T> where T : IBaseQueryable
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    //IEnumerable<T> GetBy(T entity);
}