using ElearningApplication.Data;
using ElearningApplication.Interfaces.Unit;

namespace ElearningApplication.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ELearningDbContext _context;

    public UnitOfWork(ELearningDbContext context)
    {
        _context = context;
    }
    public async Task saveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);
}