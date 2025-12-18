using Catalog.Responses;
using Catalog.Specifications;
using MediatR;

namespace Catalog.Queries;

public record GetProductsByParamsQuery(CatalogSpecParams Params) : IRequest<Pagination<ProductResponse>>;