using Microsoft.AspNetCore.Mvc;
using personsDBdemo;
using Service;

namespace personsDBdemo;

[ApiController]
public class PersonController(IPersonService personService) : ControllerBase
{

    [HttpPost(nameof(CreatePerson))]
    public async Task<Person> CreatePerson([FromBody] CreatePersonRequestDto p)
    {
        var result = await personService.CreatePerson(p);
        return result;
    }

    [HttpPatch(nameof(UpdatePerson))]
    public Person UpdatePerson([FromBody] UpdatePersonRequestDto p)
    {
        return personService.UpdatePerson(p);
    }

    [HttpDelete(nameof(DeletePerson))]
    public Person DeletePerson(string id)
    {
        return personService.DeletePerson(id);
    }

    [HttpGet(nameof(GetAllPersons))]
    public List<Person> GetAllPersons()
    {
        return personService.GetAllPersons();
    }
}