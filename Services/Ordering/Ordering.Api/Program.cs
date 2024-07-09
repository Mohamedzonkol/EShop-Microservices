var builder = WebApplication.CreateBuilder(args);

//add services to DI

builder.Services.AddApplicationServices(/*builder.Configuration*/)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiServices();
if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabase();
}

app.Run();