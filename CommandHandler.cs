using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace RyuBot
{
    public class CommandHandler : ModuleBase<SocketCommandContext>
    {
        private DiscordSocketClient _client;
        private CommandService _service;
        private string time = DateTime.Now.ToString();

        public CommandHandler(DiscordSocketClient client)
        {
            _client = client;
            _service = new CommandService();
            _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += handlecommandasync;
        }

        private async Task handlecommandasync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;
            int argPos = 0;
            var context = new SocketCommandContext(_client, msg);

            if (msg.HasCharPrefix('!', ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    var messages = await this.Context.Channel.GetMessagesAsync(1).Flatten();
                    await this.Context.Channel.DeleteMessagesAsync(messages);
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(time + ":ERROR: The command requested was invalid; or the incorrect syntax.");
                    await this.Context.Channel.SendMessageAsync(time + ":ERROR: The comman requested was invalid; or was the incorrect syntax.");
                }
            }
        }
    }
}