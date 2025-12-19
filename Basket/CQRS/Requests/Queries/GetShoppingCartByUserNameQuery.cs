using Basket.CQRS.Responses;
using MediatR;

namespace Basket.CQRS.Requests.Queries;

public record GetShoppingCartByUserNameQuery(string UserName) : IRequest<ShoppingCartResponse>;