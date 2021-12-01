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

        public async Task<TResult> SendAsync<TResult, QSource>(QSource query) where QSource : IQuery<TResult>
        {
            _logger.LogInformation($"Querry { typeof(QSource) } is computing...");

            if (query is null)
            {
                throw new ArgumentNullException(nameof(query), "Querry cannot be empty");
            }

            var handler = _context.Resolve<IQueryHandler<TResult, QSource>>();

            _logger.LogInformation($"Querry { typeof(QSource) } computing has end," +
                $" check your Http client for results");

            return await handler.HandleAsync(query);
        }
    }
}
