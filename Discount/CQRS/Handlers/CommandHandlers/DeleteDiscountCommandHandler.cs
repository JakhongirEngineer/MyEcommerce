using Discount.Repositories;
using MediatR;

namespace Discount.CQRS.Handlers.CommandHandlers;

public class DeleteDiscountCommandHandler(IDiscountRepository discountRepository) : IRequestHandler<DeleteDiscountCommand, bool>
{
    public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
    {
        var res = await discountRepository.DeleteDiscount(request.ProductName);
        return res;
    }
}