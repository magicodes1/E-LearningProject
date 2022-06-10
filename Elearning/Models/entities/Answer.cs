using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models.Entities;

public class Answer
{
    [Key]
    [Required]
    public Guid AnswerId { get; set; }

    [Required]
    public string AnswerContent { get; set; } = string.Empty;

    [DataType(DataType.DateTime)]
    public DateTime ReleaseDate { get; set; }

    public Guid QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    public Guid TeacherId { get; set; }

    public Teacher Teacher { get; set; } = null!;

    public Guid StudentId { get; set; }

    public Student Student { get; set; } = null!;
}