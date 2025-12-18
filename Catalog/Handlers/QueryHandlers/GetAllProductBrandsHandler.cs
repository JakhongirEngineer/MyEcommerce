using Catalog.Mappers;
using Catalog.Queries;
using Catalog.Repositories;
using Catalog.Responses;
using MediatR;

namespace Catalog.Handlers;

public class GetAllProductBrandsHandler : IRequestHandler<GetAllProductBrandsQuery, IList<ProductBrandResponse>>
{
    private readonly IProductBrandRepository _productBrandRepository;
    public GetAllProductBrandsHandler(IProductBrandRepository repository)
    {
        _productBrandRepository = repository;
    }
    
    public async Task<IList<ProductBrandResponse>> Handle(GetAllProductBrandsQuery request, CancellationToken cancellationToken)
    {
        var productBrands =  await _productBrandRepository.GetAllBrandsAsync();
        return productBrands.ToProductBrandResponseList();
    }
}