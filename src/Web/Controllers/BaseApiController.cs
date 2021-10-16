using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private Guid UserId => User.Identity.IsAuthenticated ? 
            Guid.Parse(User.Identity.Name) : Guid.Empty;

        public BaseApiController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command is AuthenticatedCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = UserId;
            }
            await _commandDispatcher.DispatchAsync(command);
        }

        protected async Task<TResult> SendAsync<TResult, QSource>(QSource query) where QSource : IQuery<TResult>
            => await _queryDispatcher.SendAsync<TResult, QSource>(query);
        
    }
}
