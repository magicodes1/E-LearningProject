namespace ElearningApplication.Models.Entities;

public class TermSubject
{
    public Guid TermId { get; set; }
    public Term Term { get; set; } = null!;

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = null!;
    
}