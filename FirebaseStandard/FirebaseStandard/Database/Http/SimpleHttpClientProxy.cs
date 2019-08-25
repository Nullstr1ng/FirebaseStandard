using System.Net.Http;

namespace FirebaseStandard
{
    internal sealed class SimpleHttpClientProxy : IHttpClientProxy
    {
        private readonly HttpClient _httpClient;

        public SimpleHttpClientProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HttpClient GetHttpClient()
        {
            return _httpClient;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
