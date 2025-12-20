using Discount.DTOs;
using Discount.Mappers;
using Discount.Repositories;
using MediatR;

namespace Discount.CQRS.Handlers.CommandHandlers;

public class CreateDiscountCommandHandler(IDiscountRepository discountRepository) : IRequestHandler<CreateDiscountCommand, CouponDto>
{
    public async Task<CouponDto> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var res = await discountRepository.CreateDiscount(request.ToEntity());

        return request.ToEntity().ToDto();
    }
}