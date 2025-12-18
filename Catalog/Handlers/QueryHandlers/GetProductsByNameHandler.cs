using Catalog.Mappers;
using Catalog.Queries;
using Catalog.Repositories;
using Catalog.Responses;
using MediatR;

namespace Catalog.Handlers;

public class GetProductsByNameHandler : IRequestHandler<GetProductsByNameQuery, IList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsByNameHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IList<ProductResponse>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
    {
        var res = await _productRepository.GetProductsByNameAsync(request.Name);
        return res.ToProductResponseList();
    }
}