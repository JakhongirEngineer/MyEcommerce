using Basket.CQRS.Requests.Queries;
using Basket.CQRS.Responses;
using Basket.Mappers;
using Basket.Repositories;
using MediatR;

namespace Basket.CQRS.Handlers.QueryHandlers;

public class GetShoppingCartByUserNameQueryHandler(IShoppingCartRepository shoppingCartRepository) : IRequestHandler<GetShoppingCartByUserNameQuery, ShoppingCartResponse>
{
    public async Task<ShoppingCartResponse> Handle(GetShoppingCartByUserNameQuery request, CancellationToken cancellationToken)
    {
        var res = await shoppingCartRepository.GetShoppingCartAsync(request.UserName);
        if (res == null)
        {
            return new ShoppingCartResponse(UserName: request.UserName, Items: []);
        }

        return res.ToResponse();
    }
}