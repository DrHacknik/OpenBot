using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using RyuBot.Data;
using RyuBot.Modules;
using RyuBot.Services;

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
a proper Config parser later on. Most likely XML.

----------------------------------------------

This bot also has a Logging system. The log is 
automatically dumped to the user config folder
within the subdirectory "RyuBot." Each `.log` 
file is time stamped with the date. This is 
done this way, because who'd want a log dump for 
every min or hour. Since the bot is expected to 
run daily and continue to run.

==============================================
 */
namespace RyuBot {
    public class Program {
        private static void Main (string[] args) => new Program ().StartAsync ().GetAwaiter ().GetResult ();

        private static DiscordSocketClient DiscordClient;
        private CommandHandler CmdHandler;
        private static string cd = Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "\\RyuBot";

        public async Task StartAsync () {
            string ApiKey = File.ReadAllText (Path.Combine (cd + "\\" + Config.ApiFile));

            DiscordClient = new DiscordSocketClient (new DiscordSocketConfig {
                LogLevel = LogSeverity.Verbose
            });

            Helper._DiscordClient = DiscordClient;
            DiscordClient.Log += Helper.LoggingAsync;

            try {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Clear ();
                Helper.RunAsync (Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Bot", "========================================================================\r\n^.^\\ Starting AwooBot~\r\nVersion: " + Config.Version + "\r\nPlatform: " + Config.OS + "\r\n========================================================================\r\n")));
                Console.ForegroundColor = ConsoleColor.White;
                Helper.RunAsync (Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Bot", "Reading Key file...")));
                Helper.RunAsync (Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Bot", "Connecting...")));

                await DiscordClient.LoginAsync (TokenType.Bot, ApiKey);

                Helper.RunAsync (Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Bot", "Key file is valid")));

                await DiscordClient.StartAsync ();

                CmdHandler = new CommandHandler (DiscordClient);
            } catch (Exception Ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                string ExMessage = "ERROR: Key file is invalid! Or an Internet connection is unavailable." + Environment.NewLine +
                    "ERROR: There was an internal bot error." + Environment.NewLine +
                    Ex;

                Helper.RunAsync (Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Bot", ExMessage)));

                await Task.Delay (-1);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            DiscordClient.Ready += async () => {
                string Message = "=====================================" + Environment.NewLine +
                    "Awoo-bot-beta for Discord" + Environment.NewLine +
                    "by Dr.Hacknik" + Environment.NewLine +
                    "Version: " + Config.Version + Environment.NewLine +
                    "Bot name: Awoobot" + Environment.NewLine +
                    "Bot revision: " + Config.BuildDate + Environment.NewLine +
                    "Bot Type: DotNet Core | Web-socket-based" + Environment.NewLine +
                    "Bot Plaform: " + Config.OS + Environment.NewLine +
                    "=====================================";

                await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Bot", Message));
                if (cd + "\\RyuStatus" == null) {
                    await DiscordClient.SetGameAsync (Config.GameStatus);
                } else {
                    await DiscordClient.SetGameAsync (File.ReadAllText (Path.Combine (cd + "\\RyuStatus")));
                }
            };

            await Task.Delay (-1);
        }

        public static async Task SetStatus () {
            await DiscordClient.SetGameAsync (Config.GameStatus);
            File.WriteAllText (cd + "\\" + Config.StatusFile, Config.GameStatus);
            return;
        }
    }
}