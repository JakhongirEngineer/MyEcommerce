namespace Basket.DTOs;

public record ShoppingCartDto
{
    public string UserName { get; init; }
    public IList<ShoppingCartItemDto> Items { get; init; }
};