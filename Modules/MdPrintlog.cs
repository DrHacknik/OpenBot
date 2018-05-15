//using Discord;
//using Discord.Commands;
//using Discord.WebSocket;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace RyuBot.Modules
//{
//    public class MdPrintlog : ModuleBase<SocketCommandContext>
//    {
//        private DiscordSocketClient _client;
//        private string cd = System.IO.Directory.GetCurrentDirectory();
//        private string time = DateTime.Now.ToString();


//        [Command("Printlog")]
//        [RequireUserPermission(GuildPermission.ManageMessages)]
//        public async Task Printlog(LogMessage msg)
//        {
//            _client = new DiscordSocketClient(new DiscordSocketConfig
//            {
//                LogLevel = LogSeverity.Verbose
//            });
//            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
//            await this.Context.Channel.DeleteMessagesAsync(messages);
//            Console.BackgroundColor = ConsoleColor.DarkYellow;
//            Console.WriteLine(time + ":: Command Request: !printlog; " + "ID <" + Context.User.Id.ToString() + "> " +
//                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">");

//            await this.Context.Channel.SendMessageAsync("**Log start:```\r\n" + msg.Message + "```");
//        }
//    }
//}
