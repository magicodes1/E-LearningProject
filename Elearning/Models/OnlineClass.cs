using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models;

public class OnlineClass
{
    [Key]
    [Required]
    public Guid OnlineClassId { get; set; }
    [StringLength(30)]
    [Required]

    public string OnlineClassTitle { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    [Required]
    public DateTime ReleaseDate { get; set; }
    [DataType(DataType.DateTime)]
    [Required]
    public DateTime closedDate { get; set; }
    [DataType(DataType.Time)]
    public DateTime StudyTime { get; set; }
    [StringLength(100)]
    public string ClassLink { get; set; } = string.Empty;



    public Boolean isAutomaticalStart { get; set; }
    public Boolean isSave { get; set; }
    public Boolean isShareClass { get; set; }



    public Guid OriginClassId { get; set; }
    public OriginClass originClass { get; set; } = new OriginClass();


    public ICollection<SubjectSchedule> Schedules { get; set; } = new List<SubjectSchedule>();
}