using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SW.Common.Interfaces.Entities;

namespace SW.Common.Interfaces.Repositories;
public interface ICrudRepository<T> : IQueryRepository<T>, ICreateRepository<T>, IUpdateRepository<T>, IDeleteRepository<T>, IExistRepository<T>, IQueryPagedRepository<T> where T : IBaseQueryable
{
}