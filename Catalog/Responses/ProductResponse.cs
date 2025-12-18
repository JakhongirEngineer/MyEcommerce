namespace Catalog.Responses;

public record ProductResponse(
    string Id,
    string Name,
    string Description,
    string Summary,
    string ImageFile,
    decimal Price,
    DateTimeOffset CreatedDate,
    ProductBrandResponse BrandResponse,
    ProductTypeResponse TypeResponse
    );