using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RyuBot
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        private string cd = System.IO.Directory.GetCurrentDirectory();
        private string time = DateTime.Now.ToString();

        [Command("Help")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task SendHelp()
        {
            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            await Context.Channel.SendMessageAsync("**Bot usage:**" +
                "\r\n```" +
                "\r\n!warn<@user> : Warns the mentioned user." +
                "\r\n!rickroll<@user> : RickRolls the mentioned user.For use in <#410208622778384385> " +
                "\r\n!git < enable / disable > < git_webhook > : Setups, enables / disables the Git mode~Not ready yet." +
                "\r\n!res<@user> : Sends a message with Important Info about the emulator to the mentioned user." +
                "\r\n!kick<@user> : Kicks the mentioned user." +
                "\r\n!ban<@user> : Bans the mention user.Admins only." +
                "\r\n!about : Shows the latest bot information." +
                "\r\n!input <value> : Sends the remainder of the command message as its own message." +
                "\r\n!sayhello : Say hello." +
                "\r\n!howareyou <@user> : Say how are you ?" +
                "\r\n!delete <value> : Deletes the specified amount of previous messages." +
                "```" +
                "\r\nPS: **ALL COMMANDS ARE LOGGED!**I am always watching ; 3");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !help; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">");
        }
    }
}