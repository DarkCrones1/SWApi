// using System.Linq.Expressions;

// using Microsoft.EntityFrameworkCore;

// using SW.Domain.Entities;
// using SW.Domain.Interfaces.Repositories;
// using SW.Infrastructure.Data;
// using SW.Domain.Dto.QueryFilters;

// namespace SW.Infrastructure.Repositories;

// public class UserAccountRepository : CrudRepository<UserAccount>, IUserAccountRepository
// {
//     public UserAccountRepository(SWDbContext dbContext) : base(dbContext)
//     {
//     }

//     public async Task<IEnumerable<ActiveUserAccount>> GetPaged(ActiveUserAccount entity)
//     {
//         var query = _dbContext.ActiveUserAccount.AsQueryable();

//         if (entity.Id > 0)
//             query = query.Where(x => x.Id == entity.Id);

//         return await query.ToListAsync();
//     }

//     public async Task<IEnumerable<UserAccount>> GetPaged(UserAccountQueryFilter entity)
//     {
//         var query = _dbContext.UserAccount.AsQueryable();

//         if (entity.Id > 0)
//             query = query.Where(x => x.Id == entity.Id);

//         if (!string.IsNullOrEmpty(entity.UserName) && !string.IsNullOrWhiteSpace(entity.UserName))
//             query = query.Where(x => x.UserName.Contains(entity.UserName));

//         if (entity.IsDeleted.HasValue)
//             query = query.Where(x => x.IsDeleted == entity.IsDeleted);

//         query = query.Where(x => x.UserAccountType == 1);

//         return await query.ToListAsync();
//     }

//     public async Task<IEnumerable<UserAccount>> GetPagedCraftman(UserAccountQueryFilter entity)
//     {
//         var query = _dbContext.UserAccount.AsQueryable();

//         if (entity.Id > 0)
//             query = query.Where(x => x.Id == entity.Id);

//         if (!string.IsNullOrEmpty(entity.UserName) && !string.IsNullOrWhiteSpace(entity.UserName))
//             query = query.Where(x => x.UserName.Contains(entity.UserName));

//         if (entity.IsDeleted.HasValue)
//             query = query.Where(x => x.IsDeleted == entity.IsDeleted);

//         query = query.Where(x => x.AccountType == 2);

//         return await query.ToListAsync();
//     }

//     public async Task<IEnumerable<UserAccount>> GetPagedCustomer(UserAccountQueryFilter entity)
//     {
//         var query = _dbContext.UserAccount.AsQueryable();

//         if (entity.Id > 0)
//             query = query.Where(x => x.Id == entity.Id);

//         if (!string.IsNullOrEmpty(entity.UserName) && !string.IsNullOrWhiteSpace(entity.UserName))
//             query = query.Where(x => x.UserName.Contains(entity.UserName));

//         if (entity.IsDeleted.HasValue)
//             query = query.Where(x => x.IsDeleted == entity.IsDeleted);

//         query = query.Where(x => x.AccountType == 3);

//         return await query.ToListAsync();
//     }

//     public async Task<ActiveUserAccountCustomer> GetUserAccountCustomer(int id)
//     {
//         Expression<Func<ActiveUserAccountCustomer, bool>> filter = x => x.Id == id;
//         var entity = await GetUserAccountCustomerToLogin(filter);

//         return entity ?? new ActiveUserAccountCustomer();
//     }

//     public async Task<ActiveUserAccountCustomer> GetUserAccountCustomerToLogin(Expression<Func<ActiveUserAccountCustomer, bool>> filters)
//     {
//         var entity = await _dbContext.ActiveUserAccountCustomer
//         .Where(filters)
//         .AsNoTracking()
//         .FirstOrDefaultAsync();

//         return entity ?? new ActiveUserAccountCustomer();
//     }

//     public async Task<ActiveUserAccountCraftman> GetUserAccountCraftman(int id)
//     {
//         Expression<Func<ActiveUserAccountCraftman, bool>> filter = x => x.Id == id;
//         var entity = await GetUserAccountCraftmanToLogin(filter);

//         return entity ?? new ActiveUserAccountCraftman();
//     }

//     public async Task<ActiveUserAccountCraftman> GetUserAccountCraftmanToLogin(Expression<Func<ActiveUserAccountCraftman, bool>> filters)
//     {
//         var entity = await _dbContext.ActiveUserAccountCraftman
//         .Where(filters)
//         .AsNoTracking()
//         .FirstOrDefaultAsync();

//         return entity ?? new ActiveUserAccountCraftman();
//     }
// }