using Catalog.Commands;
using Catalog.Mappers;
using Catalog.Repositories;
using Catalog.Responses;
using MediatR;

namespace Catalog.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductBrandRepository _productBrandRepository;
    private readonly IProductTypeRepository _productTypeRepository;
    public  CreateProductCommandHandler(IProductRepository productRepository, IProductBrandRepository productBrandRepository, IProductTypeRepository productTypeRepository)
    {
        _productRepository = productRepository;
        _productBrandRepository = productBrandRepository;
        _productTypeRepository = productTypeRepository;
    }
    
    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var brand = await _productBrandRepository.GetProductBrandByIdAsync(request.BrandId);
        var type = await _productTypeRepository.GetProductTypeByIdAsync(request.TypeId);

        var product = request.ToProduct();
        product.Brand = brand;
        product.Type = type;

        var res = await _productRepository.CreateProductAsync(product);
        return res.ToProductResponse();
    }
}