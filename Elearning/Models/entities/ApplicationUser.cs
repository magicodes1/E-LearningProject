using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ElearningApplication.Models.Entities;

public class ApplicationUser : IdentityUser
{
    [StringLength(150)]
    public string Avatar { get; set; } = string.Empty;

    public Guid StudentId { get; set; }
    public Student Student { get; set; } = new Student();

    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; } = new Teacher();

    public ICollection<OTP> OTPs { get; set; } = new List<OTP>();
}