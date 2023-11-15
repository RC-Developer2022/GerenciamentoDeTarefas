﻿using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Tarefas.Domain.Entitys;
using Tarefas.infrastructure.Interfaces;

namespace Tarefas.infrastructure.Services;

public sealed class PersonPersistence : IPersonPersistence
{
    private readonly TasksDbContext _context;
    public PersonPersistence(TasksDbContext context)
    {
        _context = context;
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public async Task<Person> GetPersonById(int id)
    {
        var person = _context.Person.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();


        return await person;
    }

    public async Task<Person> GetPersonByName(string name)
    {
        var person = _context.Person.Where(p => p.Name.Equals(name)).FirstOrDefaultAsync();


        return await person;
    }

    public async Task<IEnumerable<Person>> GetPersons()
    {
        var person = _context.Person.ToArrayAsync();

        return await person;
    }
}
