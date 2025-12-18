using Catalog.DTOs;
using Catalog.Entities;
using Catalog.Responses;

namespace Catalog.Mappers;

public static class ProductBrandMappers
{
    public static ProductBrandResponse ToProductBrandResponse(this ProductBrand brand)
    {
        return new ProductBrandResponse(Id: brand.Id, Name: brand.Name);
    }

    public static IList<ProductBrandResponse> ToProductBrandResponseList(this IEnumerable<ProductBrand> brands)
    {
        return brands.Select(brand => brand.ToProductBrandResponse())
            .ToList();
    }

    public static ProductBrandDto ToDto(this ProductBrandResponse response)
    {
        return new ProductBrandDto(Id: response.Id, Name: response.Name);
    }
    
    public static IList<ProductBrandDto> ToDtos(this IList<ProductBrandResponse> brands)
    {
        return brands.Select(b => b.ToDto())
            .ToList();
    }
}