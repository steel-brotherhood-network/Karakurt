using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using System;


namespace Karakurt.Core.Commands
{
   
    public class WebHooks : ModuleBase<SocketCommandContext>

    {
        
        [Command("embend"), Alias("embend"), Summary("злато не")]
        public async Task Hook([Remainder]string Input = "None")
        {
            
            EmbedBuilder Embed = new EmbedBuilder();
            Embed.WithAuthor(Context.User.GetAvatarUrl(),Context.User.Activity.Name);
            Embed.WithColor(40, 200, 150);
            Embed.WithFooter(("/злато /иди"), Context.Guild.Owner.GetAvatarUrl());
            Embed.WithDescription("Приятно проведи у нас время!" + "[**Karakurt v.0.1.4** 2018г.-2019г. by Nodius](https://vk.com/timnazar)");
            Embed.AddField("User input:", Input);
            await Context.User.SendMessageAsync("",false,Embed.Build());
            
        }
       
    }
}