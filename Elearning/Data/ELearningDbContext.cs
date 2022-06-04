using ElearningApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ElearningApplication.Data;

public class ELearningDbContext : IdentityDbContext<ApplicationUser>
{
    public ELearningDbContext(DbContextOptions<ELearningDbContext> options) : base(options)
    {
        
    }

    public DbSet<Grade> Grades { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Term> Terms { get; set; } = null!;
    public DbSet<Subject> Subjects { get; set; } = null!;
    public DbSet<OriginClass> OriginClasses { get; set; } = null!;
    public DbSet<OnlineClass> OnlineClasses { get; set; } = null!;
    public DbSet<ClassDay> ClassDays { get; set; } = null!;
    public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

    public DbSet<SubjectOriginClass> SubjectOriginClasses { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;

    
}