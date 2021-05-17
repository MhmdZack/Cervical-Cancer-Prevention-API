using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexGenScreening.Application.Features.HealthcareCenters.Commands;
using System.Threading.Tasks;

namespace NexGenScreening.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    //[Authorize]
    public class HealthcareCenterController : BaseApiController
    {
        [HttpPost("CreateHealthCare")]
        public async Task<IActionResult> Post(CreateHealthcareCenterCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }
    }
}
