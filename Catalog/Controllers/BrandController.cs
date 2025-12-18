using Catalog.DTOs;
using Catalog.Mappers;
using Catalog.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BrandController : ControllerBase
{
    private readonly IMediator _mediator;

    public BrandController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IList<ProductBrandDto>>> GetAllProductBrandsAsync()
    {
        var query = new GetAllProductBrandsQuery();
        var res = await _mediator.Send(query);
        var dtos = res.ToDtos();
        return Ok(dtos);
    }
}