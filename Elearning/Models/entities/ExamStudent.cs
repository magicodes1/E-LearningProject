using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElearningApplication.Models.Entities;
// Dùng để lưu lại học sinh nào làm bài kiểm tra nào và điểm bài kiểm tra bao nhiêu, giáo viên nào chấm
public class ExamStudent
{
    public Guid ExamDetailId { get; set; }
    public ExamDetail ExamDetail { get; set; } = null!;

    public Guid StudentId { get; set; }
    public Student Student { get; set; } = null!;
    

    
    public byte [] AttachFile { get; set; } = null!;
    [Required]
    [Range(1,10)]
    public int Score { get; set; }

    [DataType(DataType.Date)]
    [Required]
    public DateTime CompletedDay { get; set; }

    [DataType(DataType.Time)]
    [Required]
    public DateTime CompletedTime { get; set; }

    public string Remark { get; set; } = string.Empty;

    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
}