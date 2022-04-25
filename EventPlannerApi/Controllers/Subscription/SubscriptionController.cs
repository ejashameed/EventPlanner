using EventPlannerApi.RequestHandlers.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace EventPlannerApi.Controllers.Subscription
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionController : ControllerBase
    {
        public IMediator _mediator; 
        public SubscriptionController(IServiceProvider serviceProvider)
        {
            _mediator = serviceProvider.GetRequiredService<IMediator>();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetSubscriptionsQuery request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
