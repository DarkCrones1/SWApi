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
public class UserCommendController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserCommendService _service;
    private readonly ITokenHelperService _tokenHelper;

    public UserCommendController(IMapper mapper, IUserCommendService service, ITokenHelperService tokenHelper)
    {
        this._mapper = mapper;
        this._service = service;
        this._tokenHelper = tokenHelper;
    }

    [HttpGet]
    [Route("")]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UserCommendResponseDto>>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<UserCommendResponseDto>>))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ApiResponse<IEnumerable<UserCommendResponseDto>>))]
    public async Task<IActionResult> GetAll([FromQuery] UserCommendQueryFilter filter)
    {
        var entities = await _service.GetPaged(filter);
        var dtos = _mapper.Map<IEnumerable<UserCommendResponseDto>>(entities);
        var metaDataResponse = new MetaDataResponse(
            entities.TotalCount,
            entities.CurrentPage,
            entities.PageSize
        );
        var response = new ApiResponse<IEnumerable<UserCommendResponseDto>>(data: dtos, meta: metaDataResponse);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<UserCommendResponseDto>>))]
    public async Task<IActionResult> CreateCategory([FromBody] IEnumerable<UserCommendCreateRequestDto> requestDto)
    {
        try
        {
            var entity = _mapper.Map<IEnumerable<UserCommend>>(requestDto);
            await _service.CreateRange(entity);
            var dto = _mapper.Map<IEnumerable<UserCommendResponseDto>>(entity);
            var response = new ApiResponse<IEnumerable<UserCommendResponseDto>>(data: dto);
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new LogicBusinessException(ex);
        }
    }
}