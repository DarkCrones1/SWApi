using SW.Common.Entities;
using SW.Common.Interfaces.Services;
using SW.Domain.Dto.QueryFilters;
using SW.Domain.Entities;
using SW.Domain.Enumerations;
using SW.Domain.Interfaces;
using SW.Domain.Interfaces.Services;

namespace SW.Application.Services;

public class DataDreamService : CrudService<DataDream>, IDataDreamService
{
    public DataDreamService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<PagedList<DataDream>> GetPaged(DataDreamQueryFilter filter)
    {
        var result = await _unitOfWork.DataDreamRepository.GetPaged(filter);
        var pagedItems = PagedList<DataDream>.Create(result, filter.PageNumber, filter.PageSize);
        return pagedItems;
    }
}