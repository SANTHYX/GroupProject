using Infrastructure.Commons.Externals;
using Infrastructure.Externals.Imdb.Requests;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Externals.ImdbClient
{
    public class ImdbClient //:IImdbClient
    {
        /*
        private IHttpClientFactory _client;
        private ImdbGatewayOptions _options;

        public ImdbClient(IHttpClientFactory client, IOptions<ImdbGatewayOptions> options)
        {
            _client = client;
            _options = options.Value;
        }

        public async Task<TResult> FetchAsync<TResult, RQuery>(RQuery query) where RQuery : IExternalQuery, new()
        {
            var imdbClient = _client.CreateClient();
            imdbClient.BaseAddress = new Uri(_options.Url);

            //var response = await imdbClient.GetAsync();
        }
        */
    }
}
