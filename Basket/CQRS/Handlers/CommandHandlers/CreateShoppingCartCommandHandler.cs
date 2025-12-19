using Basket.CQRS.Requests.Commands;
using Basket.CQRS.Responses;
using Basket.Mappers;
using Basket.Repositories;
using MediatR;

namespace Basket.CQRS.Handlers.CommandHandlers;

public class CreateShoppingCartCommandHandler(IShoppingCartRepository repository) : IRequestHandler<CreateShoppingCartCommand, ShoppingCartResponse>
{
    public async Task<ShoppingCartResponse> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
    {
        var shoppingCart = request.ToEntity();
        var res = await repository.UpsertShoppingCartAsync(shoppingCart);
        return res.ToResponse();
    }
}