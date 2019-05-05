using System;
using System.IO;

namespace OpenBot.Services {
    public static class SvcLog {
        public static string Logged;
        private static string CurrentTime = DateTime.Now.ToString ();

        public static void DumpLog () {
            if (!Directory.Exists (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "\\OpenBot\\Canary\\Logs")) {
                Directory.CreateDirectory (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "\\OpenBot\\Canary\\Logs");
            }
            if (!Directory.Exists (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "\\OpenBot\\Logs")) {
                Directory.CreateDirectory (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "\\OpenBot\\Logs");
            }

            if (Config.Branch == "Master") {
                File.WriteAllText ((Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "\\OpenBot\\Logs") + "\\LOG_DUMP_" + DateTime.Now.ToString ("M_d_yyyy") + ".log", Logged);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine (CurrentTime + " :: Dumped log: " + Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "\\OpenBot\\Logs" + "\\LOG_DUMP_" + DateTime.Now.ToString ("M_d_yyyy") + ".log");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (Config.Branch == "Canary") {
                File.WriteAllText (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "\\OpenBot\\Canary\\Logs" + "\\LOG_DUMP_" + DateTime.Now.ToString ("M_d_yyyy") + ".log", Logged);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine (CurrentTime + " :: Dumped log: " + Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "\\OpenBot\\Canary\\Logs" + "\\LOG_DUMP_" + DateTime.Now.ToString ("M_d_yyyy") + ".log");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return;
        }
    }
}