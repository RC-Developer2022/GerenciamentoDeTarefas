using Tarefas.Domain.Entitys;

namespace Tarefas.infrastructure.Interfaces;

public interface IPersonPersistence
{
    Task<Person> GetPersonByName(string name);
    Task<Person> GetPersonById(int id);
    Task<IEnumerable<Person>> GetPersons();
}
