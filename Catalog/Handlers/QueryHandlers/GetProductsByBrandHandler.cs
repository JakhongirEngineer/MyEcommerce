using Catalog.Mappers;
using Catalog.Queries;
using Catalog.Repositories;
using Catalog.Responses;
using MediatR;

namespace Catalog.Handlers;

public class GetProductsByBrandHandler : IRequestHandler<GetProductsByBrandQuery, IList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsByBrandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IList<ProductResponse>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
    {
        var res = await _productRepository.GetProductsByBrandAsync(request.ProductBrandName);
        return res.ToProductResponseList();
    }
}