using Catalog.DTOs;
using Catalog.Mappers;
using Catalog.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[ApiController]
[Route("api/v1/types")]
public class TypeController : ControllerBase
{
    private readonly IMediator _mediator;
    public TypeController(IMediator  mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IList<ProductTypeDto>>> GetAllProductTypesAsync()
    {
        var query = new GetAllProductTypesQuery();
        var res = await _mediator.Send(query);
        var dtos = res.ToDtos();
        return Ok(dtos);
    }
}