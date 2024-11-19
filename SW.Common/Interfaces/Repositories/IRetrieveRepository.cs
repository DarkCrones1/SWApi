using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SW.Common.Interfaces.Entities;

namespace SW.Common.Interfaces.Repositories;

public interface IRetrieveRepository<T> : IQueryRepository<T>, IQueryPagedRepository<T> where T : IBaseQueryable
{

}