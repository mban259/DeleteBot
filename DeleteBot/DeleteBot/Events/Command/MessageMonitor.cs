using DeleteBot.Utils;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DeleteBot.Events.Command
{
    class MessageMonitor
    {
        private readonly DiscordSocketClient _discordSocketClient;
        private readonly CommandService _commandService;
        private readonly IServiceProvider _serviceProvider;
        internal MessageMonitor(DiscordSocketClient discordSocketClient)
        {
            _discordSocketClient = discordSocketClient;
            _commandService = new CommandService();
            _serviceProvider = new ServiceCollection().BuildServiceProvider();
        }

        internal async Task AddModulesAsync()
        {
            await _commandService.AddModulesAsync(Assembly.GetEntryAssembly());
        }

        internal async Task MessageRecieved(SocketMessage messageParam)
        {
            if (messageParam.Channel.Id != EnvManager.CommandChannelId) return;
            var message = messageParam as SocketUserMessage;
            int argPos = 0;
            if (!message.HasStringPrefix(CommandString.Prefix, ref argPos)) return;
            var context = new CommandContext(_discordSocketClient, message);
            var result = _commandService.ExecuteAsync(context, argPos, _serviceProvider);
            Debug.Log(result.Result);

        }
    }
}
