using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Repositories.implementation;

public class ProductTypeRepository : IProductTypeRepository
{
    private readonly IMongoCollection<ProductType> _productTypes;
    
    public ProductTypeRepository(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
        var db = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
        _productTypes = db.GetCollection<ProductType>(configuration["DatabaseSettings:ProductTypeCollectionName"]);
    }
    public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
    {
        return await  _productTypes.Find(_ => true).ToListAsync();
    }

    public async Task<ProductType> GetProductTypeByIdAsync(string productTypeId)
    {
        return await _productTypes.Find(productType => productType.Id == productTypeId).FirstOrDefaultAsync();
    }

    public async Task<ProductType> GetProductTypeByNameAsync(string productTypeName)
    {
        return await _productTypes.Find(productType => productType.Name == productTypeName).FirstOrDefaultAsync();
    }
}