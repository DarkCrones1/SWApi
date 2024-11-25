using Microsoft.EntityFrameworkCore;

using SW.Domain.Entities;
using SW.Domain.Interfaces.Repositories;
using SW.Infrastructure.Data;
using SW.Domain.Dto.QueryFilters;

namespace SW.Infrastructure.Repositories;

public class DataDreamRepository : CrudRepository<DataDream>, IDataDreamRepository
{
    public DataDreamRepository(SWDbContext sWDbContext) : base(sWDbContext)
    {
    }

    public override async Task<IEnumerable<DataDream>> GetPaged(DataDream entity)
    {
        var query = _dbContext.DataDream.AsQueryable();

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<DataDream>> GetPaged(DataDreamQueryFilter entity)
    {
        var query = _dbContext.DataDream.AsQueryable();

        return await query.ToListAsync();
    }
}