using Catalog.Responses;
using MediatR;

namespace Catalog.Queries;

public record GetProductsByBrandQuery(string ProductBrandName) : IRequest<IList<ProductResponse>>;