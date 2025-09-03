using System.ComponentModel.DataAnnotations;

namespace Service;

public record CreatePersonRequestDto(string Name, int Age)
{
    [MinLength(3)] public string Name { get; set; } = null!;
    [Range(0,15)]
    public int Age { get; set; }
}