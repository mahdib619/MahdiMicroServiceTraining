using Financial.Application;
using Financial.Grpc.GrpcServices;
using Financial.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.RegistrarApplicationServices()
                .RegistrarInfrastructureServices(builder.Configuration);

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<GrpcBalanceService>();

app.Run();
