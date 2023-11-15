using AutoMapper;
using Tarefas.Application.DTO;
using Tarefas.Application.Interfaces;
using Tarefas.Domain.Entitys;
using Tarefas.infrastructure.Interfaces;

namespace Tarefas.Application.Services;

public class PersonServices : IPersonServices
{
    private readonly IGeralPersistence _geralPersistence;
    private readonly IPersonPersistence _personPersistence;
    private readonly IMapper _mapper;
    public PersonServices(
        IGeralPersistence geralPersistence ,
        IPersonPersistence persistence ,
        IMapper mapper)
    {
        _geralPersistence = geralPersistence;
        _personPersistence = persistence;
        _mapper = mapper;
    }

    public async Task<PersonDTO> AddPerson(PersonDTO personDTO)
    {
        try
        {
            var person = _mapper.Map<Person>(personDTO);
            _geralPersistence.Add(person);
            if(await _geralPersistence.SaveChangesAsync())
            {
                var retorno = await _personPersistence.GetPersonById(person.Id);
                return _mapper.Map<PersonDTO>(retorno);
            }
            return null;
        }
        catch(Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<PersonDTO> UpdatePerson(PersonDTO personDTO)
    {
        try
        {
            var person = await _personPersistence.GetPersonById(personDTO.Id);
            _geralPersistence.Update(person);
            if(await _geralPersistence.SaveChangesAsync())
            {
                var retorno = await _personPersistence.GetPersonById(personDTO.Id);
                return _mapper.Map<PersonDTO>(retorno);
            }

            return null;
        }
        catch(Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeletePerson(int id)
    {
        try
        {
            var person = await _personPersistence.GetPersonById(id);
            if(person == null)
                throw new Exception("Person not found in the database");

            _geralPersistence.Delete(person);
            return await _geralPersistence.SaveChangesAsync();
        }
        catch(Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<PersonDTO> GetPersonById(int id)
    {
        var person = _mapper.Map<PersonDTO>(await _personPersistence.GetPersonById(id));

        return person;

    }

    public async Task<PersonDTO> GetPersonByName(string name)
    {
        var person = _mapper.Map<PersonDTO>(await _personPersistence.GetPersonByName(name));

        return person;
    }

    public async Task<IEnumerable<PersonDTO>> GetPersons()
    {
        var persons = _mapper.Map<IEnumerable<PersonDTO>>(await _personPersistence.GetPersons());
        return persons;

    }
}
