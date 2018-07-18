using DeleteBot.Utils;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;

namespace DeleteBot.Events.Command
{
    public class CommandModule : ModuleBase
    {
        [Command(CommandString.Delete)]
        internal async Task Delete(ulong messageId)
        {
            var channels = await Context.Guild.GetTextChannelsAsync();
            foreach (var channel in channels)
            {
                var message = await channel.GetMessageAsync(messageId);
                if (message != null)
                {
                    await message.DeleteAsync();
                    await Program.NotificationChannel.SendMessageAsync($"けしたよ:{channel.Id}:{messageId}:{message.ToString()}");
                    Debug.Log($"delete:{channel.Id}:{messageId}:{message.ToString()}");
                    return;
                }
            }
            Debug.Log("message not found");
        }

        [Command(CommandString.Delete)]
        internal async Task Delete(ITextChannel channel, ulong messageId)
        {
            var message = await channel.GetMessageAsync(messageId);
            if (message == null)
            {
                Debug.Log("message not found");
                return;
            }

            await message.DeleteAsync();
            await Program.NotificationChannel.SendMessageAsync($"けしたよ:{channel.Id}:{messageId}:{message.ToString()}");
            Debug.Log($"delete:{channel.Id}:{messageId}:{message.ToString()}");
        }

        [Command(CommandString.Ban)]
        internal async Task Ban(IUser user)
        {
            await Context.Guild.AddBanAsync(user);
            await Program.NotificationChannel.SendMessageAsync($"さよなら:{user.Mention}");
            Debug.Log($"banned:{user.Username}:{user.Id}");
        }
    }
}
