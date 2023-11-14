using AutoMapper;
using Tarefas.Application.DTO;
using Tarefas.Application.Interfaces;
using Tarefas.Domain.Entitys;
using Tarefas.infrastructure.Interfaces;

namespace Tarefas.Application.Services;

public class PersonServices : IPersonServices
{
    private readonly IPersonPersistence _persistence;
    private readonly IMapper _mapper;
    public PersonServices(IPersonPersistence persistence, IMapper mapper)
    {
        _persistence = persistence;
        _mapper = mapper;
    }

    public async Task<PersonDTO> GetPersonById(int id)
    {
        var person = _mapper.Map<PersonDTO>(await _persistence.GetPersonById(id));

        return person;
        
    }

    public async Task<PersonDTO> GetPersonByName(string name)
    {
        var person = _mapper.Map<PersonDTO>(await _persistence.GetPersonByName(name));

        return person;
    }

    public async Task<IEnumerable<PersonDTO>> GetPersons()
    {
        var persons = _mapper.Map<PersonDTO>(await _persistence.GetPersons());
        return persons;
    }
}
