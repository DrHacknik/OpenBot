using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace OpenBot.Modules {
    public class MdWeather : ModuleBase<SocketCommandContext> {
        private string time = DateTime.Now.ToString ();
        private static string cd = Environment.CurrentDirectory;
        private static IniParser parser = new IniParser (cd + "\\Temp\\Database.ini");
        public static WebClient GetDatabaseFile = new WebClient ();

        [Command ("weather")]
        public async Task Weather (string Location) {
            await Context.Message.DeleteAsync ();
            WeatherInfo.city = Location;

            EmbedBuilder Embed = new EmbedBuilder ();
            Embed.WithThumbnailUrl ("https://raw.githubusercontent.com/DrHacknik/OpenBot/master/Data/Images/Icons/Sunny.png");
            Embed.WithTitle ("The command 'weather' is not ready.");
            Embed.WithColor (new Color (236, 183, 4));
            Embed.WithDescription ("Please wait until this command is ready (as of 0.2.6.0-canary). This is the canary branch of the bot; so this command will be fully implemented soon." +
                Environment.NewLine + Environment.NewLine + "This command also uses the OpenWeather Map API." + Environment.NewLine + Environment.NewLine +
                "**Debug data:**" + Environment.NewLine + "```" + Environment.NewLine + "Location Requested: " +
                Location + Environment.NewLine + "Weather Icon Requested: Sunny" + Environment.NewLine + "Temp Unit Requested: Fahrenheit" + Environment.NewLine + "```");
            Embed.WithTimestamp (DateTime.UtcNow);
            await Context.Channel.SendMessageAsync (String.Empty, false, Embed.Build ());
            //GrabDatabaseFile();
            //await ParseWeatherAsync();

            //EmbedBuilder Embed = new EmbedBuilder();
            //Embed.WithThumbnailUrl("https://github.com/DrHacknik/OpenBot/raw/master/Data/Images/Icons/" + WeatherInfo.icon);
            //Embed.WithTitle("Weather for: " + WeatherInfo.city);
            //Embed.WithColor(new Color(236, 183, 4));
            //Embed.WithDescription("Location: " + WeatherInfo.city + Environment.NewLine + "Current Condition: " + WeatherInfo.current + Environment.NewLine + "Temp: " + WeatherInfo.temp);
            //Embed.WithTimestamp(DateTime.UtcNow);
            //await Context.Channel.SendMessageAsync(String.Empty, false, Embed.Build());

            string Message = "Command **!weather** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
        }

        public void GrabDatabaseFile () {
            return;
        }

        public async Task ParseWeatherAsync () {
            string OPWM = "http://api.openweathermap.org/data/2.5/weather?q=" + WeatherInfo.apikey + "&mode=xml";
            var XML = await new WebClient ().DownloadStringTaskAsync (new Uri (OPWM));
            XmlDocument OPWMDOC = new XmlDocument ();
            OPWMDOC.LoadXml (XML);
            string szTemp = OPWMDOC.DocumentElement.SelectSingleNode ("temperature").Attributes["value"].Value;
            double temp = double.Parse (szTemp) - 273.16;

            WeatherInfo.temp = temp.ToString ("N2") + " Fahrenheit ";
            return;
        }
    }
}