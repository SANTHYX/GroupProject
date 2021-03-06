using Application.Commons.Providers;
using Microsoft.AspNetCore.Http;
using System;

namespace Infrastructure.Providers
{
    public class ServerDetailsProvider : IServerDetailsProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ServerDetailsProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Uri GetBaseServerUrl()
        {
            var request = _httpContextAccessor.HttpContext.Request;

            return new($"{ request.Scheme }://{ request.Host.ToUriComponent() }");
        }
    }
}
