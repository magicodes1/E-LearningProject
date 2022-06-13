namespace ElearningApplication.DTOs.Account;

public class UserRoleDTO
{
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

   public List<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
}