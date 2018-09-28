using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RyuBot.Services {
    public static class SvcLog {
        public static string Logged;
        private static string cd = Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "/RyuBot";
        private static string CurrentTime = DateTime.Now.ToString ();

        public static void DumpLog () {
            if (!Directory.Exists (cd + "/Logs")) {
                Directory.CreateDirectory (cd + "/Logs");
            }

            File.WriteAllText (cd + "/Logs/LOG_DUMP_" + DateTime.Now.ToString ("M_d_yyyy") + ".log", Logged);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine (CurrentTime + " :: Dumped log: " + cd + "/LOG_DUMP_" + DateTime.Now.ToString ("M_d_yyyy") + ".log");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }
    }
}