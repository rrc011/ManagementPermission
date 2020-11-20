using AutoMapper;
using ManagementPermission.Application.Dto.Permission;
using ManagementPermission.Application.Dto.TypeOfPermission;
using ManagementPermission.Domain.Entities;

namespace ManagementPermission.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Permission, PermissionDto>();
            CreateMap<CreatePermissionDto, Permission>();
            CreateMap<UpdatePermissionDto, Permission>();
            CreateMap<TypeOfPermission, TypeOfPermissionDto>();
            CreateMap<CreateTypeOfPermissionDto, TypeOfPermission>();
            CreateMap<UpdateTypeOfPermission, TypeOfPermission>();
        }
    }
}
