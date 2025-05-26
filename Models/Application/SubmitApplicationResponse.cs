using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailAPI.Models.Application
{
    public class SubmitApplicationResponse
    {
        public string Id { get; set; } = string.Empty;

        public List<ApiError>? Errors { get; set; } = [];
    }
}
