using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RyuBot
{
    public class About : ModuleBase<SocketCommandContext>
    {
        private string cd = System.IO.Directory.GetCurrentDirectory();

        private string time = DateTime.Now.ToString();

        private string key_stat = "ubuntu-x64";

        [Command("About")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task SendAbout()

        {
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            string Message = "=====================================" + Environment.NewLine +
            "RyuBot-beta for Discord" + Environment.NewLine +
            "by Dr.Hacknik & Ac_K" + Environment.NewLine +
            "Version: 0.2.1" + Environment.NewLine +
            "Bot name: RyuBot" + Environment.NewLine +
            "Bot revision: 18_5_16_0000am" + Environment.NewLine +
            "Bot Type: DotNet Core | Web-socket-based" + Environment.NewLine +
            "=====================================";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", Message));
            await Context.Channel.SendMessageAsync(Message);
        }
    }
}