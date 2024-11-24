using System.Linq.Expressions;
using SW.Common.Interfaces.Repositories;
using SW.Domain.Dto.QueryFilters;
using SW.Domain.Entities;

namespace SW.Domain.Interfaces.Repositories;

public interface IUserCommendRepository : ICatalogBaseRepository<UserCommend>, IQueryFilterPagedRepository<UserCommend, UserCommendQueryFilter>
{
}