using System.ComponentModel.DataAnnotations;

namespace Basket.DTOs;

public record CreateShoppingCartDto
{
    [Required] 
    public string UserName { get; init; }
    [Required] 
    public IList<CreateShoppingCartItemDto> Items { get; init; }
};