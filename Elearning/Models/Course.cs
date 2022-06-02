using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models;

public class Course
{
    [Key]
    [Required]
    public Guid CourseId { get; set; }
    [StringLength(20)]
    public string CourseName { get; set; } = string.Empty;
    [StringLength(15)]
    [Required]
    public string SchoolYear { get; set; } = string.Empty;


    public Guid GradeId { get; set; }
    public Grade Grade { get; set; } = new Grade();



    public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    
}