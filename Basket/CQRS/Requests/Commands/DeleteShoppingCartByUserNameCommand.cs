using MediatR;

namespace Basket.CQRS.Requests.Commands;

public record DeleteShoppingCartByUserNameCommand(string UserName) : IRequest<bool>;