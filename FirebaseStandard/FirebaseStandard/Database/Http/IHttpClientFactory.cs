using System;

namespace FirebaseStandard
{
    public interface IHttpClientFactory
    {
        IHttpClientProxy GetHttpClient(TimeSpan? timeout);
    }
}
