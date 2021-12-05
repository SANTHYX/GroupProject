using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ApiResponse : IApiResponse
    {
        public bool IsSuccess { get; set; } = false;
        public int StatusCode { get; set; } = 500;
        public IEnumerable<FV_Error> Errors { get; set; } = new FV_Error[0];

        public static ApiResponse Success(int code = 200)
        {
            return new ApiResponse { IsSuccess = true, StatusCode = code };
        }

        public static ApiResponse Failure(IEnumerable<FV_Error> errors, int code = 500)
        {
            return new ApiResponse { IsSuccess = false, StatusCode = code, Errors = errors };
        }

    }

    public class ApiResponse<T> : ApiResponse, IApiResponse
    {
        public T Data { get; set; } = default(T);

        public static ApiResponse<T> Success(T data, int code = 200)
        {
            return new ApiResponse<T> { IsSuccess = true, Data = data, StatusCode = code };
        }
    }

    /// <summary>
    /// You can move this class somewhere else if you want lol 
    /// </summary>
    public class FV_Error
    {
        public string FieldName { get; set; }
        public IEnumerable<string> FieldErrors { get; set; }
    }
}
