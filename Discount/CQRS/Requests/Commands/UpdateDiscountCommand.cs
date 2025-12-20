using Discount.DTOs;
using MediatR;

namespace Discount.CQRS.Handlers.CommandHandlers;

public record UpdateDiscountCommand(int Id, string ProductName, string Description, int Amount) : IRequest<CouponDto>;