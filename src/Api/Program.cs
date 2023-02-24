using Andreani.ARQ.WebHost.Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using DesafioOnboardingWorker.Application;
using DesafioOnboardingWorker.Infrastructure;
using Andreani.ARQ.AMQStreams.Extensions;
using Andreani.Scheme.Onboarding;
using DesafioOnboardingWorker.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services
    .AddKafka(builder.Configuration)
    .ToConsumer<Subscriber,Pedido>("PedidoCreado")
    .Build();

var app = builder.Build();

app.ConfigureAndreani(app.Environment, app.Services.GetRequiredService<IApiVersionDescriptionProvider>());

app.Run();
