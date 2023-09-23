namespace WebMidlewareConveerApplication
{
    public class ErrorHandlingMiddlware
    {
        readonly RequestDelegate next;
        public ErrorHandlingMiddlware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await next.Invoke(context);

            if(context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                await context.Response.WriteAsync("Access error");
            }
            else if(context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                await context.Response.WriteAsync("Resource not found");
            }
        }
    }
}
