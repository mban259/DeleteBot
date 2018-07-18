using System.Text;
using DotNetEnv;

namespace DeleteBot.Utils
{
    class EnvManager
    {
        internal static readonly string DiscordToken;
        internal static readonly ulong CommandChannelId;
        internal static readonly ulong NotificationChannelId;

        static EnvManager()
        {
            Env.Load();
            DiscordToken = Env.GetString("DISCORD_TOKEN");
            CommandChannelId = ulong.Parse(Env.GetString("COMMAND_CHANNEL_ID"));
            NotificationChannelId = ulong.Parse(Env.GetString("NOTIFICATION_CHANNEL_ID"));
        }
    }
}
