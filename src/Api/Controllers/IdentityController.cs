using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Application.Identity.Commands.LoginUser;
using Application.Identity.Commands.RegisterUser;
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

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] SignUp command)
        {
            await DispatchAsync(command);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] SignIn command)
        {
            await DispatchAsync(command);

            return Ok(command.Token);
        }
    }
}
