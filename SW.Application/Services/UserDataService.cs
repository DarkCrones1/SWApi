using SW.Common.Entities;
using SW.Common.Interfaces.Services;
using SW.Domain.Dto.QueryFilters;
using SW.Domain.Entities;
using SW.Domain.Enumerations;
using SW.Domain.Interfaces;
using SW.Domain.Interfaces.Services;

namespace SW.Application.Services;

public class UserDataService : CrudService<UserData>, IUserDataService
{
    public UserDataService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<PagedList<UserData>> GetPaged(UserDataQueryFilter filter)
    {
        var result = await _unitOfWork.UserDataRepository.GetPaged(filter);
        var pagedItems = PagedList<UserData>.Create(result, filter.PageNumber, filter.PageSize);
        return pagedItems;
    }
}