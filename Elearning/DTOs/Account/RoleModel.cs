using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.DTOs.Account;

public class RoleModel
{
    [Required]
    public string Id { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new List<string>();
}