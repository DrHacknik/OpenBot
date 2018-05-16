using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class MdReboot : ModuleBase<SocketCommandContext>
    {
        [Command("Reboot")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Reboot()
        {
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(ReturnMsg);

            await Context.Channel.SendMessageAsync("Rebooting the bot... Hum... Wait... This can take up to a minute.");

            string Message = "Command **!reboot** requested by <@" + Context.Message.Author.Id + ">" + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));

            Environment.Exit(0);
        }
    }
}