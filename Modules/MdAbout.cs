using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RyuBot
{
    public class About : ModuleBase<SocketCommandContext>
    {
        private string cd = System.IO.Directory.GetCurrentDirectory();

        private string time = DateTime.Now.ToString();

        private string key_stat = "ubuntu-x64";

        [Command("About")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task SendAbout()

        {
            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            await Context.Channel.SendMessageAsync(
                "=====================================" +
                "\r\nDr.Hackniks RyujiNX Bot for Discord" +
                "\r\nVersion: 0.1.5" +
                "\r\nBot name: OpenBot" +
                "\r\nBot revision: 18_4_19_1034pm" +
                "\r\nBot Type: " + key_stat + " | Web-socket-based" +
                "\r\n=====================================");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !about; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">");
        }
    }
}