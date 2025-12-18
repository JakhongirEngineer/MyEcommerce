using Catalog.Commands;
using Catalog.DTOs;
using Catalog.Entities;
using Catalog.Responses;
using Catalog.Specifications;

namespace Catalog.Mappers;

public static class ProductMappers
{
    public static ProductResponse ToProductResponse(this Product product)
    {
        return new ProductResponse(
            Id: product.Id,
            Name: product.Name,
            Description: product.Description,
            Price: product.Price,
            Summary: product.Summary,
            ImageFile: product.ImageFile,
            CreatedDate: product.CreatedDate,
            BrandResponse: product.Brand.ToProductBrandResponse(),
            TypeResponse: product.Type.ToProductTypeResponse()
        );
    }

    public static Pagination<ProductResponse> ToPaginationProductResponse(this Pagination<Product> products)
    {
        return new Pagination<ProductResponse>(
            pageIndex: products.PageIndex,
            pageSize: products.PageSize,
            count: products.Count,
            data: products.Data.Select(product => product.ToProductResponse()).ToList()
        );
    }

    public static IList<ProductResponse> ToProductResponseList(this IEnumerable<Product> products)
    {
        return products.Select(product => product.ToProductResponse()).ToList();
    }

    public static Product ToProduct(this CreateProductCommand createProductCommand)
    {
        return new Product
        {
            Name = createProductCommand.Name,
            Description = createProductCommand.Description,
            Summary = createProductCommand.Summary,
            ImageFile = createProductCommand.ImageFile,
            Price = createProductCommand.Price,
            CreatedDate = DateTimeOffset.UtcNow,
        };
    }

    public static Product ToProduct(this UpdateProductCommand updateProductCommand, Product oldProduct)
    {
        return new Product
        {
            Name = updateProductCommand.Name ?? oldProduct.Name,
            Description = updateProductCommand.Description ?? oldProduct.Description,
            Summary = updateProductCommand.Summary ?? oldProduct.Summary,
            ImageFile = updateProductCommand.ImageFile ?? oldProduct.ImageFile,
            Price = updateProductCommand.Price ?? oldProduct.Price,
            CreatedDate = DateTimeOffset.UtcNow,
            Brand = oldProduct.Brand,
            Type =  oldProduct.Type,
        };
    }

    public static Pagination<ProductDto> ToDtos(this Pagination<ProductResponse> productResponsePagination)
    {
        return new Pagination<ProductDto>(
            pageIndex: productResponsePagination.PageIndex,
            pageSize: productResponsePagination.PageSize,
            count: productResponsePagination.Count,
            data: productResponsePagination.Data.Select(pr => pr.ToDto()).ToList()
        );
    }

    public static ProductDto ToDto(this ProductResponse productResponse)
    {
        return new ProductDto(
            Id:  productResponse.Id,
            Name: productResponse.Name,
            Summary: productResponse.Summary,
            Description: productResponse.Description,
            ImageFile: productResponse.ImageFile,
            CreatedDate: productResponse.CreatedDate,
            Brand: productResponse.BrandResponse.ToDto(),
            Type: productResponse.TypeResponse.ToDto()
            );
    }

    public static CreateProductCommand ToCommand(this CreateProductDto dto)
    {
        return new CreateProductCommand(
            Name: dto.Name,
            Description: dto.Description,
            Summary: dto.Summary,
            Price: dto.Price,
            ImageFile: dto.ImageFile,
            BrandId: dto.BrandId,
            TypeId: dto.TypeId
            );
    }

    public static UpdateProductCommand ToCommand(this UpdateProductDto dto)
    {
        return new UpdateProductCommand(
            Id: dto.Id,
            Name: dto.Name,
            Description: dto.Description,
            Summary: dto.Summary,
            Price: dto.Price,
            ImageFile: dto.ImageFile,
            BrandId: dto.BrandId,
            TypeId: dto.TypeId
        );
    }

    public static IList<ProductDto> ToDtos(this IList<ProductResponse> responses)
    {
        return responses.Select(r => r.ToDto()).ToList();
    }
}