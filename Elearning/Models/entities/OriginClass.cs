using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models;

public class OriginClass
{
    [Key]
    [Required]
    public Guid OriginClassId { get; set; }
    [Required]
    [StringLength(10)]
    public string OriginClassName { get; set; } = string.Empty;

    
    public Guid GradeId { get; set; }
    public Grade Grade { get; set; } = new Grade();




    
    public ICollection<Student> Students { get; set; } = new List<Student>();


    public ICollection<SubjectOriginClass> SubjectOriginClasses { get; set; } = new List<SubjectOriginClass>();

    public Guid TeacherId { get; set; }

    public Teacher Teacher { get; set; } = new Teacher();

    public ICollection<ExamDetailOriginClass> examDetailOriginClasses { get; set; } = new List<ExamDetailOriginClass>();
}