//using Discord.Commands;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using System.Threading.Tasks;
//using System.Diagnostics;
//using Discord;

//namespace RyuBot
//{
//    public class Status : ModuleBase<SocketCommandContext>
//    {
//        private string time = DateTime.Now.TimeOfDay.ToString();
//        private string cd = System.IO.Directory.GetCurrentDirectory();

//        [Command("Status")]
//        public async Task StatusMessage(Program _client)
//        {
//            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
//            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
//            var CurProc = Process.GetCurrentProcess();
//            var CurMem = Process.WorkingSet64("");
//            var CurCPU = Process.TotalProcessorTime("");
//            foreach (var aProc in Process.GetProcesses()) ;
//        }

//        private string message =
//        "**RAM Usage:** " + CurMem.ToString + Environment.NewLine +
//        "**CPU Usage:** " + CurCPU.ToString + Environment.NewLine +
//        "**Process Information:** " + CurProc.ToString + Environment.NewLine +
//        "**Current Time:** " + time + Environment.NewLine +
//        "**Bot Version: 0.2.0**" + Environment.NewLine;

//        //await Helper.LoggingAsync(private new LogMessage(LogSeverity.Verbose, "Bot", Message));

//        //    await Context.Channel.SendMessageAsync(Message);
//    }
//}