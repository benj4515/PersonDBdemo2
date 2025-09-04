using System.ComponentModel.DataAnnotations;

namespace Service;

public record CreatePersonRequestDto
{
    
    
    public CreatePersonRequestDto(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    
    [MinLength(3)] public string Name { get; set; } = null!;
    [Range(0,15)]
    public int Age { get; set; }
}