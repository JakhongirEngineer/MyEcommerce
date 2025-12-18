using Catalog.Mappers;
using Catalog.Queries;
using Catalog.Repositories;
using Catalog.Responses;
using Catalog.Specifications;
using MediatR;

namespace Catalog.Handlers;

public class GetProductsByParamsHandler : IRequestHandler<GetProductsByParamsQuery, Pagination<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsByParamsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<Pagination<ProductResponse>> Handle(GetProductsByParamsQuery request, CancellationToken cancellationToken)
    {
        var res = await _productRepository.GetProductsByParamsAsync(request.Params);
        return res.ToPaginationProductResponse();
    }
}