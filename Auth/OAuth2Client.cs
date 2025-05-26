using System.Net.Http.Headers;
using System.Text;
using RailAPI.Core;
using RailAPI.Models.Auth;
using RailAPI.Utils;

namespace RailAPI.Auth
{
    public class OAuth2Client
    {
        string clientId = "0oapp5xj900eaGHvL697";
        string clientSecret = "77b7UiVrbsA6HncnGXE3erxN-wIvyyDMaYcAi0XpKqPDV_7ViuW8RmSphIB-mc9-";

         

        public OAuth2Client() { 
        }

        public async Task<string> GetAccessTokenAsync(string scopes)
        {
            using var httpClient = new HttpClient();

            var authString = $"{clientId}:{clientSecret}";
            var base64Auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(authString));

            var request = new HttpRequestMessage(HttpMethod.Post, URLConstants.TokenEndpoint);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Auth);

            // Set form-urlencoded body content
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "scope", scopes }
            });

            var response = await ApiRequest.SendPostRequestAsync<TokenResponse>(request);
            return response!.AccessToken;
        }
    }
}
