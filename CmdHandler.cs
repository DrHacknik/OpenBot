using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace OpenBot
{
    public class CommandHandler : ModuleBase<SocketCommandContext>
    {
        private DiscordSocketClient DiscordClient;
        private CommandService CmdService;

        public CommandHandler(DiscordSocketClient client)
        {
            DiscordClient = client;
            CmdService = new CommandService(new CommandServiceConfig
            {
                LogLevel = LogSeverity.Verbose, // Tell the logger to give Verbose debug information
                DefaultRunMode = RunMode.Async, // Force all commands to run async by default
                CaseSensitiveCommands = false // Ignore letter case when executing commands
            });

            CmdService.AddModulesAsync(Assembly.GetEntryAssembly());
            DiscordClient.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage SocketMsg)
        {
            SocketUserMessage UserMsg = (SocketUserMessage)SocketMsg;

            if (UserMsg == null) return;

            int ArgPos = 0;
            SocketCommandContext Context = new SocketCommandContext(DiscordClient, UserMsg);

            /*
            I'm lazy and put a bunch of Responses in a string or two.
            And fucked myself by using if Statements and shitty strings :/
            Case sensitivity is a bitch

            This code can also be commented out if needed. I just made it for the
            memes.
            */
            string[] ContentListNoU;
            ContentListNoU = new string[] {
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
            Random randNoU;
            randNoU = new Random();
            int randomIndexNoU = randNoU.Next(ContentList.Length);
            string NoUResponse = ContentList[randomIndexNoU];
            string NoUResponseFinal = NoUResponse;

            Random rand;
            rand = new Random();
            int randomIndex = rand.Next(ContentListNoU.Length);
            string NoU = ContentListNoU[randomIndex];
            string NoUFinal = NoU;
            if (UserMsg.Content.Equals("Fuck you", StringComparison.CurrentCultureIgnoreCase))
            {
                await Context.Channel.SendMessageAsync(NoUFinal);
            }
            if (UserMsg.Content.Equals("You have big gay", StringComparison.CurrentCultureIgnoreCase))
            {
                await Context.Channel.SendMessageAsync(NoUFinal);
            }

            if (UserMsg.Content.Equals("You have big gai", StringComparison.CurrentCultureIgnoreCase))
            {
                await Context.Channel.SendMessageAsync(NoUFinal);
            }

            if (UserMsg.Content.Equals("Gay", StringComparison.CurrentCultureIgnoreCase))
            {
                await Context.Channel.SendMessageAsync(NoUFinal);
            }

            if (UserMsg.Content.Equals("Gai", StringComparison.CurrentCultureIgnoreCase))
            {
                await Context.Channel.SendMessageAsync(NoUFinal);
            }

            if (UserMsg.Content.Equals("Nya", StringComparison.CurrentCultureIgnoreCase))
            {
                await Context.Channel.SendMessageAsync("Nyaaaaa!");
            }

            if (UserMsg.Content.Equals("Nyah", StringComparison.CurrentCultureIgnoreCase))
            {
                await Context.Channel.SendMessageAsync("Nyaaaaa!");
            }

            if (UserMsg.Content.Equals("No u", StringComparison.CurrentCultureIgnoreCase))
            {
                await Context.Channel.SendMessageAsync(NoUResponseFinal);
            }

            if (UserMsg.Content.Equals("Des", StringComparison.CurrentCultureIgnoreCase))
            {
                await Context.Channel.SendMessageAsync("pa");
            }
            if (UserMsg.Content.Equals("ci", StringComparison.CurrentCultureIgnoreCase))
            {
                await Context.Channel.SendMessageAsync("to");
            }
            if (UserMsg.Content.Equals("Paisanos", StringComparison.CurrentCultureIgnoreCase))
            {
                await Context.Channel.SendMessageAsync("https://www.youtube.com/watch?v=U8v16kFEt-o");
            }

            if (UserMsg.HasCharPrefix('!', ref ArgPos))
            {
                var Result = await CmdService.ExecuteAsync(Context, ArgPos);
                if (!Result.IsSuccess && Result.Error != CommandError.UnknownCommand)
                {
                    await Context.Message.DeleteAsync();

                    //await Context.Channel.SendMessageAsync(Result.ErrorReason);

                    string ErrorMessage = "ERROR: The command requested was invalid or syntax was the incorrect";

                    await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", ErrorMessage));
                    //await this.Context.Channel.SendMessageAsync(ErrorMessage);
                }
            }
        }
    }
}