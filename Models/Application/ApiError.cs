using System.Text.Json.Serialization;

namespace RailAPI.Models.Application
{
    public class ApiError
    {
        [JsonPropertyName("code")]
        public required string Code { get; set; }

        [JsonPropertyName("description")]
        public required string Description { get; set; }
    }
}
