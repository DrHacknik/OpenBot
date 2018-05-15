using Discord;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RyuBot
{
    public static class Helper
    {
        public static DiscordSocketClient _DiscordClient;

        /*
         * Basic Logging function who don't handle RESTful request log.
         */
        public static async Task LoggingAsync(LogMessage LogMsg)
        {
            string CurrentTime = DateTime.Now.ToString();

            Console.WriteLine(CurrentTime + " > " + Environment.NewLine + LogMsg.Message);

            string[] HTTPMethods = { "DELETE", "GET", "PATCH", "POST", "PUT" };

            if (!HTTPMethods.Contains(LogMsg.Message.Split(' ').First()))
            {
                EmbedBuilder Embed = new EmbedBuilder();
                Embed.WithTitle(LogMsg.Source + " > " + CurrentTime);
                Embed.WithDescription(LogMsg.Message);

                await ((IMessageChannel)_DiscordClient.GetChannel(Config.BotChannelId)).SendMessageAsync("", false, Embed);
            }
        }

        /*
         * Run Async function as Sync one.
         */
        public static void RunAsync(Task task)
        {
            task.ContinueWith(t => { }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
