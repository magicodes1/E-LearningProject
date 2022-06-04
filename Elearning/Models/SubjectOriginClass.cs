using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models;

public class SubjectOriginClass
{
    [Key]
    [Required]
    public Guid SubjectOriginClassId { get; set; }

    public Guid OriginClassId { get; set; }
    public OriginClass OriginClass { get; set; } = new OriginClass();

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = new Subject();

    public OnlineClass OnlineClass { get; set; }= new OnlineClass();
}