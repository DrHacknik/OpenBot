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

        private DiscordSocketClient _client;
        private CommandHandler _handler;

        private string CurrentDirectory = Directory.GetCurrentDirectory();
        private string time = DateTime.Now.ToString();
        private string key_stat = "ubuntu-x64";

        public async Task StartAsync()
        {
            string ApiKey = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "ApiKey.txt"));

            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });

            _client.Log += Logging;

            Console.WriteLine("=====================================" +
                              "\r\nDr.Hackniks RyujiNX Bot for Discord" +
                              "\r\nVersion: 0.1.5" +
                              "\r\nBot name: OpenBot" +
                              "\r\nBot revision: 18_4_19_1034pm" +
                              "\r\nBot Type: " + key_stat + " | Web-socket-based" +
                              "\r\n=====================================");

            try
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(time + ":: Reading Key file...");
                Console.WriteLine(time + ":: Connecting...");
                await _client.LoginAsync(TokenType.Bot, ApiKey);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(time + ":: Key file is valid");
                await _client.StartAsync();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine(time + ":: Bot has connected");
                _handler = new CommandHandler(_client);
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(time + ":ERROR: Key file is invalid! Or an Internet connection is unavailable." +
                "\r\n" + time + ":ERROR: There was an internal bot error.");
                Console.WriteLine(ex);
                await Task.Delay(-1);
                return;
            }
            ConsoleInput();
            Console.BackgroundColor = ConsoleColor.Black;
            await Task.Delay(-1);
        }

        private async Task ConsoleInput()
        {
            var CoInput = string.Empty;
            while (CoInput.Trim().ToLower() != "console_exit")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                CoInput = Console.ReadLine();
                if (CoInput.Trim().ToLower() == "console_sendmsg")
                    ConsoleSendMessage();
            }
        }
        private async void ConsoleSendMessage()
        {
            Console.WriteLine("Select a Server: ");
            var server = GetSelectedServer(_client.Guilds);
            var Tchannel = GetSelectedChannel(server.TextChannels);
            var msg = string.Empty;
            while(msg.Trim() == string.Empty)
            {
                Console.WriteLine("Type a message: ");
                msg = Console.ReadLine();
            }
            await Tchannel.SendMessageAsync(msg);
        }

        private SocketGuild GetSelectedServer(IEnumerable<SocketGuild> servers)
        {
            var socketServers = servers.ToList();
            var MaxIndex = servers.Count() -1;
            for (var i = 0; i <= MaxIndex; i++)
            {
                Console.WriteLine($"{i} - {socketServers[i].Name}");
            }

            var selectedIndex = -1;
            while(selectedIndex < 0 || selectedIndex > MaxIndex)
            {
               var success = int.TryParse(Console.ReadLine().Trim(), out selectedIndex);
                if (!success) Console.WriteLine("Sorry, that was an invalid index.");
                //if (selectedIndex < 0 || selectedIndex > MaxIndex) Console.WriteLine("");
                //{

                //}
            }
            return socketServers[selectedIndex];
        }
        private SocketTextChannel GetSelectedChannel(IEnumerable<SocketTextChannel> channels)
        {
            var textChannels = channels.ToList();
            var MaxIndex = channels.Count() - 1;
            for (var i = 0; i <= MaxIndex; i++)
            {
                Console.WriteLine($"{i} - {textChannels[i].Name}");
            }

            var selectedIndex = -1;
            while (selectedIndex < 0 || selectedIndex > MaxIndex)
            {
                var success = int.TryParse(Console.ReadLine().Trim(), out selectedIndex);
                if (!success) Console.WriteLine("Sorry, that was an invalid index.");
                //if (selectedIndex < 0 || selectedIndex > MaxIndex) Console.WriteLine("");
                //{

                //}
            }
            return textChannels[selectedIndex];
        }

        private async Task Logging(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
            //await ((ISocketMessageChannel)_client.GetChannel(410243700183138306)).SendMessageAsync(msg.Message);
        }


    }
}