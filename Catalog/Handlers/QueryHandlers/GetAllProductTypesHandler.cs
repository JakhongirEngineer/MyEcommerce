using Catalog.Mappers;
using Catalog.Queries;
using Catalog.Repositories;
using Catalog.Responses;
using MediatR;

namespace Catalog.Handlers;

public class GetAllProductTypesHandler : IRequestHandler<GetAllProductTypesQuery, IList<ProductTypeResponse>>
{
    private readonly IProductTypeRepository _productTypeRepository;
    
    public GetAllProductTypesHandler(IProductTypeRepository repository)
    {
        _productTypeRepository = repository;    
    }
    
    public async Task<IList<ProductTypeResponse>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
    {
        var res = await _productTypeRepository.GetProductTypesAsync();
        return res.ToProductTypeResponseList();
    }
}