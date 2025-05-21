using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using RailAPI.Core;
using RailAPI.Models.Auth;
using static System.Formats.Asn1.AsnWriter;

namespace RailAPI.Auth
{
    public class OAuth2Client
    {
        string clientId = "YOUR_CLIENT_ID";
        string clientSecret = "YOUR_CLIENT_SECRET";
        string authEndpoint = "https://auth.layer2financial.com/oauth2/ausbdqlx69rH6OjWd696/v1/token";  
        string scopes = "customers:read accounts:read"; // we can add more scopes if needed separated by comma


        private ApiRequestAsync _apiRequestAsync;

        public OAuth2Client() {
            _apiRequestAsync = new ApiRequestAsync();
        }

        public async Task<string> GetAccessTokenAsync()
        {
            using var httpClient = new HttpClient();

            // Base64 encode clientId:clientSecret
            var authString = $"{clientId}:{clientSecret}";
            var base64Auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(authString));

            // Prepare request
            var request = new HttpRequestMessage(HttpMethod.Post, $"{authEndpoint}?grant_type=client_credentials&scope={scopes}");

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.CacheControl = new CacheControlHeaderValue { NoCache = true };
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Auth);

            request.Content = new StringContent("", Encoding.UTF8, "application/json");

            // Send request
            var response = await _apiRequestAsync.SendPostRequestAsync<TokenResponse>(request);

            return response!.AccessToken;
        }
    }
}
