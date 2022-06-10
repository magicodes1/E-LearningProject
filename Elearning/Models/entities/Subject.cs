using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models.Entities;

public class Subject
{
    [Key]
    [Required]
    public Guid SubjectId { get; set; }
    [StringLength(20)]
    [Required]
    public string SubjectName { get; set; } = string.Empty;


    
    public ICollection<SubjectOriginClass> subjectOriginClasses { get; set; } = new List<SubjectOriginClass>();
    public ICollection<ExamDetail> ExamDetails { get; set; } = new List<ExamDetail>();

    public ICollection<TermSubject> TermSubjects { get; set; } = new List<TermSubject>();


     public Guid TeacherId { get; set; }
     public Teacher Teacher { get; set; } = null!;
}