using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace OpenBot
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        private string cd = System.IO.Directory.GetCurrentDirectory();
        private string time = DateTime.Now.ToString();

        [Command("Help-canary")]
        public async Task SendHelp()
        {
            await Context.Message.DeleteAsync();

            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithTitle("Bot Usage:");
            Embed.WithColor(new Color(236, 183, 4));
            Embed.WithImageUrl("https://github.com/DrHacknik/OpenBot/blob/master/Splash_256.png?raw=true");
            Embed.WithDescription("\r\n" +
                "\r\n**!warn-canary <@user>** : Warns the mentioned user." +
                "\r\n**!rickroll <@user>** : RickRolls the mentioned user." +
                "\r\n**!kiss <@user>** : Kisses the mentioned user." +
                "\r\n**!hug <@user>** : Hugs the mentioned user." +
                "\r\n**!rikka <@user>** : Tells the mentioned user; get Rikka'd." +
                "\r\n**!lewd:** Sends a good ol' lewd to the same channel. Must be marked as NSFW." +
                "\r\n**!kick-canary <@user>** : Kicks the mentioned user." +
                "\r\n**!ban-canary <@user>** : Bans the mention user.Admins only." +
                "\r\n**!about-canary** : Shows the latest bot information." +
                "\r\n**!input-canary <value>** : Sends the remainder of the command message as its own message." +
                "\r\n**!sayhello-canary** : Say hello." +
                "\r\n**!howareyou <@user>** : Say how are you ?" +
                "\r\n**!rollnumber** : Random Int number." +
                "\r\n**!rollrole** : Random Role value." +
                "\r\n**!userinfo <@user> <image size: One value only, ex 64. If null, then 128 is used>** : Shows the mentioned user's information and avatar image." +
                "\r\n**!delete-canary <value>** : Deletes the specified amount of previous messages." + Environment.NewLine +
                "Dedicated Website: https://dochacknik.keybase.pub/index/openbot");
            Embed.WithTimestamp(DateTime.Now);
            await Context.Channel.SendMessageAsync(string.Empty, false, Embed.Build());

            string Message = "Command **!help** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }
    }
}