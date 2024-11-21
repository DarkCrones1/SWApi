using System.Linq.Expressions;
using SW.Common.Entities;
using SW.Common.Exceptions;
using SW.Domain.Dto.QueryFilters;
using SW.Domain.Entities;
using SW.Domain.Interfaces;
using SW.Domain.Interfaces.Services;

namespace SW.Application.Services;

public class UserAccountService : CrudService<UserAccount>, IUserAccountService
{
    public UserAccountService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<int> CreateUser(UserAccount user)
    {
        Expression<Func<UserAccount, bool>> filter = x => x.UserName == user.UserName && !x.IsDeleted!.Value;

        var userAccount = await _unitOfWork.UserAccountRepository.Exist(filter);

        if (userAccount)
            throw new BusinessException("El usuario ya existe, intente con otro nombre de usuario");

        await _unitOfWork.UserAccountRepository.Create(user);

        await _unitOfWork.SaveChangesAsync();
        return user.Id;
    }

    public async Task<ActiveUserAccount> GetUserAccount(int id)
    {
        var entity = await _unitOfWork.UserAccountRepository.GetUserAccount(id);
        return entity;
    }

    public async Task<ActiveUserAccount> GetUserAccountToLogin(Expression<Func<ActiveUserAccount, bool>> filters)
    {
        var entity = await _unitOfWork.UserAccountRepository.GetUserAccountToLogin(filters);
        return entity;
    }

    public async Task<PagedList<UserAccount>> GetPaged(UserAccountQueryFilter filter)
    {
        var result = await _unitOfWork.UserAccountRepository.GetPaged(filter);
        var pagedItems = PagedList<UserAccount>.Create(result, filter.PageNumber, filter.PageSize);
        return pagedItems;
    }

    
}