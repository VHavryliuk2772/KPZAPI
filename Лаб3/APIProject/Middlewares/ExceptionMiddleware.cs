using System.Text.Json;
using System.Net;
using Domain.Exceptions;

namespace InProduct.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _requestDelegate = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"There was an exception in the middleware: {ex.Message}");
                HandleException(httpContext, ex);
            }
        }

        public async void HandleException(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode;
            switch (ex)
            {
                case ItemNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case NotSupportedException:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
                case InternalServerErrorException:
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            string message = ex.Message;

            var result = JsonSerializer.Serialize(message);
            httpContext.Response.StatusCode = (int)statusCode;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(result);
        }
    }
}
