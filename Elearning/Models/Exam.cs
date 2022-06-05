using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElearningApplication.Models;

public class Exam
{
    [Key]
    public Guid ExamId { get; set; }
    [StringLength(20)]
    public string Name { get; set; } = string.Empty;
    [Range(1,3)]
    public int ScoreLevel  { get; set; }

    public ICollection<ExamDetail> ExamDetails { get; set; } = new List<ExamDetail>();

}