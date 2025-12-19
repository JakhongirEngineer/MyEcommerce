using Catalog.Commands;
using Catalog.DTOs;
using Catalog.Mappers;
using Catalog.Queries;
using Catalog.Responses;
using Catalog.Specifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] CreateProductDto createProductDto)
    {
        var command = createProductDto.ToCommand();
        var res = await _mediator.Send(command);
        var productDto = res.ToDto();
        return Ok(productDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        var command = new DeleteProductByIdCommand(Id: id);
        var res = await _mediator.Send(command);
        if (res)
        {
            return NoContent();
        }
        return NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateProductDto)
    {
        var command = updateProductDto.ToCommand();
        var res = await _mediator.Send(command);
        if (!res)
        {
            return NotFound();
        }

        return NoContent();
    }
    
    [HttpGet]
    public async Task<ActionResult<Pagination<ProductResponse>>> GetAllProductsAsync([FromQuery] CatalogSpecParams catalogSpecParams)
    {
        var query = new GetProductsByParamsQuery(catalogSpecParams);
        var res = await _mediator.Send(query);
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProductByIdAsync([FromRoute] string id)
    {
        var query = new GetProductByIdQuery(Id: id);

        var res = await _mediator.Send(query);
        var dto = res.ToDto();
        return Ok(dto);
    }

    [HttpGet("brand-name/{brandName}")]
    public async Task<ActionResult<IList<ProductDto>>> GetProductsByBrandNameAsync([FromRoute] string brandName)
    {
        var query = new GetProductsByBrandQuery(ProductBrandName: brandName);
        var res = await _mediator.Send(query);
        var dtos = res.ToDtos();
        return Ok(dtos);
    }

    [HttpGet("name/{name}")]
    public async Task<ActionResult<IList<ProductDto>>> GetProductsByNameAsync([FromRoute] string name)
    {
        var query = new GetProductsByNameQuery(Name: name);
        var res = await _mediator.Send(query);
        var dtos = res.ToDtos();
        return Ok(dtos);
    }

}