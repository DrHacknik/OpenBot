using Discord;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace RyuBot.Modules
{
    public class MdInput : ModuleBase<SocketCommandContext>
    {
        private string cd = System.IO.Directory.GetCurrentDirectory();
        private string time = DateTime.Now.ToString();

        [Command("Input")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task DoThatInput([Remainder]string IMessage)
        {
            var ReturnMsg = await Context.Channel.GetMessagesAsync(1).Flatten();
            await Context.Channel.DeleteMessagesAsync(ReturnMsg);
            //var embed = new EmbedBuilder();
            //embed.WithTitle("Inputed message");
            //embed.WithDescription(message);
            //embed.WithColor(new Color(0, 255, 0))
            string Message = "Command **!input** requested by <@" + Context.Message.Author.Id + Environment.NewLine +
                             "in channel <#" + Context.Channel.Id + ">";
            await Context.Channel.SendMessageAsync(IMessage);
            await Helper.LoggingAsync(new LogMessage(LogSeverity.Verbose, "Module", Message));
            await Context.Channel.SendMessageAsync(Message);
        }
    

        /*        private SocketGuild GetSelectedServer(IEnumerable<SocketGuild> servers)
        {
            var socketServers = servers.ToList();
            var MaxIndex = servers.Count() -1;
            for (var i = 0; i <= MaxIndex; i++)
            {
                Console.WriteLine($"{i} - {socketServers[i].Name}");
            }

            var selectedIndex = -1;
            while(selectedIndex < 0 || selectedIndex > MaxIndex)
            {
               var success = int.TryParse(Console.ReadLine().Trim(), out selectedIndex);
                if (!success) Console.WriteLine("Sorry, that was an invalid index.");
                //if (selectedIndex < 0 || selectedIndex > MaxIndex) Console.WriteLine("");
                //{

                //}
            }
            return socketServers[selectedIndex];
        }

        private SocketTextChannel GetSelectedChannel(IEnumerable<SocketTextChannel> channels)
        {
            var textChannels = channels.ToList();
            var MaxIndex = channels.Count() - 1;
            for (var i = 0; i <= MaxIndex; i++)
            {
                Console.WriteLine($"{i} - {textChannels[i].Name}");
            }

            var selectedIndex = -1;
            while (selectedIndex < 0 || selectedIndex > MaxIndex)
            {
                var success = int.TryParse(Console.ReadLine().Trim(), out selectedIndex);
                if (!success) Console.WriteLine("Sorry, that was an invalid index.");
                //if (selectedIndex < 0 || selectedIndex > MaxIndex) Console.WriteLine("");
                //{

                //}
            }
            return textChannels[selectedIndex];
        }*/
    }
}
 