using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SW.Common.Interfaces.Entities;

namespace SW.Common.Interfaces.Repositories;
public interface IDeleteRepository<T> where T : IBaseQueryable
{
    Task<int> Delete(int id);
    Task<int> DeleteRange(IEnumerable<int> idList);
    Task<int> DeleteBy(Expression<Func<T, bool>> filter);
}
