using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace personsDBdemo;

[ApiController]
public class SellerController(ISellerService sellerService) : ControllerBase
{
    
    [HttpPost(nameof(CreateSeller))]
    public async Task<Seller> CreateSeller([FromBody] CreatePetRequestDto p)
    {
        var result = await sellerService.CreateSeller(p);
        return result;
    }
    
    [HttpPatch(nameof(UpdateSeller))]
    public Pet UpdatePet([FromBody] UpdatePetRequestDto p)
    {
        return sellerService.UpdateSeller(p);
    }

    [HttpDelete(nameof(DeleteSeller))]
    public Pet DeleteSeller(string id)
    {
        return sellerService.DeleteSeller(id);
    }

    [HttpGet(nameof(GetAllPets))]
    public List<Pet> GetAllPets()
    {
        return sellerService.GetAllSellers();
    }
    
}