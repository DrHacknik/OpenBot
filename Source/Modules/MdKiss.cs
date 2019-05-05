using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace OpenBot.Modules {
    public class MdKiss : ModuleBase<SocketCommandContext> {
        private string time = DateTime.Now.ToString ();
        private string[] Kisses;

        [Command ("kiss")]
        public async Task Kissed (SocketGuildUser MentionedUser) {
            Random rand;

            rand = new Random ();
            Kisses = new string[] {
                "https://thumbs.gfycat.com/BrownAmusingBeardeddragon-size_restricted.gif",
                "https://media.giphy.com/media/4gVv2ERASSYYo/giphy.gif",
                "https://data.whicdn.com/images/144335846/original.gif",
                "https://media1.tenor.com/images/5654c7b35e067553e99bb996535c0a75/tenor.gif?itemid=10358833",
                "https://i.imgur.com/eisk88U.gif",
                "https://i.imgur.com/sGVgr74.gif",
                "https://gifer.com/i/2Lmc.gif",
                "https://i.pinimg.com/originals/6e/2f/e9/6e2fe9073f4e6aa4080e2e9ab5e3f790.gif",
                "https://78.media.tumblr.com/61519c408b9984dcc807bdefa15f5a18/tumblr_o1henjRfTe1uapp8co1_400.gif",
                "https://media.giphy.com/media/12VXIxKaIEarL2/giphy.gif",
                "https://steamusercontent-a.akamaihd.net/ugc/911282063159454859/8761502294077A13308E97EEE5B3BF92145135F2/",
                "https://media.giphy.com/media/gbm1PS3LkOngQ/source.gif",
                "https://acegif.com/wp-content/uploads/anime-kissin-16.gif",
                "https://avatars.mds.yandex.net/get-pdb/245485/c0191542-929f-45d5-a4f8-15bb6c72fc88/orig",
                "https://steamusercontent-a.akamaihd.net/ugc/920295600084634898/21C58086A7C9F7B3DAA5BF0A4A406F62E4E888E0/",
                "https://steamusercontent-a.akamaihd.net/ugc/912421173220295869/79ECB970D5DCCB469D5871B8C993EC115B59BD5A/",
                "http://gifimage.net/wp-content/uploads/2017/09/anime-gif-kiss-12.gif",
                "https://media1.tenor.com/images/8d702471e66ada086d4b86d64d7d2199/tenor.gif?itemid=5604562",
                "https://i.pinimg.com/originals/83/4c/23/834c235020095630d8ea34a01c502b94.gif",
                "https://media1.tenor.com/images/bc5e143ab33084961904240f431ca0b1/tenor.gif?itemid=9838409",
                "http://33.media.tumblr.com/a8b3e9f706d5a509b09000fd736b9467/tumblr_n3qrm4N3S31siyfwio1_500.gif",
                "https://s9.favim.com/orig/131205/anime-couple-cute-kawaii-Favim.com-1117795.gif",
                "https://steamusercontent-a.akamaihd.net/ugc/916913039246336282/9B06FF752BABD5FE3DF14DBC84F03FD16BB7E559/",
                "https://i.imgur.com/PKOsDVW.gif",
                "https://thumbs.gfycat.com/FoolhardyThirdIbis-size_restricted.gif"
            };

            await Context.Message.DeleteAsync ();
            int randomIndex = rand.Next (Kisses.Length);
            string KissPost = Kisses[randomIndex];

            EmbedBuilder Embed = new EmbedBuilder ();
            Embed.WithTitle (MentionedUser.Username + " you have been kissed by " + Context.User.Username);
            Embed.WithColor (new Color (236, 183, 4));
            Embed.WithImageUrl (KissPost);
            Embed.WithDescription ("UwU Kiss~");
            Embed.WithTimestamp (DateTime.UtcNow);
            await Context.Channel.SendMessageAsync (String.Empty, false, Embed.Build ());

            string Message = "Command **!kiss** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">";

            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
        }
    }
}