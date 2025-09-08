using System.ComponentModel.DataAnnotations;
using DataAccess;
using Service;

namespace Tests.CreatePetTest;

public class CreatePetTest(IPetService petService, MyDbContext ctx)
{
    [Fact]
    public async Task CreatePerson_ShouldBeAbleToSuccessfullyCreatePerson_WhenNoValidationErrors()
    {
        // Arrange
        var name = "Bobo";
        var validDto = new CreatePetRequestDto(name: name, breed: "dog");
        
        // Act
        
        var result = await petService.CreatePet(validDto);
        
        // Assert
        Assert.Equal(result.Name, name);
        Assert.Equal(ctx.Pets.First().Name, name);
    }
    
}