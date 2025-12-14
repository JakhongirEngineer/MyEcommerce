using Catalog.Entities;

namespace Catalog.Repositories;

public interface IProductBrandRepository
{
    Task<IEnumerable<ProductBrand>> GetAllBrandsAsync();
    
    Task<ProductBrand> GetProductBrandByIdAsync(string productBrandId);
    
    Task<ProductBrand> GetProductBrandByNameAsync(string productBrandName);
}