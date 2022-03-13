using HW2.Extensions;
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
            if(context.IsNotCompatible(options.Value.Version, out var errorMessage))
            {
                await context.RespondWith(
                    StatusCodes.Status401Unauthorized, 
                    errorMessage
                );
                return;
            }

            await _next(context);
        }

    }
}
