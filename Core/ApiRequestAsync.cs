using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RailAPI.Core
{
    public class ApiRequestAsync
    {
        private HttpClient _httpClient;

        public ApiRequestAsync( )
        {
            _httpClient = new HttpClient();
        }

        public async Task<T?> SendPostRequestAsync<T>(HttpRequestMessage request)
        { 
            var response = await _httpClient.SendAsync(request);
            var responsString = await response.Content.ReadAsStringAsync();

            return response!.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<T>(responsString)
                : throw new Exception($"Request failed with status code: {response.StatusCode}, Response: {responsString}");
        }
    }
}
