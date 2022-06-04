using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models;

// Bảng phụ để kết nối bảng originClass và subject.
// 1 real class sẽ được học rất nhiều môn học, và những môn học đó cũng sẽ được dạy trong nhiều lớp khác nhau.
// Mỗi 1 môn học của 1 lớp cụ thể nào đó sẽ có 1 lớp học online.
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