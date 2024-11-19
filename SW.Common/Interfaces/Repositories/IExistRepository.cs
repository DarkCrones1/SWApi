using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SW.Common.Entities;
using System.Linq.Expressions;
using SW.Common.Interfaces.Entities;

namespace SW.Common.Interfaces.Repositories;

    public interface IExistRepository<T> where T : IBaseQueryable
    {
        Task<bool> Exist(Expression<Func<T, bool>> filters);
    }
