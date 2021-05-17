using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NexGenScreening.Application.Features.Sample.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NexGenScreening.WebApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class SampleController : BaseApiController
    {
        [HttpPost("CreateSample")]
        public async Task<IActionResult> Post(CreateMyTestCommand command)
        {
            return this.Ok(await this.Mediator.Send(command));
        }
    }
}
