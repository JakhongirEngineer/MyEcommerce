using Catalog.Responses;
using MediatR;

namespace Catalog.Commands;

public record UpdateProductCommand(
    string Id,
    string? Name,
    string? Description,
    string? Summary,
    string? ImageFile,
    decimal? Price,
    string? BrandId,
    string? TypeId) : IRequest<bool>;