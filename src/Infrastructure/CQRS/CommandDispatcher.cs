using System.Threading.Tasks;
using Autofac;
using System;
using Application.Commons.CQRS.Command;
using Microsoft.Extensions.Logging;

namespace Infrastructure.CQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ILogger<CommandDispatcher> _logger;
        private readonly IComponentContext _context;

        public CommandDispatcher(ILogger<CommandDispatcher> logger, IComponentContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task DispatchAsync<T>(T command) where T : class, ICommand
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command), "Command is empty");
            }

            var handler = _context.Resolve<ICommandHandler<T>>();

            _logger.LogInformation($"Command [{ command.GetType().Name }] is resolving...");

            await handler.HandleAsync(command);

            _logger.LogInformation($"Command [{ command.GetType().Name }] has been resolved succesfuly");
        }
    }
}
