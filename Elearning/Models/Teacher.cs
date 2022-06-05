using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models;

public class Teacher
{
    [Key]
    [Required]
    public Guid TeacherId { get; set; }



    public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();

    public ICollection<Message> Messages { get; set; } = new List<Message>();
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    public ICollection<SubjectOriginClass> SubjectOriginClasses { get; set; } = new List<SubjectOriginClass>();
    public ICollection<OnlineClass> OnlineClasses { get; set; } = new List<OnlineClass>();



    public OriginClass OriginClass { get; set; } = new OriginClass();

    
}