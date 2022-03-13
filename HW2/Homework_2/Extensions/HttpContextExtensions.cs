namespace HW2.Extensions
{
    public static class HttpContextExtensions
    {
        public static bool IsCompatible(this HttpContext context, string? version, out string errorMessage)
        {
            if (!double.TryParse(version, out var systemVersion))
            {
                errorMessage = SystemVersionErrorMessage();
                return false;
            }

            if (GetVersionNumberFrom(context) > systemVersion)
            {
                errorMessage = CompatibilityErrorMessage();
                return false;
            }

            errorMessage = "";
            return true;
        }

        public static bool IsNotCompatible(this HttpContext context, string? version, out string errorMessage)
        {
            return !IsCompatible(context, version, out errorMessage);
        }

        private static string SystemVersionErrorMessage()
        {
            return "Malformed system version, please try again later";
        }

        private static double GetVersionNumberFrom(HttpContext httpContext)
        {
            httpContext.Request.Headers.TryGetValue("version", out var givenVersion);
            _ = double.TryParse(givenVersion, out var versionNumber);
            return versionNumber;
        }

        private static string CompatibilityErrorMessage()
        {
            return "specified version is not compatible with the system";
        }

        public async static Task RespondWith(this HttpContext context, int statusCode, string? message)
        {
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(message ?? "");
        }
    }
}
