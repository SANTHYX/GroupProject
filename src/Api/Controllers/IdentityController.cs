using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Application.Identity.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : BaseAppController
    {

        public IdentityController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : 
            base(commandDispatcher, queryDispatcher)
        {

        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUser command)
        {
            await DispatchAsync(command);

            return Ok();
        }
    }
}
