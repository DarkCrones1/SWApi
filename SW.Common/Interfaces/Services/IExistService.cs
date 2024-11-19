using System.Linq.Expressions;
using SW.Common.Interfaces.Entities;

namespace SW.Common.Interfaces.Services;

    public interface IExistService<T> where T : IBaseQueryable
    {
        Task<bool> Exist(Expression<Func<T, bool>> filters);
    }
