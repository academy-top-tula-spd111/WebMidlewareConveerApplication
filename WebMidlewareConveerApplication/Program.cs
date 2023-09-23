using WebMidlewareConveerApplication;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddlware>();
if(app.Environment.IsProduction())
    app.UseMiddleware<AuthMiddleware>("12345");
app.UseMiddleware<RoutingMiddlware>();

app.Run();
