using Ionic.Zip;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace OpenBot.Services
{
    internal class SvcGetupdate
    {
        public static WebClient upd_dwld = new WebClient();
        public static WebClient upd_theme = new WebClient();
        public static WebClient get_info = new WebClient();
        public static WebClient GetDatabaseFile = new WebClient();
        public static string cd = Environment.CurrentDirectory;
        public static string Temp = cd + "\\Temp";
        public static string Version;
        public static string BuildID;
        public static string BuildDate;
        public static string VersionNotes;
        private static string CurrentTime = DateTime.Now.ToString();

        public static void CheckUpdate()
        {
            try
            {
                Console.WriteLine(CurrentTime + " > ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Checking for bot updates...");
                Console.ForegroundColor = ConsoleColor.White;

                //Read latest update and convert to string
                WebRequest request = WebRequest.Create("https://github.com/DrHacknik/OpenBot/raw/master/Updates/Update.ini");
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader upd_rd = new StreamReader(dataStream);
                string upd_get = upd_rd.ReadToEnd();

                if (!Directory.Exists(cd + "\\Temp"))
                {
                    Directory.CreateDirectory(cd + "\\Temp");
                }
                if (File.Exists(cd + "\\Temp\\Update.ini"))
                {
                    File.Delete(cd + "\\Temp\\Update.ini");
                    File.WriteAllText(cd + "\\Temp\\Update.ini", upd_get);
                }
                else
                {
                    File.WriteAllText(cd + "\\Temp\\Update.ini", upd_get);
                }

                WebRequest request1 = WebRequest.Create("https://github.com/DrHacknik/OpenBot/raw/master/Data/Images/Icons/Database.ini");
                WebResponse response1 = request1.GetResponse();
                Stream dataStream1 = response1.GetResponseStream();
                StreamReader DataRead = new StreamReader(dataStream);
                string DataGet = DataRead.ReadToEnd();

                if (!Directory.Exists(cd + "\\Temp"))
                {
                    Directory.CreateDirectory(cd + "\\Temp");
                }
                if (File.Exists(cd + "\\Temp\\Database.ini"))
                {
                    File.Delete(cd + "\\Temp\\Database.ini");
                    File.WriteAllText(cd + "\\Temp\\Database.ini", DataGet);
                }
                else
                {
                    File.WriteAllText(cd + "\\Temp\\Database.ini", DataGet);
                }
                IniParser parser1 = new IniParser(cd + "\\Temp\\Database.ini");
                WeatherInfo.icon = parser1.GetSetting("normal_conditions", "clearnight");

                //Get and read latest update info, then grab it
                //But first delete old files, and continue.

                IniParser parser = new IniParser(cd + "\\Temp\\Update.ini");
                Version = parser.GetSetting("update", "version");
                BuildID = parser.GetSetting("update", "buildid");
                BuildDate = parser.GetSetting("update", "builddate");
                VersionNotes = parser.GetSetting("update", "versionnotes");

                string ver_old = Config.Version;
                string ver_new = Version;

                var version_old = new Version(ver_old);
                var version_new = new Version(ver_new);

                var result = version_old.CompareTo(version_new);
                if (result < 0)
                {
                    Console.WriteLine(CurrentTime + " > ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("New version of the bot is available." + Environment.NewLine + "Version: " + Version + Environment.NewLine + "BuildID: " + BuildID + Environment.NewLine + "Build Date: " + BuildDate + Environment.NewLine + "Version notes: " + VersionNotes);
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
                else
                {
                    Console.WriteLine(CurrentTime + " > ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No new bot updates.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(CurrentTime + " > ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unable to update." + Environment.NewLine + ex);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
        }

        public static void GrabUpdate()
        {
            upd_dwld.DownloadFile(new Uri("https://github.com/DrHacknik/OpenBot/raw/master/Updates/OpenBot.zip"), cd + "\\Temp\\OpenBot.exe");
            WebClient get_fin = new WebClient();
            get_fin.DownloadFile(new Uri("https://github.com/DrHacknik/SimplyU/raw/master/Common/Updates/upd_fin.exe"), cd + "\\Temp\\FinishUpdate.bat");

            Process.Start(cd + "\\Temp\\FinishUpdate.bat");

            Environment.Exit(0);
        }

        public static void Clean()
        {
            if (Directory.Exists(cd + "\\Temp"))
            {
                Directory.Delete(cd + "\\Temp", true);
                return;
            }
        }
    }
}