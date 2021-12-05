using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
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

                // var error = new ErrorResponse(ex.Message, statusCode);
                var error = ApiResponse.ServerError();

                var errorResponse = JsonSerializer.Serialize(error);
                await response.WriteAsync(errorResponse);

                _logger.LogError(ex.Message);
            }
        }
    }
}
