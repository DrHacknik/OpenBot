using System;

namespace OpenBot
{
    public static class Config
    {
        public static ulong BotChannelId = 0;
        public static string ApiKey;
        public static string LewdDir;
        public static string BotDir; //Could be "%appdata%/BotName/" if on Windows or "/home/username/.config/BotName/" if on Linux.
        public static string Branch;
        public static string BotName = "OpenBot-beta";
        public static string Version = "0.2.5.5";
        public static string BuildDate = "10/17/2018: 6:19pm EST";
        public static string OS = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
        public static string LogWithoutStamp;
    }
}