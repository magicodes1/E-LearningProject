using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models;

public class SubjectSchedule
{
    [Key]
    [Required]
    public Guid SubjectScheduleId { get; set; }
    [Required]
    [StringLength(10)]
    public string SubjectScheduleName { get; set; } =string.Empty;
    [DataType(DataType.DateTime)]
    [Required]
    public DateTime ReleaseDate { get; set; }

    

    public Guid OnlineClassId { get; set; }
    public OnlineClass onlineClass { get; set; } = new OnlineClass();

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = new Subject();


}