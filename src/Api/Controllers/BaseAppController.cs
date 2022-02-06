using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseAppController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private Guid CurrentUserId => 
            User?.Identity.IsAuthenticated == true ? Guid.Parse(User.Identity.Name) : Guid.Empty;

        public BaseAppController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : class, ICommand
        {
            if (command is AuthenticatedCommand authenticatedCommand)
            {
                authenticatedCommand.UserId = CurrentUserId;
            }

            await _commandDispatcher.DispatchAsync(command);
        }

        protected async Task<TResult> SendAsync<TResult, QSource>(QSource query) where QSource : class, IQuery<TResult>
        {
            if (query is AuthenticatedQuery<TResult> authenticatedQuery)
            {
                authenticatedQuery.UserId = CurrentUserId;
            }

            return await _queryDispatcher.SendAsync<TResult, QSource>(query);
        }          
    }
}
