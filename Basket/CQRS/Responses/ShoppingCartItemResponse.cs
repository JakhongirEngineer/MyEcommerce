namespace Basket.CQRS.Responses;

public record ShoppingCartItemResponse(
    string ProductName,
    string ProductId,
    int Quantity,
    decimal Price,
    string ImageFile);