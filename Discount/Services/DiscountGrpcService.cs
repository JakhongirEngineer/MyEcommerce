using Discount.CQRS.Handlers.CommandHandlers;
using Discount.CQRS.Requests.Queries;
using Discount.Grpc;
using Discount.Mappers;
using Grpc.Core;
using MediatR;

namespace Discount.Services;

public class DiscountGrpcService(IMediator mediator): DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var res = await mediator.Send(new GetDiscountQuery(request.ProductName));
        return res.ToModel();
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var res = await mediator.Send(request.ToCommand());
        return res.ToModel();
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var res = await mediator.Send(request.ToCommand());
        return res.ToModel();
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var res = await mediator.Send(new DeleteDiscountCommand(request.ProductName));
        return new DeleteDiscountResponse
        {
            Success = res
        };
    }
}