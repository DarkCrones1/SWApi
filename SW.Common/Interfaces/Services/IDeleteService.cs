using System.Linq.Expressions;
using SW.Common.Interfaces.Entities;

namespace SW.Common.Interfaces.Services;
public interface IDeleteService<T> where T : IBaseQueryable
{
    Task<int> Delete(int id);
    Task<int> DeleteRange(IEnumerable<int> idList);
    Task<int> DeleteBy(Expression<Func<T, bool>> filter);
}
