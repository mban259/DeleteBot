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
                    Debug.Log($"けしたよ:{channel.Id}:{messageId}:{message.ToString()}");
                    return;
                }
            }
            Debug.Log("めっせーじないよ");
        }

        [Command(CommandString.Delete)]
        internal async Task Delete(ITextChannel channel, ulong messageId)
        {
            var message = await channel.GetMessageAsync(messageId);
            if (message == null)
            {
                Debug.Log("めっせーじないよ");
                return;
            }

            await message.DeleteAsync();
            Debug.Log($"けしたよ:{channel.Id}:{messageId}:{message.ToString()}");
        }
    }
}
