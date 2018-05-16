using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class MdWarn : ModuleBase<SocketCommandContext>
    {
        [Command("Warn")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Warn(SocketGuildUser WarnedUser, [Remainder]string WarningReason)
        {
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();

            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            //Need to fix this message :)
            await Context.Channel.SendMessageAsync(WarnedUser.Mention + " | **Please read the rules on the channel <#411271165429022730>" + Environment.NewLine + "" +
                                                   "You have been formally warned!**" + Environment.NewLine + 
                                                   "You were warned for: " + WarningReason);

            string Message = "Command **!warn** requested by <@" + Context.Message.Author.Id + "> to <" + WarnedUser.Mention + ">" + Environment.NewLine +
                             "in channel <#" + Context.Channel.Id + "> with warning reason: *" + WarningReason + "*";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }
    }
}