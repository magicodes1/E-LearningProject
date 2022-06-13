using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models.Entities;

public class Teacher
{
    [Key]
    [Required]
    public Guid TeacherId { get; set; }

    [StringLength(30)]
    [Required]
    public string FullName { get; set; } = string.Empty;
    [Required]
    public bool Gender { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime Birthday { get; set; }



    public ApplicationUser ApplicationUser { get; set; } = null!;

    public ICollection<Message> Messages { get; set; } = new List<Message>();
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    public ICollection<SubjectOriginClass> SubjectOriginClasses { get; set; } = new List<SubjectOriginClass>();
    public ICollection<OnlineClass> OnlineClasses { get; set; } = new List<OnlineClass>();



    public OriginClass OriginClass { get; set; } = null!;

    public ICollection<ExamStudent> ExamStudents { get; set; } = new List<ExamStudent>();


    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}