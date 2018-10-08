using System;

namespace OpenBot
{
    public static class Config
    {
        public static ulong BotChannelId = 0;
        public static string ApiFile = "ApiKey";
        public static string StatusFile = "OpenStatus";
        public static string GameStatus;
        public static string LewdDir;
        public static string BotDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\OpenBot"; //Could be "%appdata%/BotName/" if on Windows or "/home/username/.config/BotName/" if on Linux.
        public static string BotName = "OpenBot-beta";
        public static string Version = "0.2.5.3";
        public static string BuildDate = "10/8/2018: 4:53pm EST";
        public static string OS = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
        public static bool LogWithoutStamp;
    }
}