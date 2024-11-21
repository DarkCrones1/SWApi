using System.Linq.Expressions;

using SW.Common.Interfaces.Repositories;
using SW.Domain.Dto.QueryFilters;
using SW.Domain.Entities;

namespace SW.Domain.Interfaces.Repositories;

public interface IUserAccountRepository : IQueryPagedRepository<ActiveUserAccount>, ICrudRepository<UserAccount>, IQueryFilterPagedRepository<UserAccount, UserAccountQueryFilter>
{
    Task<ActiveUserAccount> GetUserAccount(int id);
    Task<ActiveUserAccount> GetUserAccountToLogin(Expression<Func<ActiveUserAccount, bool>> filters);

    Task<IEnumerable<UserAccount>> GetPagedUserInfo(UserAccountQueryFilter filter);
}