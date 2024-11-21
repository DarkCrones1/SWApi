using System.Linq.Expressions;
using System.Net;
using System.Security.Cryptography;
using SW.Api.Responses;
using SW.Common.Exceptions;
using SW.Common.Functions;
using SW.Common.Interfaces.Repositories;
using SW.Common.Interfaces.Services;
using SW.Domain.Dto.QueryFilters;
using SW.Domain.Dto.Request.Create;
using SW.Domain.Dto.Response;
using SW.Domain.Entities;
using SW.Domain.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SW.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UserAccountController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserAccountService _service;
    private readonly ITokenHelperService _tokenHelper;

    public UserAccountController(IMapper mapper, IUserAccountService service, ITokenHelperService tokenHelper)
    {
        this._mapper = mapper;
        this._service = service;
        this._tokenHelper = tokenHelper;
    }

    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UserAccountResponseDto>))]
    public async Task<IActionResult> CreateUser([FromBody] UserAccountCreateRequestDto requestDto)
    {
        try
        {
            Expression<Func<UserAccount, bool>> filterUserName = x => !x.IsDeleted!.Value && x.UserName == requestDto.UserName;

            var existUser = await _service.Exist(filterUserName);

            if (existUser)
                return BadRequest("Ya existe un perfil con este nombre de usuario");

            Expression<Func<UserAccount, bool>> filterEmail = x => !x.IsDeleted!.Value && x.Email == requestDto.Email;

            var existEmail = await _service.Exist(filterEmail);

            if (existEmail)
                return BadRequest("Ya existe un usuario con este correo electrónico");

            var entity = await PopulateUserAccount(requestDto);
            entity.Password = MD5Encrypt.GetMD5(requestDto.Password);
            await _service.CreateUser(entity);

            var result = _mapper.Map<UserAccountResponseDto>(entity);
            var response = new ApiResponse<UserAccountResponseDto>(result);
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new LogicBusinessException(ex);
        }
    }


    private async Task<UserAccount> PopulateUserAccount(UserAccountCreateRequestDto requestDto)
    {
        Expression<Func<UserAccount, bool>> filter = x => !x.IsDeleted!.Value && x.Email == requestDto.Email;

        var existUser = await _service.Exist(filter);

        var userAccount = _mapper.Map<UserAccount>(requestDto);

        var userData = _mapper.Map<UserData>(requestDto);

        userAccount.UserData.Add(userData);
        userData.UserAccount.Add(userAccount);

        return userAccount;
    }
}