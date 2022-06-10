using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models.Entities;

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
    public Grade Grade { get; set; } = null!;



    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Term> Terms { get; set; } = new List<Term>();


    
}