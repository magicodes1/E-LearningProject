using Microsoft.AspNetCore.Identity;

namespace ElearningApplication.Models.Entities;

public class ApplicationUserRole : IdentityUserRole<string>
{
    public virtual ApplicationUser User { get; set; } = new ApplicationUser();
    public virtual ApplicationRole Role { get; set; } = new ApplicationRole();
}