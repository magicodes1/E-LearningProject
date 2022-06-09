using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models.Entities;

public class ExamType
{
    [Key]
    [Required]
    public Guid ExamTypeId { get; set; }
    [StringLength(10)]
    [Required]
    public string ExamTypeName { get; set; } = string.Empty;


    public ICollection<ExamDetail> examDetails { get; set; } = new List<ExamDetail>();
}