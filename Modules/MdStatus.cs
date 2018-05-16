using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; 

namespace RyuBot
{
   public class Status : ModuleBase<SocketCommandContext>
   {
       string time = DateTime.Now.ToString();
       string cd = System.IO.Directory.GetCurrentDirectory();
       [Command("Status")]
       public async Task StatusMessage(Program _client)
       {
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            var CurProc = Process.GetCurrentProcess();
            var CurMem = proc.WorkingSet64;
            var CurCPU = proc.TotalProcessorTime;
            foreach (var aProc in Process.GetProcesses())

            sting message = 
            "**RAM Usage:** " + CurMem.ToString + Environment.NewLine + 
            "**CPU Usage:** " + CurCPU.ToString + Environment.NewLine + 
            "**Process Usage:** " + CurProc.ToString + Environment.NewLine + 
            "**Current Time:** " + time + Environment.NewLine + 
            "**Bot Version: 0.2.0**" + Environment.NewLine; 
            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Bot", Message));
            await Context.Channel.SendMessageAsync(Message);
       }
   }
}