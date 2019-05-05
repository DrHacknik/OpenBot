using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace OpenBot.Modules {
    public class MdInsults : ModuleBase<SocketCommandContext> {
        private string time = DateTime.Now.ToString ();
        private string[] Insults;

        [Command ("insult")]
        public async Task SendInsult (SocketGuildUser MentionedUser) {
            Random rand;

            rand = new Random ();
            Insults = new string[] {
                "Roses are red, Violets are blue. I am gay, and so are you.",
                "Hey, you have something on your chin... no, the 3rd one down.",
                "You're the reason the gene pool needs a lifeguard.",
                "If I had a face like yours, I'd sue my parents. On second thought, I'd sue them either way.",
                "Your only chance of getting laid is to crawl up a chicken's butt and wait.",
                "Some day you'll go far... and I hope you stay there.",
                "Aha! I see the fuck-up fairy has visited us again!",
                "You must have been born on a highway cos' that's where most accidents happen.",
                "If laughter is the best medicine, your face must be curing the world!",
                "I'm glad to see you're not letting your education get in the way of your ignorance.",
                "Is your ass jealous of the amount of shit that just came out of your mouth?",
                "So, a thought crossed your mind? Must have been a long and lonely journey.",
                "If I wanted to kill myself, I'd climb your ego and jump to your IQ.",
                "I'd agree with you but then we'd both be wrong.",
                "When I see your face there's not a thing I would change... Except the direction I was walking in.",
                "If I had a dollar for every time you said something smart, I'd be broke.",
                "When you were born the doctor threw you out the window and the window threw you back.",
                "I love what you've done with your hair! How do you get it to come out of the nostrils like that?"
            };

            await Context.Message.DeleteAsync ();
            int randomIndex = rand.Next (Insults.Length);
            string InsultPost = Insults[randomIndex];

            EmbedBuilder Embed = new EmbedBuilder ();
            Embed.WithTitle (MentionedUser.Username + ", enjoy your insult >:3");
            Embed.WithColor (new Color (236, 183, 4));
            Embed.WithDescription ("'" + InsultPost + "'");
            Embed.WithTimestamp (DateTime.UtcNow);
            await Context.Channel.SendMessageAsync (String.Empty, false, Embed.Build ());

            string Message = "Command **!insult** requested by " + Context.User.Username + Environment.NewLine +
                "in channel <#" + Context.Channel.Id + ">" + " to " + MentionedUser.Username;

            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Module", Message));
        }
    }
}