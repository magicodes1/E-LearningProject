using Microsoft.AspNetCore.Identity;

namespace ElearningApplication.Models;

public class ApplicationUser : IdentityUser
{
    
    public Guid GradeId { get; set; }
    public Grade Grade { get; set; } = new Grade();

    public Guid CourseId { get; set; }
    public Course Course { get; set; } = new Course();
}