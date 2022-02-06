using Application.Commons.Externals;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Externals.ImdbClient
{
    public class ImdbGateway : IImdbGateway
    {
        private IHttpClientFactory _client;

        public ImdbGateway(IHttpClientFactory client)
        {
            _client = client;
        }

        public Task GetMovieData()
        {
            throw new System.NotImplementedException();
        }
    }
}
