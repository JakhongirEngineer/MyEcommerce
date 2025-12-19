using Basket.Entities;

namespace Basket.Repositories;

public interface IShoppingCartRepository
{
    Task<ShoppingCart?> GetShoppingCartAsync(string userName);
    Task DeleteShoppingCartAsync(string userName);
    Task<ShoppingCart> UpsertShoppingCartAsync(ShoppingCart shoppingCart);
}