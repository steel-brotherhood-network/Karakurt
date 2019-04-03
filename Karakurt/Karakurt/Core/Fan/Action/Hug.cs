using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Karakurt.Core.Fan.Action
{
    class Hug : ModuleBase<SocketCommandContext>
    {
        [Command("hugs"),Summary("обнять")]
        public async Task Hugs()
        {
            //await Context.Channel.DeleteMessageAsync(1);
            await Context.Channel.SendFileAsync(@"D:\Картинки\Схемы\Anime\Gif\hug1.gif");
        }
    }
}
