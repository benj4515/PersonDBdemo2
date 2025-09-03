using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public record CreatePersonRequestDto
{
    [MinLength(3)] public string Name { get; set; } = null!;
    [Range(0,15)]
    public int Age { get; set; }
}