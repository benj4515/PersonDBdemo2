using System.ComponentModel.DataAnnotations;

namespace Service;

public record CreatePetRequestDto
{
    
    
    public CreatePetRequestDto(string name, string breed)
    {
        Name = name;
        Breed = breed;
    }
    
    
    [MinLength(3)] 
    public string Name { get; set; } = null!;
    [MinLength(2)] 
    public string Breed { get; set; }
}