using System.Text.Json;
using Catalog.Entities;
using MongoDB.Driver;

namespace Catalog.Data;

public class DatabaseSeeder
{
    public static async Task SeedAsync(IConfiguration configuration)
    {
        var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
        var db = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
        var brandsCollection = db.GetCollection<ProductBrand>(configuration["DatabaseSettings:ProductBrandCollectionName"]);
        var typesCollection = db.GetCollection<ProductType>(configuration["DatabaseSettings:ProductTypeCollectionName"]);
        var productsCollection = db.GetCollection<Product>(configuration["DatabaseSettings:ProductCollectionName"]);

        var seedBasePath = Path.Combine("Data", "SeedData");
        var brandsPath = Path.Combine(seedBasePath, "brands.json");
        var typesPath = Path.Combine(seedBasePath, "types.json");
        var productsPath = Path.Combine(seedBasePath, "products.json");

        if (await brandsCollection.CountDocumentsAsync(_ => true) == 0)
        {
            string brandsContent = await File.ReadAllTextAsync(brandsPath);
            var brandsList = JsonSerializer.Deserialize<List<ProductBrand>>(brandsContent);
            await brandsCollection.InsertManyAsync(brandsList);
        }

        if (await typesCollection.CountDocumentsAsync(_ => true) == 0)
        {
            string  typesContent = await File.ReadAllTextAsync(typesPath);
            var typesList = JsonSerializer.Deserialize<List<ProductType>>(typesContent);
            await typesCollection.InsertManyAsync(typesList);
        }

        if (await productsCollection.CountDocumentsAsync(_ => true) == 0)
        {
            string  productsContent = await File.ReadAllTextAsync(productsPath);
            var productsList = JsonSerializer.Deserialize<List<Product>>(productsContent);
            foreach (var product in productsList)
            {
                product.Id = null; // let mongo generate its ID
                if (product.CreatedDate == default)
                {
                    product.CreatedDate = DateTimeOffset.UtcNow;
                }
            }
            await productsCollection.InsertManyAsync(productsList);
        }
    }
}