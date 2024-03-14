using MediatorPattern.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MediatorPattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllRecords")]
        public async Task<IActionResult> Get()
            => Ok(await _mediator.Send(new View()));

        [HttpGet("GetRecordsById")]
        public async Task<IActionResult> GetById([Required] int id)
            => Ok(await _mediator.Send(new ViewById { id = id }));

        [HttpPost("AddNewRegister")]
        public async Task<IActionResult> Add(Create handler)
            => Ok(await _mediator.Send(handler));

        [HttpPut("UpdateRecords")]
        public async Task<IActionResult> Update([Required] int id, Update handler)
        {
            handler.Id = id;
            return Ok(await _mediator.Send(handler));
        }

        [HttpDelete("DeleteRecords")]
        public async Task<IActionResult> Delete([Required] int id)
            => Ok(await _mediator.Send(new Delete { Id = id }));
    }
}