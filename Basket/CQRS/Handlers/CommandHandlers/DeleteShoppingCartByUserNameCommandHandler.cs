using Basket.CQRS.Requests.Commands;
using Basket.Repositories;
using MediatR;

namespace Basket.CQRS.Handlers.CommandHandlers;

public class DeleteShoppingCartByUserNameCommandHandler(IShoppingCartRepository shoppingCartRepository) : IRequestHandler<DeleteShoppingCartByUserNameCommand, bool>
{
    public async Task<bool> Handle(DeleteShoppingCartByUserNameCommand request, CancellationToken cancellationToken)
    {
        await shoppingCartRepository.DeleteShoppingCartAsync(request.UserName);
        return true;
    }
}