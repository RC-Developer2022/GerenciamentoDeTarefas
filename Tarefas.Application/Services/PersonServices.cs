using AutoMapper;
using Tarefas.Application.DTO;
using Tarefas.Application.Interfaces;
using Tarefas.Domain.Entitys;
using Tarefas.infrastructure.Interfaces;

namespace Tarefas.Application.Services;

public class PersonServices(IGeralPersistence geralPersistence, IPersonPersistence personPersistence, IMapper mapper) : IPersonServices
{

    public async Task<PersonDTO> AddPerson(PersonDTO personDTO)
    {
        try
        {
            personDTO.DateBirth = Convert.ToDateTime(personDTO.DateBirth);
            var person = mapper.Map<Person>(personDTO);
            geralPersistence.Add(person);
            if(await geralPersistence.SaveChangesAsync())
            {
                var retorno = await personPersistence.GetPersonById(person.Id);
                return mapper.Map<PersonDTO>(retorno);
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
            var person = await personPersistence.GetPersonById(personDTO.Id);
            geralPersistence.Update(person);
            if(await geralPersistence.SaveChangesAsync())
            {
                var retorno = await personPersistence.GetPersonById(personDTO.Id);
                return mapper.Map<PersonDTO>(retorno);
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
            var person = await personPersistence.GetPersonById(id);
            if(person == null)
                throw new Exception("Person not found in the database");

            geralPersistence.Delete(person);
            return await geralPersistence.SaveChangesAsync();
        }
        catch(Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<PersonDTO> GetPersonById(int id)
    {
        var person = mapper.Map<PersonDTO>(await personPersistence.GetPersonById(id));

        return person;

    }

    public async Task<PersonDTO> GetPersonByName(string name)
    {
        var person = mapper.Map<PersonDTO>(await personPersistence.GetPersonByName(name));

        return person;
    }

    public async Task<IEnumerable<PersonDTO>> GetPersons()
    {
        var persons = mapper.Map<IEnumerable<PersonDTO>>(await personPersistence.GetPersons());
        return persons;

    }
}
