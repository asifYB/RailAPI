using System.Text.Json;

namespace RailAPI.Core
{
    public class ApiRequest
    {
        private static readonly HttpClient _httpClient = new();

        public static async Task<T?> SendPostRequestAsync<T>(HttpRequestMessage request)
        {
            try
            {
                var response = await _httpClient.SendAsync(request);
                var responsString = await response.Content.ReadAsStringAsync();

                return response!.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<T>(responsString)
                    : throw new Exception($"Request failed with status code: {response.StatusCode}, Response: {responsString}");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new Exception($"An error occurred while sending the POST request: {ex.Message}", ex);
            }
        }

        public static async Task<T?> SendGetRequestAsync<T>(HttpRequestMessage request)
        {
            var response = await _httpClient.SendAsync(request);
            var responsString = await response.Content.ReadAsStringAsync();

            return response!.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<T>(responsString)
                : throw new Exception($"Request failed with status code: {response.StatusCode}, Response: {responsString}");
        }
    }
}
