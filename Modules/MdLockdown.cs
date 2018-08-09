using System;
using System.Collections.Generic;
using System.Text;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Net;
using System.Linq;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class Lockdown : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("Lockchannel")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(GuildPermission.ManageChannels)]
        public async Task LockChannel(IGuildChannel chn, [Remainder]string reason)
        {
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            string Message = "Command **!lockchannel** requested by " + Context.User.Mention   + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> " + "Channel: " + chn.Id + " Lock reason: " + reason;
            string IMessage = "Command **!lockchannel** requested by " + Context.User.Mention  + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> " + "Channel: " + chn.Id + " Lock reason: " + reason; 
            
            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }

        [Command("Unlockchannel")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(GuildPermission.ManageChannels)]
        public async Task UnlockChannel(IGuildChannel chn, [Remainder]string reason)
        {
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            string Message = "Command **!unlockchannel** requested by " + Context.User.Mention   + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> " + "Channel: " + chn.Id + " Lock reason: " + reason;
            string IMessage = "Command **!unlockchannel** requested by " + Context.User.Mention  + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> " + "Channel: " + chn.Id + " Lock reason: " + reason;  
                
            await this.Context.Channel.SendMessageAsync(IMessage);
        }
    }
}
