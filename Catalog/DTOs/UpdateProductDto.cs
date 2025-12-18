using System.ComponentModel.DataAnnotations;

namespace Catalog.DTOs;

public record UpdateProductDto
{
    [Required]
    public string Id { get; init; }
    [Required]
    public string Name { get; init; }
    [Required]
    public String Summary { get; init; }
    [Required]
    public String Description { get; init; }
    
    [Required]
    public String ImageFile { get; init; }

    [Required]
    public String BrandId { get; init; }

    [Required]
    public String TypeId { get; init; }

    [Range(0.0, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public decimal Price { get; init; }
    
    public DateTimeOffset CreatedDate { get; init; }
}