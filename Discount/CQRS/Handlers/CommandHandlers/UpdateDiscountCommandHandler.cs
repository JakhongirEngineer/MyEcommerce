using Discount.DTOs;
using Discount.Mappers;
using Discount.Repositories;
using MediatR;

namespace Discount.CQRS.Handlers.CommandHandlers;

public class UpdateDiscountCommandHandler(IDiscountRepository discountRepository) : IRequestHandler<UpdateDiscountCommand, CouponDto>
{
    public async Task<CouponDto> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var res = await discountRepository.UpdateDiscount(request.ToEntity());
        return request.ToEntity().ToDto();
    }
}