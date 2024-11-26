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
using SW.Domain.Dto.Request.Update;

namespace SW.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Authorize]
public class UserDataController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserDataService _service;
    private readonly ITokenHelperService _tokenHelper;

    public UserDataController(IMapper mapper, IUserDataService service, ITokenHelperService tokenHelper)
    {
        this._mapper = mapper;
        this._service = service;
        this._tokenHelper = tokenHelper;
    }

    [HttpGet]
    [Route("")]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UserDataResponseDto>>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<UserDataResponseDto>>))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ApiResponse<IEnumerable<UserDataResponseDto>>))]
    public async Task<IActionResult> GetAll([FromQuery] UserDataQueryFilter filter)
    {
        var entities = await _service.GetPaged(filter);
        var dtos = _mapper.Map<IEnumerable<UserDataResponseDto>>(entities);
        var metaDataResponse = new MetaDataResponse(
            entities.TotalCount,
            entities.CurrentPage,
            entities.PageSize
        );
        var response = new ApiResponse<IEnumerable<UserDataResponseDto>>(data: dtos, meta: metaDataResponse);
        return Ok(response);
    }

    [HttpGet]
    [Route("Self")]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UserDataResponseDto>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<UserDataResponseDto>))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ApiResponse<UserDataResponseDto>))]
    public async Task<IActionResult> GetSelf()
    {
        var entities = await _service.GetById(_tokenHelper.GetUserDataId());
        var dtos = _mapper.Map<UserDataResponseDto>(entities);
        var response = new ApiResponse<UserDataResponseDto>(data: dtos);
        return Ok(response);
    }

    [HttpPut]
    [Route("")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UserDataResponseDto>))]
    public async Task<IActionResult> Update([FromBody] UserDataUpdateRequestDto requestDto)
    {
        try
        {
            Expression<Func<UserData, bool>> filter = x => x.Id == _tokenHelper.GetUserDataId();
            var existInfo = await _service.Exist(filter);

            if (!existInfo)
                return BadRequest("No se encontro ningununa información de usuario");

            var entity = await _service.GetById(_tokenHelper.GetUserDataId());

            var newEntity = _mapper.Map<UserData>(requestDto);
            newEntity.IsDeleted = false;
            newEntity.Id = entity.Id;
            newEntity.LastModifiedBy = _tokenHelper.GetUserName();
            newEntity.LastModifiedDate = DateTime.Now;
            newEntity.Code = entity.Code;

            await _service.Update(newEntity);
            var dto = _mapper.Map<UserDataResponseDto>(newEntity);
            var response = new ApiResponse<UserDataResponseDto>(data: dto);
            return Ok(response);
        }
        catch (Exception ex)
        {

            throw new LogicBusinessException(ex);
        }
    }
}