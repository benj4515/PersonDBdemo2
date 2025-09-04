using System.ComponentModel.DataAnnotations;
using Infrasctructure.Postgres.Scaffolding;
using Service;

namespace Tests.CreatePersonTest;

public class CreatePersonTest(IPersonService personService, MyDbContext ctx)
{
    [Fact]
    public async Task CreatePerson_ShouldBeAbleToSuccessfullyCreatePerson_WhenNoValidationErrors()
    {
        // Arrange
        var name = "Bobo";
        var validDto = new CreatePersonRequestDto(name: name, age: 2);
        
        // Act
        
        var result = await personService.CreatePerson(validDto);
        
        // Assert
        Assert.Equal(result.Name, name);
        Assert.Equal(ctx.Persons.First().Name, name);
    }
    
}