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

namespace Karakurt
{
    class Program
    {
        private const string Str = "a!";
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _service;

        private static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task RunBotAsync()
        {
            //string JSON = "";
            //string SettingsLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Replace(@"bin\Debug\netcoreapp2.1", @"Data\Settings.json");
            //using (var Stream = new FileStream(SettingsLocation, FileMode.Open, FileAccess.Read))
            //using (var ReadSettings = new StreamReader(Stream))
            //{
            //    JSON = ReadSettings.ReadToEnd();
            //}

            //Setting Settings = JsonConvert.DeserializeObject<Setting>(JSON);
            //ESettings.Banned = Settings.banned;
            //ESettings.Log = Settings.log;
            //ESettings.Owner = Settings.owner;
            //ESettings.Token = Settings.token;
            //ESettings.Version = Settings.version;
            
            

            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel=LogSeverity.Debug
            });

            _commands = new CommandService(new CommandServiceConfig
            {
                CaseSensitiveCommands = true,
                DefaultRunMode = RunMode.Async,
                LogLevel = LogSeverity.Debug
            });

            _client.MessageReceived += _client_MessageReceived;
            var assembly = Assembly.GetCallingAssembly(); 

            _service = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            string botToken = "NTE2NjkyMjUyODE1MjYxNzI4.D0z0sw.ngmj_n8KAu2SIPF7u6f-jmMb8Gk";

            //event subscriptions
            _client.Ready += _client_Ready;
            _client.Log += Log;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _service);
            //string botToken = "NTUwMTYzMDE0NjI4ODAyNTkw.D3Qpdg.9cBOHlDg5BBgJSl2qYHn49QxoE4";

            await _client.LoginAsync(TokenType.Bot, botToken);
            await _client.StartAsync();

            await Task.Delay(-1);
        }
        
        private async Task _client_Ready()
        {
            await _client.SetGameAsync("Server:Byduke Town", "", ActivityType.Watching);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);

            return Task.CompletedTask;
        }

        private async Task _client_MessageReceived(SocketMessage MessageParam)
        {
            var Message = MessageParam as SocketUserMessage;
            var Context = new SocketCommandContext(_client, Message);

            if (Context.Message == null || Context.Message.Content == "") return;
            if (Context.User.IsBot) return;

            int ArgPos = 0;
            if (!(Message.HasStringPrefix("/", ref ArgPos) || Message.HasMentionPrefix(_client.CurrentUser, ref ArgPos))) return;

            var Result = await _commands.ExecuteAsync(Context,ArgPos,_service);
            if (!Result.IsSuccess)
                Console.WriteLine($"{DateTime.Now} at Commands] Something went wrong with executing a command. Text: {Context.Message.Content} | Error: {Result.ErrorReason}");
            Console.ReadKey();
        }
    }
}