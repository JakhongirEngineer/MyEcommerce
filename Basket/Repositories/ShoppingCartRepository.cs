using Basket.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly IDistributedCache _distributedCache;

    public ShoppingCartRepository(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }
    
    public async Task<ShoppingCart?> GetShoppingCartAsync(string userName)
    {
        var shoppingCartString = await _distributedCache.GetStringAsync(userName);
        if (string.IsNullOrEmpty(shoppingCartString))
        {
            return null;
        }
        return JsonConvert.DeserializeObject<ShoppingCart>(shoppingCartString);
    }

    public async Task DeleteShoppingCartAsync(string userName)
    {
        await _distributedCache.RemoveAsync(userName);
    }

    public async Task<ShoppingCart> UpsertShoppingCartAsync(ShoppingCart shoppingCart)
    {
        await _distributedCache.SetStringAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));
        return await GetShoppingCartAsync(shoppingCart.UserName);
    }
}