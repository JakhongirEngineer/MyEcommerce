using Catalog.Responses;
using MediatR;

namespace Catalog.Commands;

public record CreateProductCommand(
    string Name,
    string Description,
    string Summary,
    string ImageFile,
    decimal Price,
    string BrandId,
    string TypeId
) : IRequest<ProductResponse>;