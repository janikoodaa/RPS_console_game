using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RockPaperScissors;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

IGameContext gameCtx = new GameContext();
builder.Services.AddSingleton(serviceProvider => gameCtx);

builder.Build();
