using Microsoft.EntityFrameworkCore;

using SW.Domain.Entities;
using SW.Domain.Interfaces.Repositories;
using SW.Infrastructure.Data;
using SW.Domain.Dto.QueryFilters;

namespace SW.Infrastructure.Repositories;

public class UserDataRepository : CrudRepository<UserData>, IUserDataRepository
{
    public UserDataRepository(SWDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<UserData>> GetPaged(UserData entity)
    {
        var query = _dbContext.UserData.AsQueryable();

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<UserData>> GetPaged(UserDataQueryFilter entity)
    {
        var query = _dbContext.UserData.AsQueryable();

        return await query.ToListAsync();
    }
}