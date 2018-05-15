using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class MdSayhello : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("SayHello")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Say_Hello()

        {
            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            await Context.Channel.SendMessageAsync("**I did not do it, I did not hit her; I did nawt!**");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !sayhello; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">");
        }
    }
}
