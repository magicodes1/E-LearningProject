using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElearningApplication.Models.Entities;

public class ExamDetail
{
    [Key]
    [Required]
    public Guid ExamDetailId { get; set; }
    [StringLength(30)]
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [DataType(DataType.Time)]
    [Required]
    public DateTime ExamTime { get; set; }
    
    public byte[] AttachFile { get; set; } = null!;

    public bool isAttached { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime StartDay { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime EndDay { get; set; }


    public Guid ExamId { get; set; }

    public Exam Exam { get; set; } = new Exam();

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = new Subject();

    public Guid ExamTypeId { get; set; }
    public ExamType ExamType { get; set; } = new ExamType();


    public ICollection<ExamDetailOriginClass> examDetailOriginClasses { get; set; } = new List<ExamDetailOriginClass>();
    public ICollection<ExamStudent> ExamStudents { get; set; } = new List<ExamStudent>();
}