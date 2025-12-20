using Discount.DTOs;
using MediatR;

namespace Discount.CQRS.Handlers.CommandHandlers;

public record CreateDiscountCommand(string ProductName, string Description, int Amount) : IRequest<CouponDto>;