using Discount.CQRS.Requests.Queries;
using Discount.DTOs;
using Discount.Mappers;
using Discount.Repositories;
using MediatR;

namespace Discount.CQRS.Handlers.QueryHandlers;

public class GetDiscountQueryHandler(IDiscountRepository discountRepository) : IRequestHandler<GetDiscountQuery, CouponDto>
{
    public async Task<CouponDto> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
    {
        var res = await discountRepository.GetDiscount(request.ProductName);
        return res.ToDto();
    }
}