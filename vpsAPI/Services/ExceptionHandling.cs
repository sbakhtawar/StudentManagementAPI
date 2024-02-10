using System.Net;
using System.Text.Json;
using vpsAPI.DTOs;

namespace vpsAPI.Services
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandling> _logger;

        public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                var response = httpContext.Response;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var result = JsonSerializer.Serialize(new ErrorResponseModel(ex.Message));
                await httpContext.Response.WriteAsync(result);

                _logger.LogError(ex.Message);
            }
        }
    }
}
