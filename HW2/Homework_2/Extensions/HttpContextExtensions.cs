namespace HW2.Extensions
{
    public static class HttpContextExtensions
    {
        public static bool IsCompatible(this HttpContext context, string? version, out string errorMessage)
        {
            if (!Version.TryParse(version, out var systemVersion))
            {
                errorMessage = SystemVersionErrorMessage();
                return false;
            }
            
            if (!Version.TryParse(GetVersionFrom(context), out var givenVersion))
            {
                errorMessage = VersionFormatErrorMessage();
                return false;
            }

            if (givenVersion > systemVersion)
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

        private static string VersionFormatErrorMessage()
        {
            return "Given version is invalid, format should be major.minor";
        }

        private static string GetVersionFrom(HttpContext context)
        {
            _ = context.Request.Headers.TryGetValue("version", out var givenVersion);
            return givenVersion;
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
