var builder = WebApplication.CreateBuilder(args);
//Services
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();
//pipeline
app.MapReverseProxy();


app.Run();
