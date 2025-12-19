using Basket.CQRS.Requests.Commands;
using Basket.CQRS.Requests.Queries;
using Basket.DTOs;
using Basket.Mappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Controllers;

[ApiController]
[Route("api/v1/shopping-cart")]
public class ShoppingCartController(IMediator mediator) : ControllerBase
{
    [HttpGet("{userName}")]
    public async Task<ActionResult<ShoppingCartDto>> GetShoppingCartAsync([FromRoute] string userName)
    {
        var res = await mediator.Send(new GetShoppingCartByUserNameQuery(userName));
        var dto = res.ToDto();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingCartDto>> UpsertShoppingCartAsync(
        [FromBody] CreateShoppingCartDto createShoppingCartDto)
    {
        var command = createShoppingCartDto.ToCommand();
        var res = await mediator.Send(command);
        var dto = res.ToDto();
        return Ok(dto);
    }

    [HttpDelete("{userName}")]
    public async Task<ActionResult> DeleteShoppingCartAsync([FromRoute] string userName)
    {
        var command = new DeleteShoppingCartByUserNameCommand(userName);
        var res = await mediator.Send(command);
        if (res)
        {
            return NoContent();
        }

        return NotFound();
    }
}