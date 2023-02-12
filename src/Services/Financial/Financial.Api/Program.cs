using AspNetHelpers.Extensions;
using Financial.Application;
using Financial.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegistrarApplicationServices()
                .RegistrarInfrastructureServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCommonExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
