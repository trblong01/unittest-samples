using MediatR;
using Microsoft.AspNetCore.Mvc;
using Clothes.Application.CreateClothe;
using Clothes.Application.DeleteClothe;

namespace Clothes.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClotheController(IMediator _mediator) : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> CreateClothe([FromBody] CreateClotheCommand command)
    {
        var result = await _mediator.Send(command);
        
        if(result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);            
    }
  
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClothe(Guid id)
    {
        var result = await _mediator.Send(new DeleteClotheCommand(id));
        
        if(result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);            
    }

}
