using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using RyuBot.Data;
using RyuBot.Modules;
using RyuBot.Services;

namespace RyuBot.Services {
    public class SvcCheckspam : ModuleBase<SocketCommandContext> {
        public async Task CheckSpam () {
            //await Context.Channel.GetMessageAsync()
        }
    }
}