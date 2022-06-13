using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.DTOs.Account;

public class ChangePasswordModel
{
    [Required]
    public string Id { get; set; } = string.Empty;
    [Required]
    public string NewPassword { get; set; } = string.Empty;
}