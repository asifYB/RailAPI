using RailAPI.Core;
using RailAPI.Models.Application;

namespace RailAPI.Services.Application
{
    public class RetrieveApplications
    {
        // Retrieve applications
        public async Task<RetreiveApplicationsApiResponse> RetrieveApplicationAsync(string accessToken, GetApplicationsQuery queryParams)
        {
            var queryString = Payload.BuildGetApplicationsQueryString(queryParams);
            var url = $"https://api.rail.io/v1/applications?{queryString}";

            var headers = new Dictionary<string, string>
            {
                { "x-l2f-request-id", Guid.NewGuid().ToString() }
            };

            var request = DefaultHttpRequestBuilder.BuildGetRequest(
                url: url,
                payload: string.Empty,
                accessToken: accessToken,
                headers: headers
            );

            var response = await ApiRequest.SendGetRequestAsync<RetreiveApplicationsApiResponse>(request);
            return response!;
        }
    }
}
