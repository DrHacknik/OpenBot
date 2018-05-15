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
        public async Task DoThatInput([Remainder]string message)
        {
            var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
            await this.Context.Channel.DeleteMessagesAsync(messages);
            //var embed = new EmbedBuilder();
            //embed.WithTitle("Inputed message");
            //embed.WithDescription(message);
            //embed.WithColor(new Color(0, 255, 0));

            await Context.Channel.SendMessageAsync(message);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(time + ":: Command Request: !input; " + "ID <" + Context.User.Id.ToString() + "> " +
                "\r\nUsername: <" + Context.User.Username.ToString() + ">" + " Channel ID: <" + Context.Channel.Id + ">" + " Value: " + message);
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
 