using AspNetHelpers.Extensions;
using Serilog;
using University.Application;
using University.Infrasturcture;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders()
               .AddSerilog();

builder.Services.RegistrarApplicationServices()
                .RegistrarInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(app.Configuration)
    .CreateLogger();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCommonExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
