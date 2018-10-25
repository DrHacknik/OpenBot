using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using OpenBot.Services;

/*
==============================================

Do keep in mind this Bot is completely open-source
and licensed under the GNU GPL v3 License Agreement.

This bot used to formly known as Ryu-bot; and thusly
is still named so. But it's correct name is indeed
OpenBOT since this bot can be compiled and used
with any API Key.

Thusly, it is requested and upheld with the license
that all information pertaining that the source
is indeed OpenBOT's or a variant of such, is
directly shown in the code and within the Commands
themselves. IE: Within the About section.

----------------------------------------------

This bot may be used in servers with NSFW or
no NSFW. Although, this bot (as of 0.2.4.x)
does not support parsing of popular image
boards for NSFW content. So, that will need
to be implemented. Otherwise a traditional
Image upload method (Parsed from a local directory)
is used.

----------------------------------------------

This bot also has a fallback system; if the bot
Disconnects the API will reconnect and resume the
session. If the bot crashes (in some instances)
it can recover perfectly by rebooting itself.
Although this rarely works; since this bot is
mostly used on Linux systems and servers.

----------------------------------------------

All Config Strings are stored within `Config.cs`
Although, hopefully sometime soon I will implement
a proper Config parser later on. Most likely XML or
JSON.

----------------------------------------------

This bot also has a Logging system. The log is
automatically dumped to the user config folder
within the subdirectory "OpenBot." Each `.log`
file is time stamped with the date. This is
done this way, because who'd want a log dump for
every min or hour. Since the bot is expected to
run daily and continue to run.

==============================================
 */

namespace OpenBot
{
    public class Program
    {
        private static void Main(string[] args) => new Program().StartAsync().GetAwaiter().GetResult();

        private static DiscordSocketClient DiscordClient;
        private CommandHandler CmdHandler;
        private string ApiKey = Config.ApiKey;
        private static string cd = Config.BotDir;

        public async Task StartAsync()
        {
            if (Config.Branch == "Canary")
            {
                Config.BotDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OpenBot\\Canary";
            }
            else if (Config.BotDir == "Master")
            {
                Config.BotDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OpenBot";
            }
            if (!File.Exists(cd + "\\Config\\Config.ini"))
            {
                CreateBotDir();
                CreateConfig();
                SaveConfig();
            }
            else
            {
                await ParseConfig();
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "========================================================================\r\n\\^.^/ Starting " + Config.BotName + "~\r\nVersion: " + Config.Version + "\r\nPlatform: " + Config.OS + "\r\n========================================================================\r\n")));
            Console.ForegroundColor = ConsoleColor.White;
            if (File.ReadAllText(Path.Combine(cd + "\\ApiKey")) == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "No API Token is stored within the Config.")));
                Console.ForegroundColor = ConsoleColor.Red;
                Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "The bot has stopped due to a previous error. \r\nPlease fix the issue and restart the bot.")));
                Console.ForegroundColor = ConsoleColor.White;
                await Task.Delay(-1);
                return;
            }

            DiscordClient = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });

            Helper._DiscordClient = DiscordClient;
            DiscordClient.Log += Helper.LoggingAsync;

            try
            {
                Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "Reading Key file...")));

                Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "Connecting...")));

                await DiscordClient.LoginAsync(TokenType.Bot, File.ReadAllText(Path.Combine(cd + "\\ApiKey")));

                Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "Key file is valid")));

                await DiscordClient.StartAsync();

                CmdHandler = new CommandHandler(DiscordClient);
            }
            catch (Exception Ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                string ExMessage = "ERROR: Key file is invalid! Or an Internet connection is unavailable." + Environment.NewLine +
                    "ERROR: There was an internal bot error." + Environment.NewLine +
                    Ex;

                Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", ExMessage)));
                Console.ForegroundColor = ConsoleColor.Red;
                Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "The bot has stopped due to a previous error. \r\nPlease fix the issue and restart the bot.")));
                Console.ForegroundColor = ConsoleColor.White;
                await Task.Delay(-1);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            DiscordClient.Ready += async () =>
            {
                string Message = "=====================================" + Environment.NewLine +
                    Config.BotName + " for Discord" + Environment.NewLine +
                    "by Dr.Hacknik" + Environment.NewLine +
                    "Version: " + Config.Version + Environment.NewLine +
                    "Bot name: " + Config.BotName + Environment.NewLine +
                    "Bot revision: " + Config.BuildDate + Environment.NewLine +
                    "Bot Type: DotNet Core | Web-socket-based" + Environment.NewLine +
                    "Bot Plaform: " + Config.OS + Environment.NewLine +
                    "=====================================";

                SvcGetupdate.CheckUpdate();
                await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", Message));
            };

            await SetStatus();
            await Task.Delay(-1);
        }

        public static async Task SetStatus()
        {
            while (true)
            {
                int Count = DiscordClient.Guilds.Count();
                string SCount = Count.ToString();
                await DiscordClient.SetGameAsync("on " + SCount + " Guilds.");
                await Task.Delay(-1);
            }
        }

        public static void CreateBotDir()
        {
            if (!Directory.Exists(cd))
            {
                try
                {
                    Directory.CreateDirectory(cd);
                    return;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "Unable to create Bot Directory")));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Helper.RunAsync(Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", "The bot has stopped due to a previous error. \r\nPlease fix the issue and restart the bot.")));
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }
        }

        public static void CreateConfig()
        {
            Directory.CreateDirectory(cd + "\\Config");
            File.Create(cd + "\\Config\\Config.ini");
            IniParser parser = new IniParser(cd + "\\Config\\Config.ini");
            parser.AddSetting("botsettings", "botlewddir");
            parser.AddSetting("botsettings", "logwithoutstamp");
            parser.AddSetting("botsettings", "branch", "canary");
            parser.SaveSettings(cd + "\\Config\\Config.ini");
            return;
        }

        public static void SaveConfig()
        {
            IniParser parser = new IniParser(cd + "\\Config\\Config.ini");
            parser.AddSetting("botsettings", "botlewddir", Config.LewdDir);
            parser.AddSetting("botsettings", "logwithoutstamp", Config.LogWithoutStamp);
            parser.SaveSettings(cd + "\\Config\\Config.ini");
            return;
        }

        public async Task ParseConfig()
        {
            IniParser parser = new IniParser(cd + "\\Config\\Config.ini");
            try //Parse the config file
            {
                Config.LewdDir = parser.GetSetting("botsettings", "botlewddir");
                Config.LogWithoutStamp += parser.GetSetting("botsettings", "logwithoutstamp");
                // if (parser.GetSetting("botsettings", "branch") == "Canary")
                // {
                //     Config.BotDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OpenBot\\Canary";
                //     Config.Branch = "Canary";
                // }
                // else
                // {
                //     Config.BotDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OpenBot";
                //     Config.Branch = "Master";
                // }
                await SetStatus();
            }
            catch (Exception ex) { }
            return;
        }
    }
}