using Microsoft.AspNetCore.Identity;

namespace ElearningApplication.Models.Entities;

public class ApplicationRole : IdentityRole
{
     public virtual ICollection<ApplicationUserRole> UserRoles { get; set; } = new List<ApplicationUserRole>();
}