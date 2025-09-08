using System.ComponentModel.DataAnnotations;

namespace Service;

public record UpdatePetRequestDto
{
    public UpdatePetRequestDto(string name, string breed, string id)
    {
        Name = name;
        Breed = breed;
        Id = id;
    }

    [MinLength(2)]
    public string Name { get; set; }
    [MinLength(1)] 
    public string Breed { get; set; }
    /// <summary>
    /// ID is used for retrieving existing pet, not for updating the ID value
    /// </summary>
    public string Id { get; set; }
}