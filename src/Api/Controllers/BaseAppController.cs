using Application.Commons.CQRS.Command;
using Application.Commons.CQRS.Query;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseAppController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public BaseAppController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            await _commandDispatcher.DispatchAsync(command);
        }

        protected async Task<TResult> SendAsync<TResult, QSource>(QSource query) where QSource : IQuery<TResult>
            => await _queryDispatcher.SendAsync<TResult, QSource>(query);
    }
}
