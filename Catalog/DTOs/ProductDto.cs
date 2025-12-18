namespace Catalog.DTOs;

public record ProductDto(
    string Id,
    string Name,
    string Summary,
    string Description,
    string ImageFile,
    ProductBrandDto Brand,
    ProductTypeDto Type,
    DateTimeOffset CreatedDate);