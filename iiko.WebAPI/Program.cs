using WebAPI.Extensions;
using WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddMapper()
    .AddDatabase(builder.Configuration["Database:ConnectionString"]!)
    .RegisterRequiredServices()
    .AddGlobalExceptionHandler();

var app = builder.Build();

app.UseGlobalExceptionHandler();
app.MapControllers();

app.Run();