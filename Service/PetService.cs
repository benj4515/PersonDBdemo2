using System.ComponentModel.DataAnnotations;
using DataAccess;

namespace Service;

public interface IPetService
{
    Task<Pet> CreatePet(CreatePetRequestDto pet);
    Pet UpdatePet(UpdatePetRequestDto pet);
    Pet DeletePet(string personId);
    List<Pet> GetAllPets();
}

public class PetService(MyDbContext _db) : IPetService
{ 
    public async Task<Pet> CreatePet(CreatePetRequestDto pet)
    {
        Validator.ValidateObject(pet,
            new ValidationContext(pet),
            true);
        var petEntity = new Pet(
            breed: pet.Breed,
            name: pet.Name,
            createdAt: DateTime.UtcNow,
            id: Guid.NewGuid().ToString());
        await _db.Pets.AddAsync(petEntity);
        await _db.SaveChangesAsync();
        return petEntity;
    }

    public Pet UpdatePet(UpdatePetRequestDto pet)
    {
        Validator.ValidateObject(pet,
            new ValidationContext(pet),
            true);
        var existingPet = _db.Pets.First(p => p.Id == pet.Id);
        existingPet.Breed = pet.Breed;
        existingPet.Name = pet.Name;
        _db.SaveChanges();
        return existingPet;
    }
    
    public Pet DeletePet(string personId)
    {
        var existingPerson = _db.Pets.First(p => p.Id == personId);
        _db.Pets.Remove(existingPerson);
        _db.SaveChanges();
        return existingPerson;
    }
    
    public List<Pet> GetAllPets()
    {
        return _db.Pets.ToList();
    }
}