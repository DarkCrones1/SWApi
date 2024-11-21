using SW.Common.Entities;
using SW.Common.Interfaces.Services;
using SW.Domain.Dto.QueryFilters;
using SW.Domain.Entities;

namespace SW.Domain.Interfaces.Services;

public interface IUserDataService : ICrudService<UserData>
{
    Task<PagedList<UserData>> GetPaged(UserDataQueryFilter filter);
    // Task UpdateProfile(int userInfoId, string urlProfile, string userName);
}