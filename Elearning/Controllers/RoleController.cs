using AutoMapper;
using ElearningApplication.DTOs.Account;
using ElearningApplication.Exceptions;
using ElearningApplication.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElearningApplication.Controller;
[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _role;
    private readonly IMapper _mapper;
    public RoleController(IRoleService role, IMapper mapper)
    {
        _role = role;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddRoleToUser(RoleModel roleModel)
    {
        if (roleModel == null) throw new BadRequestException("payload is null");

        if (!ModelState.IsValid) throw new BadRequestException("Model is invalid");

        var result = await _role.AddRole(roleModel);

        return Ok(result);
    }
}