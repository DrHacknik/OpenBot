using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace OpenBot {
    public class GameStatus : ModuleBase<SocketCommandContext> {
        private static string cd = Config.BotDir;

        private string time = DateTime.Now.ToString ();

        [Command ("SetStatus")]
        [RequireUserPermission (GuildPermission.ManageMessages)]
        public async Task SetStatus ([Remainder] string IStatus) {
            await Context.Message.DeleteAsync ();
            string Message = "Command **!setstatus** requested by " + Context.User.Username + ">" + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> with value: *" + IStatus + "*";
            Config.GameStatus = IStatus;
            await Program.SetStatus ();

            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
            return;
        }
    }
}