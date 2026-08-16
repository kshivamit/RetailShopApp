using RetailShop.API.Models;
using RetailShop.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace RetailShop.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            catch (Exception ex)
            {
                //_logger.LogError(ex, ex.Message);
                //context.Response.ContentType = "application/json";
                //context.Response.StatusCode =
                //    (int)HttpStatusCode.InternalServerError;

                //var response = new
                //{
                //    StatusCode = context.Response.StatusCode,
                //    Message = ex.Message
                //};

                //await context.Response.WriteAsync(
                //    JsonSerializer.Serialize(response));

                _logger.LogError(ex, "An exception occurred. TraceId: {TraceId}", context.TraceIdentifier);
                
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
        {
            var response = new ErrorResponse
            {
                TraceId = context.TraceIdentifier
            };

            switch (exception)
            {
                case NotFoundException:
                    context.Response.StatusCode =
                        (int)HttpStatusCode.NotFound;

                    response.Message = exception.Message;
                    break;

                case BadRequestException:
                    context.Response.StatusCode =
                        (int)HttpStatusCode.BadRequest;

                    response.Message = exception.Message;
                    break;

                case ConflictException:
                    context.Response.StatusCode =
                        (int)HttpStatusCode.Conflict;

                    response.Message = exception.Message;
                    break;

                default:
                    context.Response.StatusCode =
                        (int)HttpStatusCode.InternalServerError;

                    response.Message =
                        "An unexpected error occurred.";
                    break;
            }

            response.StatusCode = context.Response.StatusCode;

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}
