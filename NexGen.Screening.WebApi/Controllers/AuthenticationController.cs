using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexGenScreening.Application.DTOs.Authentication;
using NexGenScreening.Application.Interfaces.Services;
using System.Threading.Tasks;

namespace NexGen.Screening.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        #region "Action Methods"
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return this.Ok(await this.authenticationService.AuthenticateAsync(request, this.GenerateIPAddress()));
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken([FromBody] RefreshTokenRequest tokenRequest)
        {
            return this.Ok(await this.authenticationService.RefreshTokenAsync(tokenRequest, this.GenerateIPAddress()));
        }

        [AllowAnonymous]
        [HttpPost("revoke-token")]
        public async Task<ActionResult> RevokeToken([FromBody] RevokeTokenRequest revoketoken)
        {
            return this.Ok(await this.authenticationService.RevokeTokenAsync(revoketoken, this.GenerateIPAddress()));
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<ActionResult> ForgotPassword([FromBody] ForgotPasswordRequest forgotPasswordModel)
        {
            return this.Ok(await this.authenticationService.ForgotPassword(forgotPasswordModel));
        }
        #endregion

        #region "Private Methods"
        private string GenerateIPAddress()
        {
            if (this.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return this.Request.Headers["X-Forwarded-For"];
            }
            else
            {
                return this.HttpContext.Connection.RemoteIpAddress.MapToIPv6().ToString();
            }
        }
        #endregion
    }
}
