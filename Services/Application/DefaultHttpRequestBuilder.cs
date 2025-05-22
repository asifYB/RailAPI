using System.Net.Http.Headers;
using System.Text;

namespace RailAPI.Services.Application
{
    public class DefaultHttpRequestBuilder
    {

        public static HttpRequestMessage BuildPostRequest(string url, string payload, string accessToken, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            };

            // Add Authorization header
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Add custom headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            return request;
        }

        public static HttpRequestMessage BuildGetRequest(string url, string payload, string accessToken, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            };

            // Add Authorization header
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Add custom headers
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }

            return request;
        }
    }
}
