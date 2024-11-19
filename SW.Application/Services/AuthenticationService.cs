using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using SW.Common.Entities;
// using SW.Domain.Dto.QueryFilters;
using SW.Domain.Entities;
using SW.Domain.Interfaces;
using SW.Domain.Interfaces.Services;

namespace SW.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUnitOfWork unitOfWork;

    public AuthenticationService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> IsValidUser(string UserNameOrEmail, string password)
    {
        Expression<Func<UserAccount, bool>> filters = x =>
                (x.UserName == UserNameOrEmail || x.Email == UserNameOrEmail)
                && x.Password == password
                && x.IsActive
                && x.IsAuthorized
                && !x.IsDeleted!.Value;

        var result = await unitOfWork.UserAccountRepository.Exist(filters);

        return result;
    }
}