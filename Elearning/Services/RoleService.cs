using AutoMapper;
using ElearningApplication.DTOs.Account;
using ElearningApplication.Exceptions;
using ElearningApplication.Interfaces.Services;
using ElearningApplication.Models.Entities;
using ElearningApplication.Models.Response;
using Microsoft.AspNetCore.Identity;

namespace ElearningApplication.Services;

public class RoleService : IRoleService
{
    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly UserManager<ApplicationUser> _userManager;

    private readonly IMapper _mapper;

    public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _mapper = mapper;
    }

    private async Task<ApplicationUser> AddRoleToUser(string id, string role)
    {
        //Create new role if it isn't existense.
        if (!await _roleManager.RoleExistsAsync(role))
        {
            await _roleManager.CreateAsync(new IdentityRole(role));
        }

        var user = await _userManager.FindByIdAsync(id);

        if(user==null) throw new NotFoundException($"User {id} isn't found");

        var result = await _userManager.AddToRoleAsync(user,role);

        if(!result.Succeeded) throw new BadRequestException($"Adding role {role} to user {id} is failed.");

        return user;
    }

    public async Task<DataResponse> AddRole(RoleModel roleModel)
    {
        var roles = roleModel.Roles;

        ApplicationUser user = null!;

        foreach (var role in roles)
        {
           user = await AddRoleToUser(roleModel.Id, role);
        }

        var userRoleDTO = _mapper.Map<UserRoleDTO>(user);

        return new DataResponse(true,userRoleDTO,null!);
    }
}