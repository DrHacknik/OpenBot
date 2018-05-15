using Discord;
using Discord.WebSocket;
using RyuBot.Modules;
using RyuBot.Data;
using RyuBot.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace RyuBot
{
    public class Program
    {
        private static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient DiscordClient;
        private CommandHandler      CmdHandler;

        public async Task StartAsync()
        {
            string ApiKey = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), Config.ApiFile));
            
            DiscordClient = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });

            Helper._DiscordClient = DiscordClient;
            DiscordClient.Log    += Helper.LoggingAsync;

            try
            {
                Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "Reading Key file...")));
                Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "Connecting...")));

                await DiscordClient.LoginAsync(TokenType.Bot, ApiKey);

                Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "Key file is valid")));

                await DiscordClient.StartAsync();

                CmdHandler = new CommandHandler(DiscordClient);
            }
            catch (Exception Ex)
            {
                string ExMessage = "ERROR: Key file is invalid! Or an Internet connection is unavailable." + Environment.NewLine + 
                                   "ERROR: There was an internal bot error." + Environment.NewLine + 
                                   Ex;

                Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", ExMessage)));

                await Task.Delay(-1);

                return;
            }

            DiscordClient.Ready += async () =>
            {
                string Message = "=====================================" + Environment.NewLine +
                                 "RyuBot for Discord" + Environment.NewLine +
                                 "by Dr.Hacknik & Ac_K" + Environment.NewLine +
                                 "Version: 0.2.0" + Environment.NewLine +
                                 "Bot name: RyuBot" + Environment.NewLine +
                                 "Bot revision: 18_5_16_0000am" + Environment.NewLine +
                                 "Bot Type: DotNet Core | Web-socket-based" + Environment.NewLine +
                                 "=====================================";


                await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", Message));
            };

            await Task.Delay(-1);
        }
    }
}