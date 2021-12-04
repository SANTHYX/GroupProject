using System;

namespace Application.Commons.Providers
{
    public interface IServerDetailsProvider
    {
        Uri GetBaseServerUrl();
    }
}
