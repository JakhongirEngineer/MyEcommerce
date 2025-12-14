namespace Catalog.Specifications;

public class CatalogSpecParams
{
    private const int MaxPageSize = 50;
    
    private int _pageSize = 10;
    
    public int PageIndex { get; set; } = 0;
    
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
    
    public string? ProductBrandId  { get; set; }
    
    public string? ProductTypeId { get; set; }
    
    public string? Sort { get; set; }
    
    public string? Search { get; set; }
}