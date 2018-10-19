using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace OpenBot.Modules {
    public class MdWeather : ModuleBase<SocketCommandContext> {
        private string time = DateTime.Now.ToString ();
        private ulong apikey;
        private string location;
        private string temp;
        private string current;
        private string icon;

        [Command ("weather")]
        public async Task Kissed (string Location) {
            Random rand;

           
            await Context.Message.DeleteAsync ();
            EmbedBuilder Embed = new EmbedBuilder ();
            Embed.WithTitle ("Weather for: " + Location);
            Embed.WithColor (new Color (236, 183, 4));
            Embed.WithImageUrl ();
            Embed.WithDescription ("Location: " + Location + Environment.NewLine + "Current Condition: " + current + Environment.NewLine + "Temp: " + temp);
            Embed.WithTimestamp (DateTime.UtcNow);
            await Context.Channel.SendMessageAsync (String.Empty, false, Embed.Build ());

            string Message = "Command **!weather** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
            
         private void ParseAPI { 
             
         }
        }
    }
}
