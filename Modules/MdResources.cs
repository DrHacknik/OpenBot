using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class Res : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("Res")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task res(SocketGuildUser user)
        {
            //var embed = new EmbedBuilder();
            //embed.WithTitle("Resources:");
            //embed.WithDescription(message);
            //embed.WithColor(new Color(0, 255, 0));
            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            await Context.Channel.SendMessageAsync(user.Mention + "__**Please visit the following sites for more information:**__ \r\nhttps://zoltx23.github.io/ryujinx-emu/ \r\nhttps://github.com/gdkchan/Ryujinx");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !res; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">" + " Mentioned user: " + "<" + user.Mention + ">");
        }
    }
}