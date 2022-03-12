using Microsoft.Extensions.Options;

namespace HW2.Middleware
{
    public class VersionControlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IOptions<VersionOption> options;

        public VersionControlMiddleware(
            RequestDelegate next,
            IOptions<VersionOption> options)
        {
            _next = next;
            this.options = options;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            await _next(context);
        }

    }

    public static class VersionControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseVersionControl(
            this IApplicationBuilder builder, IOptions<VersionOption> options)
        {
            return builder.UseMiddleware<VersionControlMiddleware>(options);
        }
    }

}
