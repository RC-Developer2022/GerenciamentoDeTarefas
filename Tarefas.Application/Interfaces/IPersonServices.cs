using Tarefas.Application.DTO;

namespace Tarefas.Application.Interfaces;

public interface IPersonServices
{
    Task<PersonDTO> GetPersonByName (string name);
    Task<PersonDTO> GetPersonById(int id);
    Task<IEnumerable<PersonDTO>> GetPersons();
}
