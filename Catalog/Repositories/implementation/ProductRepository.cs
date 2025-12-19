using Catalog.Entities;
using Catalog.Specifications;
using MongoDB.Driver;

namespace Catalog.Repositories.implementation;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _products;

    public ProductRepository(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
        var db = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
        _products = db.GetCollection<Product>(configuration["DatabaseSettings:ProductCollectionName"]);
    }
    
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _products.Find(_ => true).ToListAsync();
    }

    public async Task<Pagination<Product>> GetProductsByParamsAsync(CatalogSpecParams catalogSpecParams)
    {
        var builder = Builders<Product>.Filter;
        var filter = builder.Empty;

        if (!string.IsNullOrEmpty(catalogSpecParams.Search))
        {
            filter &= builder.Where(product => product.Name.ToLower().Contains( catalogSpecParams.Search));
        }

        if (!string.IsNullOrEmpty(catalogSpecParams.ProductBrandId))
        {
            filter &= builder.Eq(product => product.Brand.Id, catalogSpecParams.ProductBrandId);
        }

        if (!string.IsNullOrEmpty(catalogSpecParams.ProductTypeId))
        {
            filter &= builder.Eq(product => product.Type.Id, catalogSpecParams.ProductTypeId);
        }
        
        var totalCount = await _products.CountDocumentsAsync(filter);
        var data = await GetFilteredProductsAsync(catalogSpecParams, filter);

        return new Pagination<Product>(catalogSpecParams.PageIndex, catalogSpecParams.PageSize, totalCount, data);
    }

    private async Task<IReadOnlyList<Product>> GetFilteredProductsAsync(
        CatalogSpecParams catalogSpecParams,
        FilterDefinition<Product> filter,
        CancellationToken cancellationToken = default)
    {
        var pageIndex = Math.Max(1, catalogSpecParams.PageIndex);
        var pageSize  = Math.Max(1, catalogSpecParams.PageSize);

        var sortDefinition = catalogSpecParams.Sort switch
        {
            "priceDesc" => Builders<Product>.Sort.Descending(p => p.Price),
            "priceAsc"  => Builders<Product>.Sort.Ascending(p => p.Price),
            "nameDesc"  => Builders<Product>.Sort.Descending(p => p.Name),
            _           => Builders<Product>.Sort.Ascending(p => p.Name),
        };

        return await _products
            .Find(filter)
            .Sort(sortDefinition)
            .Skip(pageSize * (pageIndex - 1))
            .Limit(pageSize)
            .ToListAsync(cancellationToken);
    }


    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string productName)
    {
        return await _products.Find(product => product.Name.ToLower() == productName).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByBrandAsync(string productBrandName)
    {
        return await _products
            .Find(product => product.Brand.Name == productBrandName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByTypeAsync(string productTypeName)
    {
        return await _products
            .Find(product => product.Type.Name == productTypeName)
            .ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(string productId)
    {
        return await _products.Find(product => product.Id == productId).FirstOrDefaultAsync();
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
         await _products.InsertOneAsync(product);
         return product;
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var replacedResult = await _products.ReplaceOneAsync(product => product.Id == product.Id, product);
        return replacedResult.IsAcknowledged && replacedResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProductByIdAsync(string productId)
    {
        var deleteResult = await _products.DeleteOneAsync(product => product.Id == productId);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}