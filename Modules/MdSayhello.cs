using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace OpenBot.Modules
{
    public class MdSayhello : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("SayHello-beta")]
        public async Task Say_Hello()
        {
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync("**I did not do it, I did not hit her; I did nawt!**");
            string Message = "Command **!sayhello** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }
    }
}