using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

/*
Do keep in mind that this command is nowhere near finished.
I plan on having it parse most common Sites, such as Reddit and other
offbrand sites :3
 */

namespace OpenBot.Modules {
    public class MdLewd : ModuleBase<SocketCommandContext> {
        [Command ("lewd")]
        public async Task Lewdie () {
            await Context.Message.DeleteAsync ();

            Random rand;
            rand = new Random ();
            if (((SocketTextChannel) Context.Channel).IsNsfw) {
                string[] Lewds = Directory.GetFiles (Config.LewdDir, "*.*", SearchOption.TopDirectoryOnly);

                int randomIndex = rand.Next (Lewds.Length);
                string LewdPost = Lewds[randomIndex];

                EmbedBuilder Lewdbed = new EmbedBuilder ();

                await Context.Channel.SendFileAsync (LewdPost, "UwU Leeeewds");
                string Message = "Command **!lewd** requested by " + Context.User.Username + Environment.NewLine +
                    "in channel <#" + Context.Channel.Id + ">" + " With file <" + LewdPost + ">";

                await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
            } else {
                EmbedBuilder Lewdbed = new EmbedBuilder ();
                Lewdbed.WithTitle ("L-lewdie");
                Lewdbed.WithColor (new Color (253, 114, 152));
                Lewdbed.WithImageUrl ("https://i.stack.imgur.com/MKMpFm.jpg");
                Lewdbed.WithDescription ("Try using this command in a channel that has a NSFW tag enabled.");
                Lewdbed.WithTimestamp (DateTime.Now);
                await Context.Channel.SendMessageAsync (string.Empty, false, Lewdbed.Build ());

                string Message = "Command **!lewd** requested by " + Context.User.Username + Environment.NewLine +
                    "in channel <#" + Context.Channel.Id + ">";

                await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
            }
        }
    }
}