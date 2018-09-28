namespace RyuBot
{
    public static class Config
    {
        public static ulong BotChannelId = 0;
        public static string ApiFile = "ApiKey";
        public static string StatusFile = "OpenStatus";
        public static string GameStatus;
        public static string Version = "0.2.5.1";
        public static string VersionSlim = "0_2_5_1";
        public static string BuildDate = "9/28/2018: 5:44pm EST";
        public static string BuildDateSlim = "9_28_2018_5_44_pm_EST";
        public static string OS = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
        public static bool LogWithoutStamp;
    }
}