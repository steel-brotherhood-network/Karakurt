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
    public class UserMessages : ModuleBase<SocketCommandContext>
    {
        [Command("иди"), Alias("helloworld", "world"), Summary("Hello world command")]
        public async Task Goliut()
        {
            await Context.Channel.SendMessageAsync("Загляни в личку");
            await Context.User.SendMessageAsync("Спать пошёл нахой,а то до утра не до живёшь!!!");
            return;
        }
    }
}