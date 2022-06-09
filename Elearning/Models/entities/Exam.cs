using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElearningApplication.Models.Entities;

public class Exam
{
    [Key]
    [Required]
    public Guid ExamId { get; set; }
    [StringLength(20)]
    [Required]
    public string Name { get; set; } = string.Empty;
    [Range(1,3)]
    [Required]
    public int ScoreLevel  { get; set; }

    public ICollection<ExamDetail> ExamDetails { get; set; } = new List<ExamDetail>();

}