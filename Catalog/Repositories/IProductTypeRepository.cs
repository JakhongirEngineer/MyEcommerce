using Catalog.Entities;

namespace Catalog.Repositories;

public interface IProductTypeRepository
{
    Task<IEnumerable<ProductType>> GetProductTypesAsync();
    
    Task<ProductType> GetProductTypeByIdAsync(string productTypeId);
    Task<ProductType> GetProductTypeByNameAsync(string productTypeName);
}