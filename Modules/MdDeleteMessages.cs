using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace OpenBot.Modules
{
    public class MdDeleteMessages : ModuleBase<SocketCommandContext>
    {
        [Command("Delete-beta")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task DeleteMessages(int Number, ulong ChannelId = 0, [Remainder] string Reason = "Unknown")
        {
            await Context.Channel.SendMessageAsync("This command is currently not functional. Due to the new Discord.NET API.");
            return;

            if (ChannelId == 0)
            {
                return;
            }
            else
            {
                //await ((SocketTextChannel)Context.Channel).DeleteAsync();
            }

            await Context.Message.DeleteAsync();

            string Message = "Command **!delete " + Number.ToString() + "** requested by " + Context.User.Username + ">" + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> for channel <#" + ((ChannelId == 0) ? Context.Channel.Id.ToString() : ChannelId.ToString()) + ">" + Environment.NewLine +
                "with reason: *" + Reason + "*";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));

            const int Delay = 5000;
            var LastMsg = await Context.Channel.SendMessageAsync($"Delete completed. _This message will be deleted in {Delay / 1000} seconds._");

            await Task.Delay(Delay);

            await LastMsg.DeleteAsync();
        }
    }
}