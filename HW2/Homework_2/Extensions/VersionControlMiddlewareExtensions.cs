using Microsoft.Extensions.Options;

namespace HW2.Middleware
{
    public static class VersionControlMiddlewareExtensions
    {
        public static IApplicationBuilder UseVersionControl(
            this IApplicationBuilder builder, IOptions<VersionOption> options)
        {
            return builder.UseMiddleware<VersionControlMiddleware>(options);
        }
    }

}
