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

        if (entity.Id > 0)
            query = query.Where(x => x.Id == entity.Id);

        if (entity.Code.HasValue)
            query = query.Where(x => x.Code == entity.Code);

        if (!string.IsNullOrEmpty(entity.Name))
            query = query.Where(x => x.Name.Contains(entity.Name));

        if (!string.IsNullOrEmpty(entity.Description))
            query = query.Where(x => x.Description!.Contains(entity.Description));

        if (entity.SleepQualityStatus > 0)
            query = query.Where(x => x.SleepQualityStatus == entity.SleepQualityStatus);

        if (entity.IsDeleted.HasValue)
            query = query.Where(x => x.IsDeleted == entity.IsDeleted);

        if (entity.RandomCommend == true)
            query = query.OrderBy(x => Guid.NewGuid());

        return await query.ToListAsync();
    }
}