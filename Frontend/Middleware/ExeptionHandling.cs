using Frontend.Models.ViewModel;
using System.Net;
using System.Text.Json;

namespace Frontend.Middleware
{
    public class ExeptionHandlingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger  _logger;
        public ExeptionHandlingMiddleware(RequestDelegate requestDelegate,ILogger<ExeptionHandlingMiddleware> logger) 
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleExeptionAsync(httpContext, ex.Message, HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                await HandleExeptionAsync(httpContext, ex.Message, HttpStatusCode.BadRequest);
            }
        }

        private async Task HandleExeptionAsync(HttpContext httpContext, string exMess,
            HttpStatusCode httpStatusCode)
        {
            _logger.LogError(exMess);
            HttpResponse response = httpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDTO errorDTO = new ErrorDTO()
            {
                StatusCode = (int)httpStatusCode,
            };
            string result = JsonSerializer.Serialize(errorDTO);
            await response.WriteAsJsonAsync(result);

          
            return;
        }
    }
}

