using EventPlannerApi.RequestHandlers.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace EventPlannerApi.Controllers.Events
{
    [ApiController]
    [Route("[controller]")]

    public class EventsController : ControllerBase
    {
        public IMediator _mediator;

        public EventsController(IServiceProvider serviceProvider)
        {
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateEventCommand request)
        {
            var reponse = await _mediator.Send(request);
            return Ok(reponse);
        }

        [HttpGet]
        [Route("GetByClientId")]
        public async Task<IActionResult> GetByClientIdAsync([FromQuery] GetByClientIdQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
