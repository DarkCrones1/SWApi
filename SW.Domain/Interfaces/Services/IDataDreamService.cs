using SW.Common.Entities;
using SW.Common.Interfaces.Services;
using SW.Domain.Dto.QueryFilters;
using SW.Domain.Entities;

namespace SW.Domain.Interfaces.Services;

public interface IDataDreamService : ICrudService<DataDream>
{
    Task<PagedList<DataDream>> GetPaged(DataDreamQueryFilter filter);
}