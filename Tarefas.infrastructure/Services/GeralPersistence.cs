using Tarefas.infrastructure.Interfaces;

namespace Tarefas.infrastructure.Services;

public class GeralPersistence : IGeralPersistence
{
    public readonly TasksDbContext _context;

    public GeralPersistence(TasksDbContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
        _context.AddAsync(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public void DeleteRange<T>(T[] entityArray) where T : class
    {
        _context.RemoveRange(entityArray);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

    public void Update<T>(T entity) where T : class
    {
        _context.Update(entity);
    }
}
