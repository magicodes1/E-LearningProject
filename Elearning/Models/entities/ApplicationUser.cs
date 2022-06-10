using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ElearningApplication.Models.Entities;

public class ApplicationUser : IdentityUser
{
    [StringLength(150)]
    public string Avatar { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    public DateTime PasswordResetStartDate { get; set; }

    public Guid StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;

    public ICollection<OTP> OTPs { get; set; } = new List<OTP>();

   public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
}