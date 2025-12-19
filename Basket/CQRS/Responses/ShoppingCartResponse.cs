namespace Basket.CQRS.Responses;

public record ShoppingCartResponse(string UserName, IList<ShoppingCartItemResponse> Items);