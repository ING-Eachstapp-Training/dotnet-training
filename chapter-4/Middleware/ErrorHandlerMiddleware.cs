using System;
using System.Net;
using System.Text.Json;
using chapter_4.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace chapter_4.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/problem+json";
                string title = string.Empty;
                switch (error)
                {
                    case TaskNotFoundException:
                        response.StatusCode = 400;
                        title = "The task is not found";
                        break;
                    default:
                        // unhandled error (thrown as internal server errors)
                        _logger.LogError(error.Message);
                        title = "Internal server error";
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new ErrorModel
                {
                    Title = title,
                    Status = response.StatusCode
                });

                await response.WriteAsync(result);
            }
        }
    }
    class ErrorModel
    {
        public string Title { get; set; }
        public int Status { get; set; }
    }
}

