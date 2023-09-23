namespace WebMidlewareConveerApplication
{
    public class RoutingMiddlware
    {
        public RoutingMiddlware(RequestDelegate _) { }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path;
            switch(path)
            {
                case "/":
                    await context.Response.WriteAsync("Home page");
                    break;
                case "/about":
                    await context.Response.WriteAsync("About page");
                    break;
                case "/contacts":
                    await context.Response.WriteAsync("Contacts page");
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    break;
            }
        }
    }
}
