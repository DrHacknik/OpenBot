using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace OpenBot.Modules {
    public class rick : ModuleBase<SocketCommandContext> {
        private string time = DateTime.Now.ToString ();

        [Command ("RickRoll-canary")]
        [RequireUserPermission (GuildPermission.ManageMessages)]
        public async Task rck (SocketGuildUser user) {
            await Context.Message.DeleteAsync ();
            await Context.Channel.SendMessageAsync (user.Mention + "\r\n**Get Rick Roll'd mate!** \r\nhttps://www.youtube.com/watch?v=oHg5SJYRHA0");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine (time + ":: Command Request: !rickroll; " + "ID <" + Context.User.Id.ToString () + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString () + "> Channel ID: <" + Context.Channel.Id + "> Mentioned user: " + "<" + user.Mention + ">");
        }
    }
}