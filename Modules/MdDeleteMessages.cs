using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace RyuBot.Modules
{
    public class MdDeleteMessages : ModuleBase<SocketCommandContext>
    {
        private static readonly AutoResetEvent _ResetEvent = new AutoResetEvent(false);


        [Command("Delete")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task DeleteMessages(int Number, ulong ChannelId = 0, [Remainder]string Reason = "Unknown")
        {
            if (ChannelId == 0)
            {
                var ReturnMsg = await Context.Channel.GetMessagesAsync(Number).Flatten();
                await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            }
            else
            {
                var ReturnMsg = await ((IMessageChannel)Context.Client.GetChannel(ChannelId)).GetMessagesAsync(Number).Flatten();
                await ((IMessageChannel)Context.Client.GetChannel(ChannelId)).DeleteMessagesAsync(ReturnMsg);
            }

            var InputMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(InputMsg);

            string Message = "Command **!delete " + Number.ToString() + "** requested by <@" + Context.Message.Author.Id + ">" + Environment.NewLine +
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