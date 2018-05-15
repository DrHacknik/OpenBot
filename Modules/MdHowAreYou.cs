using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class MdHowAreYou : ModuleBase<SocketCommandContext>
    {
        private string cd = AppDomain.CurrentDomain.BaseDirectory;
        private string time = DateTime.Now.ToString();

        [Command("HowAreYou")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task How_Are_You(SocketGuildUser user)
        {
            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            await Context.Channel.SendMessageAsync("**How are you** " + user.ToString() + "?");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !howareyou; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">" + " Mentioned user: " + "<" + user.Mention + ">");
        }
    }
}