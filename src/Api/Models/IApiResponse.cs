using System.Collections.Generic;

namespace Api.Models
{
    public interface IApiResponse
    {
        IEnumerable<FV_Error> Errors { get; set; }
        bool IsSuccess { get; set; }
        int StatusCode { get; set; }
    }
}