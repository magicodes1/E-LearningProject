using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models;

public class Grade
{
    [Key]
    [Required]
    public Guid GradeId { get; set; }
    [StringLength(5)]
    [Required]
    public string GradeName { get; set; } = string.Empty;

    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<OriginClass> originClasses { get; set; } = new List<OriginClass>();



    public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();

}