using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class Res : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("Res")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task res(SocketGuildUser user)
        {
            //var embed = new EmbedBuilder();
            //embed.WithTitle("Resources:");
            //embed.WithDescription(message);
            //embed.WithColor(new Color(0, 255, 0));
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            await Context.Channel.SendMessageAsync(user.Mention + "__**Please visit the following sites for more information:**__ \r\nhttps://zoltx23.github.io/ryujinx-emu/ \r\nhttps://github.com/gdkchan/Ryujinx");
            string Message = "Command **!res** requested by <@" + Context.Message.Author.Id  + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">" + "Mentioned User: <" + user.Mention + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }
    }
}