using Financial.Application;
using Financial.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegistrarApplicationServices()
                .RegistrarInfrastructureServices(builder.Configuration);

builder.Services.AddGrpc();

var app = builder.Build();

app.Run();
