using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models.Entities;

public class OTP
{
    [Key]
    [Required]
    public Guid OTPId { get; set; }
    public string Code { get; set; } = string.Empty;
    [DataType(DataType.Time)]
    public DateTime? ExpiredTime { get; set; }
    
    [Required]
    public string  Id { get; set; } = string.Empty;

    public ApplicationUser ApplicationUser { get; set; } = null!;
}