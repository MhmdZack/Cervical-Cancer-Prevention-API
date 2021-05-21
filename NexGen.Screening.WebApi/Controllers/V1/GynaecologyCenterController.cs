using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NexGenScreening.Application.Features.Commands;
using NexGenScreening.Application.Features.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexGenScreening.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class GynaecologyCenterController : BaseApiController
    {
        [HttpPost]
        [Route("CreateGyna")]
        public async Task<IActionResult> Post(CreateGynaCenterCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }

        [HttpPost]
        [Route("GetAllGynaecologyCenters")]
        public async Task<IActionResult> GetAllHccByClientId(GetAllGynaecologyQuery request)
        {
            return this.Ok(await this.Mediator.Send(request));
        }

        [HttpPost]
        [Route("GetGynaecologyCenter")]
        public async Task<IActionResult> GetHccByHccCode(GetGynaCenterByCode request)
        {
            return this.Ok(await this.Mediator.Send(request));
        }
    }
}