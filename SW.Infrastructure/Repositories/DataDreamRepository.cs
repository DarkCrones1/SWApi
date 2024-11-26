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

        if (entity.Code.HasValue)
            query = query.Where(x => x.Code == entity.Code);

        if (entity.UserDataId > 0)
            query = query.Where(x => x.UserDataId == entity.UserDataId);

        if (entity.MinStartDay.HasValue)
            query = query.Where(x => x.StartTime >= entity.MinStartDay.Value);

        if (entity.MaxEndDay.HasValue)
            query = query.Where(x => x.EndTime <= entity.MaxEndDay.Value);

        if (entity.SleepQualityStatus > 0)
            query = query.Where(x => x.SleepQualityStatus == entity.SleepQualityStatus);

        if (entity.AverageHearthRate > 0)
            query = query.Where(x => x.AverageHearthRate == entity.AverageHearthRate);

        if (entity.AverageOxygenLevel.HasValue)
            query = query.Where(x => x.AverageOxygenLevel >= entity.AverageOxygenLevel.Value);

        if (entity.DeepSleepHours.HasValue)
            query = query.Where(x => x.DeepSleepHours >= entity.DeepSleepHours.Value);

        if (entity.Interruptions.HasValue)
            query = query.Where(x => x.Interruptions == entity.Interruptions.Value);

        return await query.ToListAsync();
    }
}