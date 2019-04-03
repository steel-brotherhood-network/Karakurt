using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace Karakurt.Core.Commands
{
    public class ChannelMessages : ModuleBase<SocketCommandContext>
    {
        [Command("злато"), Alias("злато"), Summary("злато не трогать")]
        public async Task Chang()
        {
            await Context.Channel.SendMessageAsync("Злато не трогать");
        }

        [Command("помоги Серёге")]
        public async Task Ping()
        {
            await ReplyAsync("Сори,но его бота я не потяну.Пусть он сам попробует как ты)");
        }

        [Command("bump"), Alias("like"), Summary("bump and like")]
        public async Task Bump()
        {
            await Context.Channel.SendMessageAsync("!bump");
            await Context.Channel.SendMessageAsync("=like");
        }

        [Command("hug"), Summary("обнять")]
        public async Task Hugs()
        {
            await Context.Channel.DeleteMessageAsync(1);
            await Context.Channel.SendMessageAsync("!bump");
            await Context.Channel.SendFileAsync(@"D:\Картинки\Схемы\Anime\Gif\hug1.gif");
        }
    }
}
