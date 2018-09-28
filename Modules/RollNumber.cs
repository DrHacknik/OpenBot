using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace RyuBot.Modules {
    public class MdRollNumber : ModuleBase<SocketCommandContext> {
        private string time = DateTime.Now.ToString ();
        private string[] Roles;
        [Command ("rollnumber")]
        public async Task RollNumber () {
            Random rand;

            rand = new Random ();
            int dice = rand.Next (1, 70);
            string RolledDice = Convert.ToString (dice);
            await Context.Message.DeleteAsync ();

            EmbedBuilder Embed = new EmbedBuilder ();
            Embed.WithTitle ("You rolled the number:");
            Embed.WithColor (new Color (236, 183, 4));
            Embed.WithDescription ("**" + RolledDice + "**");
            Embed.WithTimestamp (DateTime.UtcNow);
            await Context.Channel.SendMessageAsync (String.Empty, false, Embed.Build ());

            string Message = "Command **!rollnumber** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
        }
    }
}