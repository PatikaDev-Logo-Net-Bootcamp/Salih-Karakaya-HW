namespace HW2.Extensions
{
    public static class HttpContextExtensions
    {
        public static bool IsCompatible(this HttpContext httpContext, string version)
        {
            _ = double.TryParse(version, out var result);
            httpContext.Request.Headers.TryGetValue("version", out var sourceVersion);
            return result.Equals(sourceVersion);
        }
    }
}
