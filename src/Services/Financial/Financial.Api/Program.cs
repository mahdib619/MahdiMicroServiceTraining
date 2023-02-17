using EventBus.Messages.Common;
using Financial.Api.EventBusConsumers;
using Financial.Application;
using Financial.Infrastructure;
using MassTransit;
using WebApplicationHelpers.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegistrarApplicationServices()
                .RegistrarInfrastructureServices(builder.Configuration);

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<StudentPickedCourseConsumer>();
    config.AddConsumer<StudentDeletedCourseConsumer>();

    config.UsingRabbitMq((mqCtx, mqCfg) =>
    {
        mqCfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

        mqCfg.ReceiveEndpoint(EventBusConstants.PICK_COURSE_QUEUE, epCfg =>
        {
            epCfg.ConfigureConsumer<StudentPickedCourseConsumer>(mqCtx);
        });
        mqCfg.ReceiveEndpoint(EventBusConstants.DELETE_COURSE_QUEUE, epCfg =>
        {
            epCfg.ConfigureConsumer<StudentDeletedCourseConsumer>(mqCtx);
        });
    });
});

builder.Services.AddScoped<StudentPickedCourseConsumer>();

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
