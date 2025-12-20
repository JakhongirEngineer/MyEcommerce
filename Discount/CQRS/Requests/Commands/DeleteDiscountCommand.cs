using MediatR;

namespace Discount.CQRS.Handlers.CommandHandlers;

public record DeleteDiscountCommand(string ProductName) : IRequest<bool>;
