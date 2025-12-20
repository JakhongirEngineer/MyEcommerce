using Discount.DTOs;
using MediatR;

namespace Discount.CQRS.Requests.Queries;

public record GetDiscountQuery(string ProductName) : IRequest<CouponDto>;