using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
namespace SectBot {
    class Program {

        DiscordSocketClient _cleint;
        CommandHandler _handler;

        // Make main run async
        static void Main(string[] args)
          => new Program().StartAsync().GetAwaiter().GetResult();
        

        public async Task StartAsync() {
            //Console.WriteLine(Utils.GetFormattedAlert("GREET_&NAME", "Edward"));
            //Console.ReadLine();
     
            // Configure client settings
            _cleint = new DiscordSocketClient(new DiscordSocketConfig {
                LogLevel = LogSeverity.Verbose,
            });
            _cleint.Log += Log;
            await _cleint.LoginAsync(TokenType.Bot, Config.bot.token);

            // TODO: I think here we init the configs
            await _cleint.StartAsync();


            _handler = new CommandHandler();
            await _handler.InitAsync(_cleint);
            await Task.Delay(-1);
            Console.WriteLine(Utils.GetAlert("TEST"));
            Console.WriteLine(Config.bot.cmdPrefix);
        }

        private async Task Log(LogMessage msg) {
            Console.WriteLine(msg);
        }

        // TODO: To make this work with multiple servers the bot will have to 
        // Set the config server-id when initing the BOT
        // If the server-id doesnt exist already create it
        // Myabe as well when its added to a server ?
    }
}
