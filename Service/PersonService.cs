using System.ComponentModel.DataAnnotations;
using Infrasctructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using personsDBdemo;

namespace Service;

public interface IPersonService
{
    Task<Person> CreatePerson(CreatePersonRequestDto person);
    Person UpdatePerson(UpdatePersonRequestDto person);
    Person DeletePerson(string personId);
    List<Person> GetAllPersons();
}

public class PersonService(MyDbContext _db) : IPersonService
{ 
    public async Task<Person> CreatePerson(CreatePersonRequestDto person)
    {
        Validator.ValidateObject(person,
            new ValidationContext(person),
            true);
        var personEntity = new Person(
            age: person.Age,
            name: person.Name,
            createdAt: DateTime.UtcNow,
            id: Guid.NewGuid().ToString());
        await _db.Persons.AddAsync(personEntity);
        await _db.SaveChangesAsync();
        return personEntity;
    }

    public Person UpdatePerson(UpdatePersonRequestDto person)
    {
        Validator.ValidateObject(person,
            new ValidationContext(person),
            true);
        var existingPerson = _db.Persons.First(p => p.Id == person.Id);
        existingPerson.Age = person.Age;
        existingPerson.Name = person.Name;
        _db.SaveChanges();
        return existingPerson;
    }
    
    public Person DeletePerson(string personId)
    {
        var existingPerson = _db.Persons.First(p => p.Id == personId);
        _db.Persons.Remove(existingPerson);
        _db.SaveChanges();
        return existingPerson;
    }
    
    public List<Person> GetAllPersons()
    {
        return _db.Persons.ToList();
    }
}