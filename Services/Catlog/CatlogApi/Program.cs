using BuildingBlocks.Behavouir;
using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);
//Add services to the container.

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddCarter();
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("DefaultConnection")!);
}).UseLightweightSessions();
builder.Services.AddExceptionHandler<CustomExceptionHandler>();
var app = builder.Build();

//Pipeline
app.MapCarter();
app.UseExceptionHandler(options =>
{
});
app.Run();
