using Basket.CQRS.Responses;
using Basket.DTOs;
using MediatR;

namespace Basket.CQRS.Requests.Commands;

public record CreateShoppingCartCommand(string UserName, IList<CreateShoppingCartItemDto> Items) : IRequest<ShoppingCartResponse>;