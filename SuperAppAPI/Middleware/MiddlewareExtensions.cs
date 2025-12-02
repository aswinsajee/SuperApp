namespace SuperAppAPI.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
