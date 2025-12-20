using Discount.CQRS.Handlers.CommandHandlers;
using Discount.DTOs;
using Discount.Entities;
using Discount.Grpc;

namespace Discount.Mappers;

public static class DiscountMapper
{
    public static CouponDto ToDto(this Coupon coupon)
    {
        return new CouponDto(coupon.Id, coupon.ProductName, coupon.Description, coupon.Amount);
    }

    public static Coupon ToEntity(this CreateDiscountCommand command)
    {
        return new Coupon()
        {
            ProductName = command.ProductName,
            Description = command.Description,
            Amount = command.Amount
        };
    }

    public static Coupon ToEntity(this UpdateDiscountCommand command)
    {
        return new Coupon()
        {
            Id = command.Id,
            ProductName = command.ProductName,
            Description = command.Description,
            Amount = command.Amount
        };
    }

    public static CouponModel ToModel(this CouponDto dto)
    {
        return new CouponModel()
        {
            Id = dto.Id,
            Amount = dto.Amount,
            Description = dto.Description,
            ProductName = dto.ProductName,
        };
    }

    public static CreateDiscountCommand ToCommand(this CreateDiscountRequest request)
    {
        return new CreateDiscountCommand(ProductName: request.Coupon.ProductName,
            Description: request.Coupon.Description, Amount: request.Coupon.Amount);
    }
    
    public static UpdateDiscountCommand ToCommand(this UpdateDiscountRequest request)
    {
        return new UpdateDiscountCommand(Id: request.Coupon.Id, ProductName: request.Coupon.ProductName,
            Description: request.Coupon.Description, Amount: request.Coupon.Amount);
    }
}