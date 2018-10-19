using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Net;
using System.Xml;

namespace OpenBot.Modules
{
    public class MdWeather : ModuleBase<SocketCommandContext>
    {
        private string time = DateTime.Now.ToString();

        [Command("weather")]
        public async Task Weather(string Location)
        {
            await Context.Message.DeleteAsync();
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithTitle("Weather for: " + Location);
            Embed.WithColor(new Color(236, 183, 4));
            Embed.WithImageUrl("");
            Embed.WithDescription("Location: " + Location + Environment.NewLine + "Current Condition: " + current + Environment.NewLine + "Temp: " + temp);
            Embed.WithTimestamp(DateTime.UtcNow);
            await Context.Channel.SendMessageAsync(String.Empty, false, Embed.Build());

            string Message = "Command **!weather** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
        }

        public class ParseWeather
        {
            public void WeatherData()
            {
                WeatherInfo.location = City;
            }

            private string city;
            private float temp;
            private float tempMax;
            private float tempMin;

            public void CheckWeather()
            {
                WeatherAPI DataAPI = new WeatherAPI(City);
                temp = DataAPI.GetTemp();
            }

            public string City { get => city; set => city = value; }
            public float Temp { get => temp; set => temp = value; }
            public float TempMax { get => tempMax; set => tempMax = value; }
            public float TempMin { get => tempMin; set => tempMin = value; }
        }
    }

    internal class WeatherAPI
    {
        public WeatherAPI(string city)
        {
            SetCurrentURL(city);
            xmlDocument = GetXML(CurrentURL);
        }

        public float GetTemp()
        {
            XmlNode temp_node = xmlDocument.SelectSingleNode("//temperature");
            XmlAttribute temp_value = temp_node.Attributes["value"];
            string temp_string = temp_value.Value;
            return float.Parse(temp_string);
        }

        private const string APIKEY = "API KEY HERE";
        private string CurrentURL;
        private XmlDocument xmlDocument;

        private void SetCurrentURL(string location)
        {
            CurrentURL = "http://api.openweathermap.org/data/2.5/weather?q="
                + location + "&mode=xml&units=metric&APPID=" + APIKEY;
        }

        private XmlDocument GetXML(string CurrentURL)
        {
            using (WebClient client = new WebClient())
            {
                string xmlContent = client.DownloadString(CurrentURL);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlContent);
                return xmlDocument;
            }
        }
    }
}