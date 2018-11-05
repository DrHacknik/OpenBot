using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace OpenBot.Modules {
    public class MdTeleport : ModuleBase<SocketCommandContext> {
        private string time = DateTime.Now.ToString ();

        [Command ("tp")]
        public async Task Teleport ([Remainder]string location) {
            await Context.Message.DeleteAsync ();
            if (location == null) {
                await Context.Channel.SendMessageAsync ("Please input a proper coordinates. *IE: -000, 00, 0000.*", false);
            } else if (location != null) {
                await Context.Channel.SendMessageAsync ("**[Server]:**  " + Context.User.Username + " has teleported to " + location, false);
            }

            string Message = "Command **!tp** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
        }
    }
}