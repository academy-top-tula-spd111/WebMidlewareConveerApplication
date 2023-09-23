namespace WebMidlewareConveerApplication
{
    public class AuthMiddleware
    {
        readonly RequestDelegate next;
        string pattern;
        public AuthMiddleware(RequestDelegate next, string pattern)
        {
            this.next = next;
            this.pattern = pattern;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != pattern)
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            else
                await next.Invoke(context);
        }
    }
}
