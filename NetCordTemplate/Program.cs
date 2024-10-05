using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NetCord;
using NetCord.Gateway;
using NetCord.Hosting.Gateway;
using NetCord.Hosting.Services;
using NetCord.Hosting.Services.ApplicationCommands;
using NetCord.Hosting.Services.ComponentInteractions;
using NetCord.Services.ApplicationCommands;
using NetCord.Services.ComponentInteractions;

using NetCordTemplate;
using NetCordTemplate.Helpers;
using NetCordTemplate.HostedServices;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddDiscordGateway(options =>
    {
        options.Intents = GatewayIntents.All;
    })
    .AddApplicationCommands<SlashCommandInteraction, SlashCommandContext>(OptionsHelper.ConfigureApplicationCommandService)
    .AddApplicationCommands<UserCommandInteraction, UserCommandContext>(OptionsHelper.ConfigureApplicationCommandService)
    .AddApplicationCommands<MessageCommandInteraction, MessageCommandContext>(OptionsHelper.ConfigureApplicationCommandService)
    .AddComponentInteractions<ButtonInteraction, ButtonInteractionContext>(OptionsHelper.ConfigureInteractionService)
    .AddComponentInteractions<StringMenuInteraction, StringMenuInteractionContext>(OptionsHelper.ConfigureInteractionService)
    .AddComponentInteractions<UserMenuInteraction, UserMenuInteractionContext>(OptionsHelper.ConfigureInteractionService)
    .AddComponentInteractions<ModalInteraction, ModalInteractionContext>(OptionsHelper.ConfigureInteractionService)
    .AddHttpClient()
    .AddGatewayEventHandlers(typeof(Program).Assembly)
    .AddHostedSingletonService<SampleHostedService>()
    .AddOptions<Configuration>()
    .BindConfiguration(string.Empty);

var host = builder.Build()
    .AddModules(typeof(Program).Assembly)
    .UseGatewayEventHandlers();

await host.RunAsync();
