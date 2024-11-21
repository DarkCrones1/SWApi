using System.Linq.Expressions;
using SW.Common.Entities;
using SW.Common.Interfaces.Services;
using SW.Domain.Dto.QueryFilters;
using SW.Domain.Entities;

namespace SW.Domain.Interfaces.Services;

public interface IUserAccountService : ICrudService<UserAccount>
{
    Task<int> CreateUser(UserAccount user);
    Task<ActiveUserAccount> GetUserAccount(int id);
    Task<ActiveUserAccount> GetUserAccountToLogin(Expression<Func<ActiveUserAccount, bool>> filters);

    Task<PagedList<UserAccount>> GetPaged(UserAccountQueryFilter filter);
}