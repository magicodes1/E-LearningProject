using System.ComponentModel.DataAnnotations;

namespace ElearningApplication.Models.Entities;

// Lớp này dùng để lưu lại những học sinh đã tham gia buổi học ngày hôm đó và tham gia với thời gian
//bao lâu để đánh giá điểm chuyên cần
public class StudentClassDay
{
    public Guid ClassDayId { get; set; }

    public ClassDay ClassDay { get; set; } = null!;


    public Guid StudentId { get; set; }
    public Student Student { get; set; } = null!;
    

    [DataType(DataType.Time)]
    public DateTime StayingTime { get; set; }
}