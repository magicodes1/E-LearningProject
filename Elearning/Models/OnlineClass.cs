using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models;

public class OnlineClass
{
    [Key]
    [Required]
    public Guid OnlineClassId { get; set; }
    [StringLength(30)]

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
    [StringLength(100)]
    public string PasswordClass { get; set; } = string.Empty;



    public Boolean isAutomaticalStart { get; set; }
    public Boolean isSave { get; set; }
    public Boolean isShareClass { get; set; }



    public Guid OriginClassId { get; set; }
    public OriginClass originClass { get; set; } = new OriginClass();

    public Guid SubjectOriginClassId { get; set; }
    public SubjectOriginClass SubjectOriginClass { get; set; } = new SubjectOriginClass();


    public Guid TeacherId { get; set; }

    public Teacher Teacher { get; set; } = new Teacher();


    public ICollection<ClassDay> ClassDays { get; set; } = new List<ClassDay>();
    
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public ICollection<Message> Messages { get; set; } = new List<Message>();
}