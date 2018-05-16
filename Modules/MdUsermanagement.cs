using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class UserManagement : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("Kick")]
        [RequireBotPermission(GuildPermission.KickMembers)]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task KickUser(IGuildUser user, [Remainder]string reason)
        {
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            await user.KickAsync(reason);
            string Message = "Command **!kick** requested by <@" + Context.Message.Author.Id  + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">" + "Mentioned User: <" + user.Mention + ">" + " Kick reason: <" + reason + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }

        [Command("Ban")]
        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task BanUser(IGuildUser user, [Remainder]string reason)
        {
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            await user.Guild.AddBanAsync(user, 1, reason);
            string Message = "Command **!ban** requested by <@" + Context.Message.Author.Id  + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">" + "Mentioned User: <" + user.Mention + ">" + " Ban reason: <" + reason + ">";

        }

        [Command("Mute")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        [RequireBotPermission(GuildPermission.MuteMembers)]
        public async Task MuteUser(IGuildUser user, [Remainder]string reason)
        {
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            await Context.Channel.SendMessageAsync("This Command isn't ready yet.");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
             string Message = "Command **!mute** requested by <@" + Context.Message.Author.Id  + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">" + "Mentioned User: <" + user.Mention + ">" + " Mute reason: <" + reason + ">";

        }
    }
}
