using SW.Common.Entities;
using SW.Common.Interfaces.Services;
using SW.Domain.Dto.QueryFilters;
using SW.Domain.Entities;
using SW.Domain.Enumerations;
using SW.Domain.Interfaces;
using SW.Domain.Interfaces.Services;

namespace SW.Application.Services;

public class UserCommendService : CatalogBaseService<UserCommend>, IUserCommendService
{
    public UserCommendService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<PagedList<UserCommend>> GetPaged(UserCommendQueryFilter filter)
    {
        var result = await _unitOfWork.UserCommendRepository.GetPaged(filter);
        var pagedItems = PagedList<UserCommend>.Create(result, filter.PageNumber, filter.PageSize);
        return pagedItems;
    }
}