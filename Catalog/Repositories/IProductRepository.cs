using Catalog.Entities;
using Catalog.Specifications;

namespace Catalog.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    
    Task<Pagination<Product>> GetProductsByParamsAsync(CatalogSpecParams catalogSpecParams);
    
    Task<IEnumerable<Product>> GetProductsByNameAsync(string productName);
    
    Task<IEnumerable<Product>> GetProductsByBrandAsync(string productBrandName);
    
    Task<IEnumerable<Product>> GetProductsByTypeAsync(string productTypeName);

    Task<Product> GetProductByIdAsync(string productId);
    
    Task<Product> CreateProductAsync(Product product);
    
    Task<bool> UpdateProductAsync(Product product);
    
    Task<bool>  DeleteProductByIdAsync(string productId);
}