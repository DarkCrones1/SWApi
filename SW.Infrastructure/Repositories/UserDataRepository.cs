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

        if (entity.Id > 0)
        query = query.Where(x => x.Id == entity.Id);

    if (entity.Code.HasValue)
        query = query.Where(x => x.Code == entity.Code);

    if (!string.IsNullOrEmpty(entity.Name) && !string.IsNullOrWhiteSpace(entity.Name))
            query = query.Where(x => x.FirstName.Contains(entity.Name) || x.LastName.Contains(entity.Name) || x.MiddleName!.Contains(entity.Name));

    if (!string.IsNullOrEmpty(entity.CellPhone))
        query = query.Where(x => x.CellPhone.Contains(entity.CellPhone));

    if (!string.IsNullOrEmpty(entity.Phone))
        query = query.Where(x => x.Phone!.Contains(entity.Phone));

    if (entity.BirthDate.HasValue)
        query = query.Where(x => x.BirthDate == entity.BirthDate);

    if (entity.IsDeleted.HasValue)
        query = query.Where(x => x.IsDeleted == entity.IsDeleted);

        return await query.ToListAsync();
    }
}