using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ElearningApplication.Models;

public class ApplicationUser : IdentityUser
{
    [StringLength(150)]
    public string Avatar { get; set; } = string.Empty;

    public Guid StudentId { get; set; }
    public Student Student { get; set; } = new Student();
}