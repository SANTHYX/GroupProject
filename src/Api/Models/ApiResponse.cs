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
        public IEnumerable<ResponseError> Errors { get; set; } = new ResponseError[0];

        public static ApiResponse Success(int code = 200)
        {
            return new ApiResponse { IsSuccess = true, StatusCode = code };
        }

        public static ApiResponse Failure(IEnumerable<ResponseError> errors, int code = 500)
        {
            return new ApiResponse { IsSuccess = false, StatusCode = code, Errors = errors };
        }

        public static ApiResponse ServerError()
        {
            return new ApiResponse { IsSuccess = false, StatusCode = 500, Errors = ResponseError.ServerError() };
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
    public class ResponseError
    {
        /// <summary>
        /// Use this as Field name for form validation 
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Use this as Field errors for form validation
        /// </summary>
        public IEnumerable<string> Messages { get; set; }

        public static ResponseError Error(string key, string message) =>
            new ResponseError { Key = key, Messages = new string[] { message } };

        public static IEnumerable<ResponseError> ServerError(string message = "Something unexpected have happend.")
        {
            return new ResponseError[] 
            {
                new ResponseError { Key = "Server", Messages = new string[] { message } }
            };
        }
    }
}
