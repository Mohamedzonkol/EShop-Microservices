using BuildingBlocks.Behavouir;

var builder = WebApplication.CreateBuilder(args);
//Add services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("DefaultConnection")!);
}).UseLightweightSessions();

var app = builder.Build();

//Pipeline
app.MapCarter();
app.Run();
