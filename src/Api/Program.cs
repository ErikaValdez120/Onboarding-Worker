using Andreani.ARQ.AMQStreams.Extensions;
using Andreani.ARQ.WebHost.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Worker_onboarding.Application;
using Worker_onboarding.Infrastructure;
using Andreani.Scheme.Onboarding;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services
    .AddKafka(builder.Configuration)
    .CreateOrUpdateTopic(6, "PedidoCreadoV")
    .ToProducer<Pedido>("PedidoAsignadoV")
    .ToConsumer<Subscriber, Pedido>("PedidoCreadoV")
    .Build();

var app = builder.Build();

app.ConfigureAndreani(app.Environment, app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.Run();

// configurar publicador y consumidor
