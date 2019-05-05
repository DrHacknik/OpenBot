using Discord;
using Discord.Commands;
using System;

namespace OpenBot.Services
{
    [RequireUserPermission(GuildPermission.ManageMessages)]
    public class SvcAutowarn : ModuleBase<SocketCommandContext>
    {
        private string user;
        private string time = DateTime.Now.ToString();

        public void GetCount()
        {
        }

        public void SetCount()
        {
        }
    }
}