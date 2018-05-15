using System;
using System.Collections.Generic;
using System.Text;
using RyuBot.Modules;
using RyuBot.Data;
using RyuBot.Services;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace RyuBot.Services
{
    [RequireUserPermission(GuildPermission.ManageMessages)]
    public class SvcAutowarn : ModuleBase<SocketCommandContext>
    {
        private string user = null;
        private string time = DateTime.Now.ToString();

        public void GetCount()
        {
            
        } 
        public void SetCount()
        {

        }
        public async Task WarnUser(SocketGuildUser user)
        {
            
            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            await Context.Channel.SendMessageAsync(user.Mention + " | **Please read the rules on the channel #rules. \r\nYou have been formally warned!** \r\nWe do **NOT** allow the sharing of Warez, or (other) Pirating sources.");

            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !warn; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Mentioned user: " + "<" + user.Mention + ">" + " Channel ID: <" + Context.Channel.Id + ">");
        }
    }
}
