﻿using Tarefas.Application.DTO;

namespace Tarefas.Application.Interfaces;

public interface IPersonServices
{
    Task<PersonDTO> AddPerson(PersonDTO personDTO);
    Task<PersonDTO> UpdatePerson(PersonDTO personDTO);
    Task<bool> DeletePerson(int id);
    Task<PersonDTO> GetPersonByName (string name);
    Task<PersonDTO> GetPersonById(int id);
    Task<IEnumerable<PersonDTO>> GetPersons();
}
