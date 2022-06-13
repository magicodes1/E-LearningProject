namespace ElearningApplication.Interfaces.Unit;

public interface IUnitOfWork
{
    Task saveChangesAsync(CancellationToken cancellationToken=default);
}