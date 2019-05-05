using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace OpenBot.Modules {
    public class MdRollRole : ModuleBase<SocketCommandContext> {
        private string time = DateTime.Now.ToString ();
        private string[] Roles;

        [Command ("rollrole-canary")]
        public async Task RollRole () {
            Random rand;

            rand = new Random ();
            Roles = new string[] {
                "Gai",
                "Normal User",
                "Trusted",
                "Helper",
                "Moderator",
                "Admin",
                "Web developer",
                "Developer",
                "Owner",
                "God Like!",
                "Sensei",
                "Senpai",
                "Catgirl",
                "Catboi",
                "Wolfgirl",
                "Foxgirl",
                "OWO What's this?",
                "UwU What's this?",
                "A FUCKING GOD!"
            };

            await Context.Message.DeleteAsync ();
            int randomIndex = rand.Next (Roles.Length);
            string RolePost = Roles[randomIndex];

            EmbedBuilder Embed = new EmbedBuilder ();
            Embed.WithTitle ("Roll that role?");
            Embed.WithColor (new Color (236, 183, 4));
            Embed.WithDescription (Context.User.Username + " Rolled **" + RolePost + "**");
            Embed.WithTimestamp (DateTime.UtcNow);
            await Context.Channel.SendMessageAsync (String.Empty, false, Embed.Build ());

            string Message = "Command **!rollrole** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
        }
    }
}