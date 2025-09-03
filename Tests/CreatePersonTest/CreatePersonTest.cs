using System.ComponentModel.DataAnnotations;
using Infrasctructure.Postgres.Scaffolding;
using Service;

namespace Tests.CreatePersonTest;

public class CreatePersonTest(PersonService personService, MyDbContext ctx)
{
    [Fact]
    public async Task CreatePerson_ShouldBeAbleToSuccessfullyCreatePerson_WhenNoValidationErrors()
    {
        // Arrange
        var name = "Bob";
        var validDto = new CreatePersonRequestDto(Name: name, Age: 2);
        
        // Act
        
        var result = await personService.CreatePerson(validDto);
        
        // Assert
        Assert.Equal(result.Name, name);
        Assert.Equal(ctx.Persons.First().Name, name);
    }
    
}