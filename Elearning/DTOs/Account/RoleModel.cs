namespace ElearningApplication.DTOs.Account;

public class RoleModel
{
    public string Id { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new List<string>();
}