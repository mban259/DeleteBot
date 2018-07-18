using System.Threading.Tasks;
using DeleteBot.Events.Command;
using DeleteBot.Utils;
using Discord;
using Discord.WebSocket;

namespace DeleteBot
{
    class Program
    {
        private readonly DiscordSocketClient _client = new DiscordSocketClient();

        private readonly MessageMonitor _messageMonitor;
        static void Main(string[] args)
        {
            var program = new Program();
            program.Awake();
            program.MainAsync().GetAwaiter().GetResult();
        }

        internal Program()
        {
            _client = new DiscordSocketClient();
            _messageMonitor = new MessageMonitor(_client);
        }

        internal void Awake()
        {
            _client.MessageReceived += _messageMonitor.MessageRecieved;
            _client.Log += Log;
        }

        internal async Task MainAsync()
        {
            await _messageMonitor.AddModulesAsync();
            await _client.LoginAsync(TokenType.Bot, EnvManager.DiscordToken);
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        private async Task Log(LogMessage log)
        {
            Debug.Log(log.Message);
        }
    }
}
