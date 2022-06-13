using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models.Entities;

public class Term
{
    [Key]
    [Required]
    public Guid TermId { get; set; }
    [Required]
    [StringLength(10)]
    public string TermName { get; set; } = string.Empty;
    [Required]
    public int TermYear { get; set; }

    public Guid CourseId { get; set; }
    public Course Course { get; set; } = null!;


    public ICollection<TermSubject> TermSubjects { get; set; } = new List<TermSubject>();
}