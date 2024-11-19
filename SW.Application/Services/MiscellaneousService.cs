using SW.Common.Dtos.Response;
using SW.Common.Helpers;
using SW.Domain.Enumerations;
using SW.Domain.Interfaces.Services;

namespace SW.Application.Services;

public class MiscellaneousService : IMiscellaneousService
{
    // public async Task<IEnumerable<EnumValueResponseDto>> GetCartStatus()
    // {
    //     var lstItems = new List<EnumValueResponseDto>();

    //     lstItems = EnumHelper.GetEnumItems<CartStatus>().ToList();

    //     await Task.CompletedTask;

    //     return lstItems ?? new List<EnumValueResponseDto>();
    // }

}