using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ManagementPermission.Application.Dto.TypeOfPermission;
using ManagementPermission.Application.Interfaces.Repositories;
using ManagementPermission.Application.Parameters;
using ManagementPermission.Application.Wrappers;
using ManagementPermission.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ManagementPermission.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfPermissionController : ControllerBase
    {
        private readonly ITypeOfPermissionRepository _typeOfPermissionRepository;
        private readonly IMapper _mapper;

        public TypeOfPermissionController(ITypeOfPermissionRepository typeOfPermissionRepository, IMapper mapper)
        {
            _typeOfPermissionRepository = typeOfPermissionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedResponse<IEnumerable<TypeOfPermissionDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
        {
            var permissions = await _typeOfPermissionRepository.GetPagedReponseAsync(filter.PageNumber, filter.PageSize, x => !x.IsDeleted);
            var permissionsViewModel = _mapper.Map<IEnumerable<TypeOfPermissionDto>>(permissions);
            return Ok(new PagedResponse<IEnumerable<TypeOfPermissionDto>>(permissionsViewModel, filter.PageNumber, filter.PageSize));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Response<TypeOfPermissionDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            var permissions = await _typeOfPermissionRepository.GetByIdAsync(id);
            if (permissions == null) throw new Exception($"Type Of Permission Not Found.");
            var permissionsViewModel = _mapper.Map<TypeOfPermissionDto>(permissions);
            return Ok(new Response<TypeOfPermissionDto>(permissionsViewModel));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTypeOfPermissionDto input)
        {
            var permissions = _mapper.Map<TypeOfPermission>(input);
            permissions.Created = DateTime.Now;
            await _typeOfPermissionRepository.AddAsync(permissions);
            return Ok(new Response<TypeOfPermission>(permissions));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTypeOfPermission input)
        {
            var permissions = await _typeOfPermissionRepository.GetByIdAsync(id);

            if (permissions == null)
            {
                throw new Exception($"Type Of Permission Not Found.");
            }
            else
            {
                permissions.Description = input.Description;
                permissions.LastModified = DateTime.Now;
                await _typeOfPermissionRepository.UpdateAsync(permissions);
                return Ok(new Response<TypeOfPermission>(permissions));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var permissions = await _typeOfPermissionRepository.GetByIdAsync(id);
            if (permissions == null) throw new Exception($"Type Of Permission Not Found.");
            permissions.IsDeleted = true;
            await _typeOfPermissionRepository.UpdateAsync(permissions);
            return Ok(new Response<int>(permissions.Id));
        }
    }
}
