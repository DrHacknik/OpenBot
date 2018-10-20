using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace OpenBot.Modules
{
    public class MdWeather : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();
        private static string cd = Environment.CurrentDirectory;
        private static IniParser parser = new IniParser(cd + "\\Temp\\Database.ini");
        public static WebClient GetDatabaseFile = new WebClient();

        [Command("weather")]
        public async Task Weather(string Location)
        {
            await Context.Message.DeleteAsync();
            WeatherInfo.city = Location;

            GrabDatabaseFile();
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithThumbnailUrl("https://github.com/DrHacknik/OpenBot/raw/master/Data/Images/Icons/" + WeatherInfo.icon);
            Embed.WithTitle("Weather for: " + WeatherInfo.city);
            Embed.WithColor(new Color(236, 183, 4));
            Embed.WithDescription("Location: " + WeatherInfo.city + Environment.NewLine + "Current Condition: " + WeatherInfo.current + Environment.NewLine + "Temp: " + WeatherInfo.temp);
            Embed.WithTimestamp(DateTime.UtcNow);
            await Context.Channel.SendMessageAsync(String.Empty, false, Embed.Build());

            string Message = "Command **!weather** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }

        public void GrabDatabaseFile()
        {
        }

        public class ParseWeather
        {
        }
    }
}