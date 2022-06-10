using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.DTOs.Account;

public class SignupModel
{
    [Required]
    public string UserName { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(10)]
    [RegularExpression(@"^[0-9]*$")]
    public string PhoneNumber { get; set; } = string.Empty;
}