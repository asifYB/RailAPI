using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailAPI.Models.Application
{
    public class RetreiveApplicationsApiResponse
    {
        public class ApplicationsApiResponse
        {
            public ApplicationData Data { get; set; } = new();
            public ApplicationLinks Links { get; set; } = new();
            public List<ApiError> Errors { get; set; } = [];
        }

        public class ApplicationData
        {
            public List<ApplicationResponse> Applications { get; set; } = new();
        }

        public class ApplicationLinks
        {
            public string Self { get; set; } = string.Empty;
            public string First { get; set; } = string.Empty;
            public string Prev { get; set; } = string.Empty;
            public string Next { get; set; } = string.Empty;
            public string Last { get; set; } = string.Empty;
        }
    }
}
