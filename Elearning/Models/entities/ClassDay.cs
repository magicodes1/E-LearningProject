using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models.Entities;

public class ClassDay
{
    [Key]
    [Required]
    public Guid ClassDayId { get; set; }
    [Required]
    [StringLength(10)]
    public string ClassDayName { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    [Required]
    public DateTime ReleaseDate { get; set; }



    public Guid OnlineClassId { get; set; }
    public OnlineClass onlineClass { get; set; } = null!;

    public ICollection<StudentClassDay> StudentClassDays { get; set; } = new List<StudentClassDay>();
}