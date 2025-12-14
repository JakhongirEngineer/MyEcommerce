using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Repositories.implementation;

public class ProductBrandRepository : IProductBrandRepository
{
    private readonly IMongoCollection<ProductBrand> _productBrands;
    
    public ProductBrandRepository(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
        var db = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
        _productBrands = db.GetCollection<ProductBrand>(configuration["DatabaseSettings:BrandCollectionName"]);
    }

    public async Task<IEnumerable<ProductBrand>> GetAllBrandsAsync()
    {
        return await _productBrands.Find(_ => true).ToListAsync();
    }

    public async Task<ProductBrand> GetProductBrandByIdAsync(string productBrandId)
    {
        return await _productBrands.Find(productBrand => productBrand.Id == productBrandId).FirstOrDefaultAsync();
    }

    public async Task<ProductBrand> GetProductBrandByNameAsync(string productBrandName)
    {
        return await _productBrands.Find(productBrand => productBrand.Name == productBrandName).FirstOrDefaultAsync();
    }
}