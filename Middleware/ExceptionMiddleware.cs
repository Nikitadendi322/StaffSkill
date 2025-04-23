using System.Net;
using System.Text.Json;

namespace StaffSkill.Middleware
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

        public async Task InvokeAsync(HttpContext c)
        {
            try
            {
                await _next(c);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Необработанное исключение");
                await HandleExceptionAsync(c, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Внутренняя ошибка сервера",
                Details = ex.Message
            }));
        }
    }
}
