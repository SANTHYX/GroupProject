using System.Collections.Generic;

namespace Api.Models
{
    public interface IApiResponse
    {
        IEnumerable<ResponseError> Errors { get; set; }
        bool IsSuccess { get; set; }
        int StatusCode { get; set; }
    }
}