using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Reflection;
using System.Threading.Tasks;

namespace RyuBot
{
    public class CommandHandler : ModuleBase<SocketCommandContext>
    {
        private DiscordSocketClient DiscordClient;
        private CommandService      CmdService;

        public CommandHandler(DiscordSocketClient client)
        {
            DiscordClient = client;
            CmdService    = new CommandService();

            CmdService.AddModulesAsync(Assembly.GetEntryAssembly());
            DiscordClient.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage SocketMsg)
        {
            SocketUserMessage UserMsg = (SocketUserMessage)SocketMsg;

            if (UserMsg == null) return;

            int ArgPos = 0;
            SocketCommandContext Context = new SocketCommandContext(DiscordClient, UserMsg);

            if (UserMsg.HasCharPrefix('!', ref ArgPos))
            {
                var Result = await CmdService.ExecuteAsync(Context, ArgPos);
                if (!Result.IsSuccess && Result.Error != CommandError.UnknownCommand)
                {
                    var Messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
                    await this.Context.Channel.DeleteMessagesAsync(Messages);

                    await Context.Channel.SendMessageAsync(Result.ErrorReason);

                    string ErrorMessage = "ERROR: The command requested was invalid or syntax was the incorrect";

                    await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", ErrorMessage));
                    await this.Context.Channel.SendMessageAsync(ErrorMessage);
                }
            }
        }
    }
}