namespace ElearningApplication.Models;

public class TermSubject
{
    public Guid TermId { get; set; }
    public Term Term { get; set; } = new Term();

    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = new Subject();
    
}