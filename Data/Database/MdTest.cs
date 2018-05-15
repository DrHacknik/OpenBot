using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class Test : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("Test")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task SendTest()

        {
            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            await Context.Channel.SendMessageAsync("Oh hi Mark.");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !test; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">");
        }
    }
}