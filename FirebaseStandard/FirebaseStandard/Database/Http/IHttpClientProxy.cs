using System;
using System.Net.Http;

namespace FirebaseStandard
{
    public interface IHttpClientProxy : IDisposable
    {
        HttpClient GetHttpClient();
    }
}
