using System.ComponentModel.DataAnnotations;
using DataAccess;

namespace Service;

public interface ISellerService
{
    Task<Seller> CreateSeller(CreateSellerRequestDto seller);
    Seller UpdateSeller(UpdateSellerRequestDto seller);
    Seller DeleteSeller(string sellerId);
    List<Seller> GetAllSellers();
}

public class SellerService(MyDbContext _db) : ISellerService
{
    public Task<Seller> CreateSeller(CreateSellerRequestDto seller)
    {
        Validator.ValidateObject(seller,
            new ValidationContext(seller),
            true);
        var sellerEntity = new Seller(
    )
        await _db.Sellers.AddAsync(sellerEntity);
        await _db.SaveChangesAsync();
        return sellerEntity;
    }

    public Seller UpdateSeller(UpdateSellerRequestDto seller)
    {
        throw new NotImplementedException();
    }

    public Seller DeleteSeller(string sellerId)
    {
        throw new NotImplementedException();
    }

    public List<Seller> GetAllSellers()
    {
        throw new NotImplementedException();
    }
}