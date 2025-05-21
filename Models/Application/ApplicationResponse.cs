using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
