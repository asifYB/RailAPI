using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
