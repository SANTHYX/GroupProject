using Autofac;
using System.Threading.Tasks;
using System;
using Application.Commons.CQRS.Query;
using Microsoft.Extensions.Logging;

namespace Infrastructure.CQRS
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly ILogger<QueryDispatcher> _logger;
        private readonly IComponentContext _context;

        public QueryDispatcher(ILogger<QueryDispatcher> logger, IComponentContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<TResult> SendAsync<TResult, QSource>(QSource query) where QSource : class, IQuery<TResult>
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query), "Querry cannot be empty");
            }

            _logger.LogInformation($"Querry [{ query.GetType().Name }] is computing...");

            var handler = _context.Resolve<IQueryHandler<TResult, QSource>>();

            _logger.LogInformation($"Querry [{ query.GetType().Name  }] computing has end," +
                $" check your HTTP client for results");

            return await handler.HandleAsync(query);
        }
    }
}
