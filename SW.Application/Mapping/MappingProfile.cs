using AutoMapper;
using SW.Common.Helpers;
using SW.Domain.Dto.QueryFilters;
using SW.Domain.Dto.Request.Create;
using SW.Domain.Dto.Request.Update;
using SW.Domain.Dto.Response;
using SW.Domain.Entities;
using SW.Domain.Enumerations;

namespace SW.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Response

        CreateMap<UserAccount, UserAccountResponseDto>()
        .ForMember(
            dest => dest.UserName,
            opt => opt.MapFrom(src => src.UserName)
        ).ForMember(
            dest => dest.IsDeleted,
            opt => opt.MapFrom(src => src.IsDeleted)
        ).AfterMap(
            (src, dest) =>
            {
                var userData = src.UserData.FirstOrDefault() ?? new UserData();
                dest.UserDataId = userData.Id;
                dest.FullName = userData.FullName;
                dest.Phone = userData.Phone!;
                dest.CellPhone = userData.CellPhone;
            }
        );

        CreateMap<UserData, UserDataResponseDto>()
        .ForMember(
            dest => dest.GenderName,
            opt => opt.MapFrom(src => EnumHelper.GetDescription<Gender>((Gender)src.Gender!))
        );

        CreateMap<UserCommend, UserCommendResponseDto>().ForMember(
            dest => dest.Status,
            opt => opt.MapFrom(src => StatusDeletedHelper.GetStatusDeletedEntity(src.IsDeleted))
        ).ForMember(
            dest => dest.IsActive,
            opt => opt.MapFrom(src => !src.IsDeleted)
        ).ForMember(
            dest => dest.SleepQualityStatusName,
            opt => opt.MapFrom(src => EnumHelper.GetDescription<SleepQualityStatus>((SleepQualityStatus)src.SleepQualityStatus))
        );

        CreateMap<DataDream, DataDreamResponseDto>()
        .ForMember(
            dest => dest.SleepQualityStatusName,
            opt => opt.MapFrom(src => EnumHelper.GetDescription<SleepQualityStatus>((SleepQualityStatus)src.SleepQualityStatus))
        );

        // Create

        CreateMap<UserAccountCreateRequestDto, UserAccount>()
        .ForMember(
            dest => dest.IsDeleted,
            opt => opt.MapFrom(src => ValuesStatusPropertyEntity.IsNotDeleted)
        ).ForMember(
            dest => dest.IsActive,
            opt => opt.MapFrom(src => true)
        ).ForMember(
            dest => dest.IsAuthorized,
            opt => opt.MapFrom(src => true)
        ).ForMember(
            dest => dest.CreatedDate,
            opt => opt.MapFrom(src => DateTime.Now)
        ).ForMember(
            dest => dest.Email,
            opt => opt.MapFrom(src => src.Email)
        ).ForMember(
            dest => dest.UserAccountType,
            opt => opt.MapFrom(src => (short)UserAccountType.Free)
        );

        CreateMap<UserAccountCreateRequestDto, UserData>()
        .AfterMap(
            (src, dest) => 
            {
                dest.FirstName = "Asignar";
                dest.LastName = "Asignar";
                dest.CellPhone = "Asignar";
                dest.Code = Guid.NewGuid();
                dest.Gender = (short)Gender.Other;
                dest.IsDeleted = ValuesStatusPropertyEntity.IsNotDeleted;
                dest.CreatedDate = DateTime.Now;
            }
        );

        CreateMap<UserCommendCreateRequestDto, UserCommend>()
        .ForMember(
            dest => dest.Code,
            opt => opt.MapFrom(src => Guid.NewGuid())
        ).ForMember(
            dest => dest.CreatedDate,
            opt => opt.MapFrom(src => DateTime.Now)
        ).ForMember(
            dest => dest.IsDeleted,
            opt => opt.MapFrom(src => ValuesStatusPropertyEntity.IsNotDeleted)
        ).ForMember(
            dest => dest.CreatedBy,
            opt => opt.MapFrom(src => "admin")
        );

        CreateMap<DataDreamCreateRequestDto, DataDream>()
        .ForMember(
            dest => dest.Code,
            opt => opt.MapFrom(src => Guid.NewGuid())
        ).ForMember(
            dest => dest.CreatedDate,
            opt => opt.MapFrom(src => DateTime.Now)
        );
        // .ForMember(
        //     dest => dest.StartTime,
        //     opt => opt.MapFrom(src => DateTime.Now)
        // ).ForMember(
        //     dest => dest.EndTime,
        //     opt => opt.MapFrom(src => DateTime.Now)
        // );

        // Update

        CreateMap<UserDataUpdateRequestDto, UserData>();

        CreateMap<DataDreamUpdateRequestDto, DataDream>();

        // QueryFilter

        CreateMap<UserDataQueryFilter, UserData>();

        CreateMap<UserCommendQueryFilter, UserCommend>();

        CreateMap<DataDreamQueryFilter, DataDream>();
    }
}