using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class MdSayhello : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("SayHello")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Say_Hello()

        {
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            await Context.Channel.SendMessageAsync("**I did not do it, I did not hit her; I did nawt!**");
            string Message = "Command **!sayhello** requested by <@" + Context.Message.Author.Id  + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">" + "Mentioned User: <" + user.Mention + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }
    }
}
