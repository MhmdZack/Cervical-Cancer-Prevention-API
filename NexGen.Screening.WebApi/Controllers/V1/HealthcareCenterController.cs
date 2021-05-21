using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexGenScreening.Application.Features.Commands;
using NexGenScreening.Application.Features.Queries;
using System.Threading.Tasks;

namespace NexGenScreening.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    //[Authorize]
    public class HealthcareCenterController : BaseApiController
    {
        [HttpPost]
        [Route("CreateHcc")]
        public async Task<IActionResult> Post(CreateHealthcareCenterCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPut]
        [Route("UpdateHcc")]
        public async Task<IActionResult> UpdateHealthcareCenter(UpdateHealthcareCenterCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllHcc")]
        public async Task<IActionResult> GetAllHccByClientId(GetAllHccQuery request)
        {
            return this.Ok(await this.Mediator.Send(request));
        }

        [HttpPost]
        [Route("GetHcc")]
        public async Task<IActionResult> GetHccByHccCode(GetHccByHccCode request)
        {
            return this.Ok(await this.Mediator.Send(request));
        }
    }
}
