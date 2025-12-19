using System.ComponentModel.DataAnnotations;

namespace Basket.DTOs;

public record CreateShoppingCartItemDto
{
    [Required]
    public string ProductId { get; init; }
    [Required]
    public string ProductName { get; init; }
    [Required]
    public decimal Price { get; init; }
    [Range(1, int.MaxValue)]
    public int Quantity { get; init; }
    [Required]
    public string ImageFile { get; init; }
};