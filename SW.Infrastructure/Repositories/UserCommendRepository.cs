using Microsoft.EntityFrameworkCore;

using SW.Domain.Entities;
using SW.Domain.Interfaces.Repositories;
using SW.Infrastructure.Data;
using SW.Domain.Dto.QueryFilters;

namespace SW.Infrastructure.Repositories;

public class UserCommendRepository : CatalogBaseRepository<UserCommend>, IUserCommendRepository
{
    public UserCommendRepository(SWDbContext sWDbContext) : base(sWDbContext)
    {
    }

    public override async Task<IEnumerable<UserCommend>> GetPaged(UserCommend entity)
    {
        var query = _dbContext.UserCommend.AsQueryable();

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<UserCommend>> GetPaged(UserCommendQueryFilter entity)
    {
        var query = _dbContext.UserCommend.AsQueryable();

        if (entity.SleepQualityStatus > 0)
            query = query.Where(x => x.SleepQualityStatus == entity.SleepQualityStatus);

        return await query.ToListAsync();
    }
}