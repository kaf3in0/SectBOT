using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace SectBot {
    class CommandHandler {

        // Discord properties
        DiscordSocketClient _client;
        CommandService _service;

        public async Task InitAsync(DiscordSocketClient client) {
            _client = client;
            _service = new CommandService();
            
            // (?) I think this looks in the project for all the commands
            await _service.AddModulesAsync(Assembly.GetEntryAssembly(), null);

            // Set handler for messages recieved
            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage arg) {
            // Check if arg is a msg
            var msg = arg as SocketUserMessage;
            if (msg == null) return;

            // Get the context of the msg
            var ctx = new SocketCommandContext(_client, msg);
            int argPos = 0;

            // If the msg has a prefix or a mention to the bot handle the command
            if (msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos)
                || msg.HasMentionPrefix(_client.CurrentUser, ref argPos)) {

                // IDK
                var result = await _service.ExecuteAsync(ctx, argPos, null);

                // Log what happend when the command is valid but it failed
                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand) {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}
