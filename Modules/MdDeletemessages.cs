using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class DeleteMessages : ModuleBase<SocketCommandContext>
    {
        private string cd = System.IO.Directory.GetCurrentDirectory();
        private string time = DateTime.Now.ToString();

        [Command("Delete")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Delete_messages([Remainder]uint count)
        {
            var messages = await this.Context.Channel.GetMessagesAsync((int)count + 1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !delete; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">" + " Value: " + count);
        }
    }
}