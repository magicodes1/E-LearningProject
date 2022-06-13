using ElearningApplication.DTOs.Account;
using ElearningApplication.Models.Response;

namespace ElearningApplication.Interfaces.Services;

public interface IRoleService
{
    Task<DataResponse> AddRole(RoleModel roleModel);
}