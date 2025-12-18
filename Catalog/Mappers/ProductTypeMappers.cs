using Catalog.DTOs;
using Catalog.Entities;
using Catalog.Responses;

namespace Catalog.Mappers;

public static class ProductTypeMappers
{
    public static ProductTypeResponse ToProductTypeResponse(this ProductType productType)
    {
        return new ProductTypeResponse(Id: productType.Id, Name: productType.Name);
    }

    public static IList<ProductTypeResponse> ToProductTypeResponseList(this IEnumerable<ProductType> productTypes)
    {
        return productTypes.Select(productType => productType.ToProductTypeResponse()).ToList();
    }

    public static ProductTypeDto ToDto(this ProductTypeResponse response)
    {
        return new ProductTypeDto(Id: response.Id, Name: response.Name);
    }

    public static IList<ProductTypeDto> ToDtos(this IList<ProductTypeResponse> responses)
    {
        return responses.Select(r => r.ToDto()).ToList();
    }
}