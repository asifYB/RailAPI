using System.Text.Json.Serialization;

namespace RailAPI.Models.Application
{
    public class ApplicationResponse
    {

        [JsonPropertyName("id")]
        public required string ApplicationId { get; set; }

        [JsonPropertyName("errors")]
        public required List<ApiError>  Errors { get; set; }
    }
}
