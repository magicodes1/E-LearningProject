using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.DTOs.Account;

public class PasswordResetModel
{
    [Required]
    public string Id { get; set; } =string.Empty;
    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; } =string.Empty;
}