using Newtonsoft.Json;
using System.Net;

namespace Weather.ExternalServices.Wrapper
{
    public class WrapperApiService : IWrapperApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public WrapperApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<T> GetAsync<T>(string wrapperApi, string url)
        {
            var client = GetHttpClient(wrapperApi);
            var response = await client.GetAsync(url);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<T>(responseString);
                return result;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("Resource Not Found");
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new Exception("Invalid city name provided");
            }
            else
            {
                throw new Exception(responseString);
            }
        }
        private HttpClient GetHttpClient(string wrapperApi)
        {
            var client = _httpClientFactory.CreateClient(wrapperApi);
            return client;
        }
    }
}
