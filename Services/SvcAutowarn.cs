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
    [RequireUserPermission (GuildPermission.ManageMessages)]
    public class SvcAutowarn : ModuleBase<SocketCommandContext> {
        private string user;
        private string time = DateTime.Now.ToString ();

        public void GetCount () { }

        public void SetCount () { }
    }
}