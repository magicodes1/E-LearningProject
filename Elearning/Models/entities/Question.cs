using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models.Entities;

public class Question
{
    [Key]
    [Required]
    public Guid QuestionId { get; set; }

    [Required]
    public string QuestionContent { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    public DateTime ReleaseDate { get; set; }


    public Guid OnlineClassId { get; set; }

    public OnlineClass OnlineClass { get; set; } = null!;


    public Guid StudentId { get; set; }

    public Student Student { get; set; } = null!;


    public ICollection<Answer> Answers { get; set; } = null!;

}