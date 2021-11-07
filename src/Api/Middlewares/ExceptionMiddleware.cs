using Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                var statusCode = ex switch
                {   
                    _ => StatusCodes.Status500InternalServerError
                };

                var error = new ErrorResponse(ex.Message, statusCode);
                var errorResponse = JsonSerializer.Serialize(error);

                await response.WriteAsync(errorResponse);
            }
        }
    }
}
