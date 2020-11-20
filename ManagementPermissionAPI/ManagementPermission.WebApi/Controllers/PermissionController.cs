using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ManagementPermission.Application.Dto.Permission;
using ManagementPermission.Application.Interfaces.Repositories;
using ManagementPermission.Application.Parameters;
using ManagementPermission.Application.Wrappers;
using ManagementPermission.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManagementPermission.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<PermissionDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
        {
            var permissions = await _permissionRepository.GetPagedReponseAsync(filter.PageNumber, filter.PageSize, x => !x.IsDeleted);
            var permissionsViewModel = _mapper.Map<IEnumerable<PermissionDto>>(permissions);
            return Ok(new PagedResponse<IEnumerable<PermissionDto>>(permissionsViewModel, filter.PageNumber, filter.PageSize));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<PermissionDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var permissions = await _permissionRepository.GetByIdAsync(id);
            if (permissions == null) throw new Exception($"Permission Not Found.");
            var permissionsViewModel = _mapper.Map<PermissionDto>(permissions);
            return Ok(new Response<PermissionDto>(permissionsViewModel));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePermissionDto input)
        {
            var permissions = _mapper.Map<Permission>(input);
            permissions.Created = DateTime.Now;
            await _permissionRepository.AddAsync(permissions);
            return Ok(new Response<Permission>(permissions));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdatePermissionDto input)
        {
            var permissions = await _permissionRepository.GetByIdAsync(id);

            if (permissions == null)
            {
                throw new Exception($"Permission Not Found.");
            }
            else
            {
                permissions.Name = input.Name;
                permissions.LastName = input.LastName;
                permissions.TypeOfPermissionId = input.TypeOfPermissionId;
                permissions.LastModified = DateTime.Now;
                await _permissionRepository.UpdateAsync(permissions);
                return Ok(new Response<Permission>(permissions));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var permissions = await _permissionRepository.GetByIdAsync(id);
            if (permissions == null) throw new Exception($"Permission Not Found.");
            permissions.IsDeleted = true;
            await _permissionRepository.UpdateAsync(permissions);
            return Ok(new Response<int>(permissions.Id));
        }
    }
}
