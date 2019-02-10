using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;


namespace SectBot.Modules {
    public class Misc : ModuleBase<SocketCommandContext> {
        [Command("help")]
        public async Task Help(string message) {
            await Context.Channel.SendMessageAsync("Hello");
        }

        [Command("echo")]
        public async Task Echo([Remainder]string message) {
            var embedBuilder = new EmbedBuilder();
            embedBuilder.WithTitle($"{Context.User.Username} spune");
            embedBuilder.WithDescription(message);
            embedBuilder.WithColor(new Color(0, 255, 0));
            Embed embed = embedBuilder.Build();

            await Context.Channel.SendMessageAsync("", false, embed);
        }

        [Command("pick")]
        public async Task Pick([Remainder]string message) {

            string[] options = message.Split(new char[] { '|', ';', '/' }, StringSplitOptions.RemoveEmptyEntries);
            Random r = new Random();
            string selection = options[r.Next(0, options.Length)];


            var embedBuilder = new EmbedBuilder();
            embedBuilder.WithTitle($"Choice");
            embedBuilder.WithDescription(selection);
            embedBuilder.WithColor(new Color(0, 255, 0));
            Embed embed = embedBuilder.Build();

            await Context.Channel.SendMessageAsync("", false, embed);
        }


        [Command("secret")]
        public async Task Secret(string arg = "") {
            // Check if user has the role that grants him permission
            if (!IsUserSectDJ((SocketGuildUser)Context.User)) {
                await Context.Channel.SendMessageAsync(Utils.GetFormattedAlert(
                        "DJ_PERMISSION_&DJROLENAME", Config.bot.DJRoleName));
                return;
            }
            // Get user DM
            var dmChannle = await Context.User.GetOrCreateDMChannelAsync();
            await dmChannle.SendMessageAsync("esti gay");
        }

        /*
        public bool IsUserSectDJDUMB(SocketGuildUser user) {
            string targetRoleName = "SECT DJ";
            var result = from r in user.Guild.Roles
                         where r.Name == targetRoleName
                         select r.Id;
            ulong roleID = result.FirstOrDefault();
            // If the role doesnt exist in the server
            if (roleID == 0) return false;
            var targetRole = user.Guild.GetRole(roleID);
            return user.Roles.Contains(targetRole);
        }
        */



        public bool IsUserSectDJ(SocketGuildUser user) {
            foreach (var role in user.Roles) {
                if (role.Name == Config.bot.DJRoleName) return true;
            }
            return false;
        }


    }
}
