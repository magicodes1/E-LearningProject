using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models;

public class Student
{
    [Key]
    [Required]
    public Guid StudentId { get; set; }
    [StringLength(30)]
    [Required]
    public string FullName { get; set; } = string.Empty;
    [Required]
    public bool Gender { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime Birthday { get; set; }


    public Guid GradeId { get; set; }
    public Grade Grade { get; set; } = new Grade();

    public Guid CourseId { get; set; }
    public Course Course { get; set; } = new Course();

    public Guid OriginClassId { get; set; }

    public OriginClass originClass { get; set; } = new OriginClass();



    public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
}