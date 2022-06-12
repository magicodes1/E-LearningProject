using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.DTOs.Account;

public class VerifyCodeModel
{
    [Required]
    public string Id { get; set; } = string.Empty;
    [StringLength(5)]
    [RegularExpression(@"^[0-9]*$")]
    public string Code { get; set; } = string.Empty;
}