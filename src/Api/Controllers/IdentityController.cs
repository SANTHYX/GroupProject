using Api.Models;
using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Application.Identity.Commands.ChangeCreedentials;
using Application.Identity.Commands.LoginUser;
using Application.Identity.Commands.LoginUser.Dto;
using Application.Identity.Commands.RecoveryAccess;
using Application.Identity.Commands.RefreshToken;
using Application.Identity.Commands.RegisterUser;
using Application.Identity.Commands.RevokeToken;
using Application.Identity.Commands.SetPasswordAtRecovery;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : BaseAppController
    {

        public IdentityController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) 
            : base(commandDispatcher, queryDispatcher)
        {

        }
        
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUpAsync([FromBody] SignUp command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignInAsync([FromBody] SignIn command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse<TokenModel>.Success(command.Token));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] RefreshToken command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse<TokenModel>.Success(command.Token));
        }

        [HttpPost("refresh-token/{refresh}/revoke")]
        public async Task<IActionResult> RevokeTokenAsync([FromRoute] string refresh)
        {
            RevokeToken command = new() { Refresh = refresh };

            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }

        [HttpPost("recovery-access")]
        public async Task<IActionResult> RecoveryAccessAsync([FromBody] RecoveryAccess command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }

        [HttpPut("change-credentials")]
        public async Task<IActionResult> ChangeCredentialsAsync([FromBody] ChangeCreedentials command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }

        [HttpPut("recovery-access/password")]
        public async Task<IActionResult> SetPasswordAtRecoveryAsync([FromBody] SetPasswordAtRecovery command)
        {
            await DispatchAsync(command);

            return Ok(ApiResponse.Success());
        }
    }
}
