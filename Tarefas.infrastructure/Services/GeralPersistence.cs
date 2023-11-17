using Tarefas.infrastructure.Interfaces;

namespace Tarefas.infrastructure.Services;

public class GeralPersistence(TasksDbContext context) : IGeralPersistence
{

    public void Add<T>(T entity) where T : class
    {
        context.AddAsync(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        context.Remove(entity);
    }

    public void DeleteRange<T>(T[] entityArray) where T : class
    {
        context.RemoveRange(entityArray);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await context.SaveChangesAsync()) > 0;
    }

    public void Update<T>(T entity) where T : class
    {
        context.Update(entity);
    }
}
