using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace OpenBot.Modules
{
    public class MdStubbed : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("stub-specific")]
        public async Task StubSpecific(SocketGuildUser MentionedUser, [Remainder] string Stub)
        {
            await Context.Message.DeleteAsync();

            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithTitle("The following user been stubbed: " + MentionedUser.Username);
            Embed.WithColor(new Color(161, 9, 238));
            Embed.WithDescription("```" + Environment.NewLine + Environment.NewLine + Stub + "```");
            Embed.WithTimestamp(DateTime.UtcNow);
            await Context.Channel.SendMessageAsync(String.Empty, false, Embed.Build());

            string Message = "Command **!stub-specific** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }

        [Command("stub")]
        public async Task Stub(SocketGuildUser MentionedUser)
        {
            await Context.Message.DeleteAsync();
            await Context.Channel.SendMessageAsync("User " + MentionedUser.Mention + " has been stubbed.", false);

            string Message = "Command **!stub** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }
    }
}