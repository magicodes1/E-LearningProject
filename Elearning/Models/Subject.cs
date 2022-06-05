using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models;

public class Subject
{
    [Key]
    [Required]
    public Guid SubjectId { get; set; }
    [StringLength(20)]
    [Required]
    public string SubjectName { get; set; } = string.Empty;


    public Guid TermId { get; set; }
    public Term Term {get;set;} = new Term();
    
    public ICollection<SubjectOriginClass> subjectOriginClasses { get; set; } = new List<SubjectOriginClass>();
    public ICollection<ExamDetail> ExamDetails { get; set; } = new List<ExamDetail>();
}