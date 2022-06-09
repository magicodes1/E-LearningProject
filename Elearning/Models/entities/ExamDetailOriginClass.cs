namespace ElearningApplication.Models.Entities;

public class ExamDetailOriginClass
{
    public Guid ExamDetailId { get; set; }
    public ExamDetail ExamDetail { get; set; } = new ExamDetail();

    public Guid OriginClassId { get; set; }
    public OriginClass OriginClass { get; set; } = new OriginClass();
}