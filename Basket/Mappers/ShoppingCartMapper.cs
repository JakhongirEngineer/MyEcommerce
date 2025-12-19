using Basket.CQRS.Requests.Commands;
using Basket.CQRS.Responses;
using Basket.DTOs;
using Basket.Entities;

namespace Basket.Mappers;

public static class ShoppingCartMapper
{
    public static ShoppingCartResponse ToResponse(this ShoppingCart shoppingCart)
    {
        return new ShoppingCartResponse(shoppingCart.UserName, shoppingCart.Items.ToResponse());
    }

    public static IList<ShoppingCartItemResponse> ToResponse(this IList<ShoppingCartItem> items)
    {
        return items.Select(item => item.ToResponse()).ToList();
    }

    public static ShoppingCartItemResponse ToResponse(this ShoppingCartItem shoppingCartItem)
    {
        return new ShoppingCartItemResponse(
            ProductName: shoppingCartItem.ProductName,
            ProductId: shoppingCartItem.ProductId,
            Quantity: shoppingCartItem.Quantity,
            Price: shoppingCartItem.Price,
            ImageFile: shoppingCartItem.ImageFile);
    }

    public static ShoppingCart ToEntity(this CreateShoppingCartCommand command)
    {
        return new ShoppingCart()
        {
            UserName = command.UserName,
            Items = command.Items.ToEntity()
        };
    }

    public static IList<ShoppingCartItem> ToEntity(this IList<CreateShoppingCartItemDto> items)
    {
        return items.Select(item => item.ToEntity()).ToList();
    }

    public static ShoppingCartItem ToEntity(this CreateShoppingCartItemDto itemDto)
    {
        return new ShoppingCartItem()
        {
            ProductId = itemDto.ProductId,
            ProductName = itemDto.ProductName,
            Quantity = itemDto.Quantity,
            Price = itemDto.Price,
            ImageFile = itemDto.ImageFile
        };
    }

    public static ShoppingCartDto ToDto(this ShoppingCartResponse response)
    {
        return new ShoppingCartDto()
        {
            UserName = response.UserName,
            Items = response.Items.ToDto(),
        };
    }

    public static IList<ShoppingCartItemDto> ToDto(this IList<ShoppingCartItemResponse> items)
    {
        return items.Select(item => item.ToDto()).ToList();
    }

    public static ShoppingCartItemDto ToDto(this ShoppingCartItemResponse response)
    {
        return new ShoppingCartItemDto
        {
            ProductId = response.ProductId,
            ProductName = response.ProductName,
            Quantity = response.Quantity,
            Price = response.Price,
            ImageFile = response.ImageFile
        };
    }

    public static CreateShoppingCartCommand ToCommand(this CreateShoppingCartDto dto)
    {
        return new CreateShoppingCartCommand(UserName: dto.UserName, Items: dto.Items);
    }
}