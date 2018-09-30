using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace OpenBot.Modules {
    public class MdHowAreYou : ModuleBase<SocketCommandContext> {
        private string cd = AppDomain.CurrentDomain.BaseDirectory;
        private string time = DateTime.Now.ToString ();

        [Command ("HowAreYou")]
        public async Task How_Are_You (SocketGuildUser user) {
            await Context.Message.DeleteAsync ();
            await Context.Channel.SendMessageAsync ("**How are you** " + user.ToString () + "?");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            string Message = "Command **!howareyou** requested by <" + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">" + " to <" + user.Mention + ">";
            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
        }
    }
}