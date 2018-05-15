using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class MdRebpot : ModuleBase<SocketCommandContext>
    {
        private string cd = System.IO.Directory.GetCurrentDirectory();
        private string time = DateTime.Now.ToString();

        [Command("Reboot")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Reboot()
        {
            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            //var embed = new EmbedBuilder();
            //embed.WithTitle("Inputed message");
            //embed.WithDescription(message);
            //embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync("Rebooting the bot. \r\nThis can take up to a minute.");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !reboot; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">");

            
        }
    }
}