using Catalog.Commands;
using Catalog.Mappers;
using Catalog.Repositories;
using MediatR;

namespace Catalog.Handlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    private readonly IProductBrandRepository _productBrandRepository;
    private readonly IProductTypeRepository _productTypeRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository,
        IProductBrandRepository productBrandRepository, IProductTypeRepository productTypeRepository)
    {
        _productRepository = productRepository;
        _productBrandRepository = productBrandRepository;
        _productTypeRepository = productTypeRepository;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var oldProduct = await _productRepository.GetProductByIdAsync(request.Id) ??
                         throw new NullReferenceException("Product not found");

        var product = request.ToProduct(oldProduct);
        if (request.TypeId != null && request.TypeId != oldProduct.Type.Id)
        {
            var type = await _productTypeRepository.GetProductTypeByIdAsync(request.TypeId) ??
                       throw new NullReferenceException("Product Type not found");
            product.Type = type;
        }

        if (request.BrandId != null && request.BrandId != oldProduct.Brand.Id)
        {
            var brand = await _productBrandRepository.GetProductBrandByIdAsync(request.BrandId) ??
                        throw new NullReferenceException("Product brand not found");
            product.Brand = brand;
        }


        var res = await _productRepository.UpdateProductAsync(product);
        return res;
    }
}