using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace OpenBot
{
    public class MdSetLewdDir : ModuleBase<SocketCommandContext>
    {
        private string cd = Directory.GetCurrentDirectory();

        private string time = DateTime.Now.ToString();

        [Command("SetLewdDir")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task SetDir([Remainder] string IDir)
        {
            await Context.Message.DeleteAsync();
            string Message = "Command **!setlewddir** requested by " + Context.User.Username + ">" + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + "> with value: *" + IDir + "*";
            Config.LewdDir = IDir;
            Program.SaveConfig();
            await Context.Channel.SendMessageAsync("The Lewd Directory has been set! ^.^");
            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
            return;
        }
    }
}