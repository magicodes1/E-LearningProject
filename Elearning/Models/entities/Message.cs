using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models.Entities;

public class Message
{
    [Key]
    [Required]
    public Guid MessageId { get; set; }
    [Required]
    public string Content { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    public DateTime ReleaseDate { get; set; }


    public Guid OnlineClassId { get; set; }

    public OnlineClass OnlineClass { get; set; } = null!;


    public Guid StudentId { get; set; }

    public Student Student { get; set; } = null!;
    

    public Guid TeacherId { get; set; }

    public Teacher Teacher { get; set; } = null!;

}