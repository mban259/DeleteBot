using DotNetEnv;

namespace DeleteBot.Utils
{
    class EnvManager
    {
        internal static readonly string DiscordToken;
        internal static readonly ulong CommandChannelId;

        static EnvManager()
        {
            Env.Load();
            DiscordToken = Env.GetString("DISCORD_TOKEN");
            CommandChannelId = ulong.Parse(Env.GetString("COMMAND_CHANNEL_ID"));
        }
    }
}
