namespace Basket.DTOs;

public record ShoppingCartItemDto
{
     public string ProductId  { get; init; }
     public string ProductName { get; init; }
     public decimal Price  { get; init; }
     public int Quantity { get; init; }
     public string ImageFile { get; init; }
}