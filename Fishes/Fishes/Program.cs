var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseHttpsRedirection()
    .UseStaticFiles()
    .Use(async (context, next) =>
    {
        var response = context.Response;
        if (context.Request.Path == "/")
        {
            response.ContentType = "text/html";
            await response.SendFileAsync("wwwroot/html/index.html");
        }
        else
        {
            await next.Invoke();
        } 
    });

app.Run();
