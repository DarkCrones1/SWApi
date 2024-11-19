using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SW.Common.Interfaces.Entities;

namespace SW.Common.Interfaces.Services;
public interface IUpdateService<T> where T : IBaseQueryable
{
    Task Update(T entity);
}