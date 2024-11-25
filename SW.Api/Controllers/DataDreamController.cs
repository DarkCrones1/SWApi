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
public class DataDreamController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IDataDreamService _service;
    private readonly ITokenHelperService _tokenHelper;

    public DataDreamController(IMapper mapper, IDataDreamService service, ITokenHelperService tokenHelper)
    {
        this._mapper = mapper;
        this._service = service;
        this._tokenHelper = tokenHelper;
    }

    [HttpGet]
    [Route("")]
    [AllowAnonymous]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<DataDreamResponseDto>>))]
    [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<DataDreamResponseDto>>))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ApiResponse<IEnumerable<DataDreamResponseDto>>))]
    public async Task<IActionResult> GetAll([FromQuery] DataDreamQueryFilter filter)
    {
        var entities = await _service.GetPaged(filter);
        var dtos = _mapper.Map<IEnumerable<DataDreamResponseDto>>(entities);
        var metaDataResponse = new MetaDataResponse(
            entities.TotalCount,
            entities.CurrentPage,
            entities.PageSize
        );
        var response = new ApiResponse<IEnumerable<DataDreamResponseDto>>(data: dtos, meta: metaDataResponse);
        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<DataDreamResponseDto>))]
    public async Task<IActionResult> Create([FromBody] DataDreamCreateRequestDto requestDto)
    {
        try
        {
            var entity = _mapper.Map<DataDream>(requestDto);
            entity.UserDataId = _tokenHelper.GetUserDataId();
            entity.CreatedBy = _tokenHelper.GetUserName();
            await _service.Create(entity);
            var dto = _mapper.Map<DataDreamResponseDto>(entity);
            var response = new ApiResponse<DataDreamResponseDto>(data: dto);
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new LogicBusinessException(ex);
        }
    }

    [HttpPut("{id:int}/EndTime")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<DataDreamResponseDto>))]
    public async Task<IActionResult> Update([FromRoute] int id)
    {
        try
        {   
            var oldEntity = await _service.GetById(id);

            oldEntity.LastModifiedBy = _tokenHelper.GetUserName();
            oldEntity.LastModifiedDate = DateTime.Now;
            oldEntity.EndTime = DateTime.Now;
            await _service.Update(oldEntity);

            var dto = _mapper.Map<DataDreamResponseDto>(oldEntity);
            var response = new ApiResponse<DataDreamResponseDto>(data: dto);
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw new LogicBusinessException(ex);
        }
    }
}