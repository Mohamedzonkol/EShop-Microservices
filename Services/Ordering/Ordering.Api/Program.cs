using Ordering.Api;
using Ordering.Applecation;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
//add services to DI
builder.Services.AddInfrastructureServices(builder.Configuration).AddApplicationServices().AddApiServices();

var app = builder.Build();

app.UseApiServices();

app.Run();