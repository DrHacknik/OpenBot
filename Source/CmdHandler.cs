using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace OpenBot {
    public class CommandHandler : ModuleBase<SocketCommandContext> {
        private DiscordSocketClient DiscordClient;
        private CommandService CmdService;

        public CommandHandler (DiscordSocketClient client) {
            DiscordClient = client;
            CmdService = new CommandService (new CommandServiceConfig {
                LogLevel = LogSeverity.Verbose, // Tell the logger to give Verbose debug information
                    DefaultRunMode = RunMode.Async, // Force all commands to run async by default
                    CaseSensitiveCommands = false // Ignore letter case when executing commands
            });

            CmdService.AddModulesAsync (Assembly.GetEntryAssembly ());
            DiscordClient.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync (SocketMessage SocketMsg) {
            SocketUserMessage UserMsg = (SocketUserMessage) SocketMsg;
            int ArgPos = 0;
            SocketCommandContext Context = new SocketCommandContext (DiscordClient, UserMsg);

            var Responses = new string[] {
                "You have big gay",
                "You have big gai",
                "Gay",
                "Gai",
                "No u",
                "Des",
                "Pa",
                "Ci",
                "To",
            };

            var ContentListNoU = new string[] {
                "No u",
                "U no",
                "Uno",
                "But why?",
                "You know what, fuck you!",
                "Why not everyone?",
                "UwU",
                "OwO",
                "Despacito",
                "Don't lose your gay.",
                "Why not we?",
                "Ok.",
                "Ok, get naked.",
                "Ok, we can rub our dicks together.",
                "Why not you though?",
                "Nani",
                "Nani sore",
                "Why you have to be mad; is only game.",
                "https://youtu.be/sxo5_4mTFDE"
            };

            string[] ContentList;
            ContentList = new string[] {
                "https://www.youtube.com/watch?v=6dAMPTVhsfI",
                "Why not No U?",
                "https://www.youtube.com/watch?v=72LKjGErD9o",
                "Uno",
                "Ok",
            };

            // foreach (var Str in Responses)
            // {
            //     if (Str == ContentListNoU)
            //     {
            //         Random randNoU;
            //         randNoU = new Random();
            //         int randomIndexNoU = randNoU.Next(ContentList.Length);
            //         string NoUResponse = ContentList[randomIndexNoU];
            //         string NoUResponseFinal = NoUResponse;

            //         Random rand;
            //         rand = new Random();
            //         int randomIndex = rand.Next(ContentListNoU.Length);
            //         string NoU = ContentListNoU[randomIndex];
            //         string NoUFinal = NoU;
            //         if (UserMsg.Content.Equals(Str, StringComparison.CurrentCultureIgnoreCase))
            //         {
            //             await Context.Channel.SendMessageAsync(NoUFinal);
            //             break;
            //         }
            //     }
            // }

            if (UserMsg == null) return;

            if (UserMsg.HasCharPrefix ('!', ref ArgPos)) {
                var Result = await CmdService.ExecuteAsync (Context, ArgPos);
                if (!Result.IsSuccess && Result.Error != CommandError.UnknownCommand) {
                    await Context.Message.DeleteAsync ();

                    //await Context.Channel.SendMessageAsync(Result.ErrorReason);

                    string ErrorMessage = "ERROR: The command requested was invalid or syntax was the incorrect";

                    await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Bot", ErrorMessage));
                    //await this.Context.Channel.SendMessageAsync(ErrorMessage);
                }
            }
        }
    }
}