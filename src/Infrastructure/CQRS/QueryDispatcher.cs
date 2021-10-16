using Autofac;
using System.Threading.Tasks;
using System;
using Application.Commons.CQRS.Query;

namespace Infrastructure.CQRS
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _context;

        public QueryDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task<TResult> SendAsync<TResult, QSource>(QSource query) where QSource : IQuery<TResult>
        {
            if (query is null)
            {
                throw new ArgumentNullException(nameof(query), "Querry cannot be empty");
            }
            var handler = _context.Resolve<IQueryHandler<TResult, QSource>>();

            return await handler.HandleAsync(query);
        }
    }
}
