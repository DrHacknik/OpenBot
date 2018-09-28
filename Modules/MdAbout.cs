using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace RyuBot {
    public class About : ModuleBase<SocketCommandContext> {
        private string cd = System.IO.Directory.GetCurrentDirectory ();

        private string time = DateTime.Now.ToString ();

        [Command ("About-beta")]
        [RequireUserPermission (GuildPermission.ManageMessages)]
        public async Task SendAbout () {
            EmbedBuilder Embed = new EmbedBuilder ();
            Embed.WithTitle ("About Awoo Bot [Beta]:");
            Embed.WithColor (new Color (236, 183, 4));
            Embed.WithImageUrl ("https://i.imgur.com/bplcGZ7.png");
            Embed.WithDescription (
                "**Awoo-bot-beta for Discord**" + Environment.NewLine +
                "**by Dr.Hacknik**" + Environment.NewLine +
                "**Version:** " + Config.Version + Environment.NewLine +
                "**Bot name:** Awoobot" + Environment.NewLine +
                "**Bot revision:** " + Config.BuildDate + Environment.NewLine +
                "**Bot Type:** DotNet Core | Web-socket-based" + Environment.NewLine +
                "**Bot Platform:** " + Config.OS + Environment.NewLine);
            Embed.WithTimestamp (DateTime.UtcNow);
            await Context.Channel.SendMessageAsync (String.Empty, false, Embed.Build ());

            await Context.Message.DeleteAsync ();

            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Bot", ""));
        }
    }
}