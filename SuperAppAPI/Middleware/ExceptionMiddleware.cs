using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace SuperAppAPI.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }
       public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //Set Respons Status
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            //Log To file

            string logPath = Path.Combine("Logs", "error.log");

            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");
            
           string log = $@"
--------------------------
DATE: {DateTime.Now}
MESSAGE: {exception.Message}
STACKTRACE: {exception.StackTrace}
--------------------------
";
            await File.AppendAllTextAsync(logPath, log);

            //Return JSON Response
            var response = new
            {
                message = "An unexpected error occured.",
                detail = _env.IsDevelopment() ? exception.Message : null
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
