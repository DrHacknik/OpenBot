using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace OpenBot.Modules {
    public class MdRikkad : ModuleBase<SocketCommandContext> {
        private string time = DateTime.Now.ToString ();

        [Command ("rikka-canary")]
        public async Task GetRikkad (SocketGuildUser MentionedUser) {
            await Context.Message.DeleteAsync ();

            EmbedBuilder Embed = new EmbedBuilder ();
            Embed.WithTitle (MentionedUser.Username + " you have been rikka'd by " + Context.User.Username);
            Embed.WithColor (new Color (161, 9, 238));
            Embed.WithImageUrl ("https://imgur.com/aKIEavu.gif");
            Embed.WithDescription ("/>.>/ ow~");
            Embed.WithTimestamp (DateTime.UtcNow);
            await Context.Channel.SendMessageAsync (String.Empty, false, Embed.Build ());

            string Message = "Command **!rikka** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
        }
    }
}