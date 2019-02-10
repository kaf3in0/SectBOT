using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;


namespace SectBot.Modules {
    class ConfigManager : ModuleBase<SocketCommandContext> {
        [Command("set_dj_role_name")]
        public async Task SetDJRoleName(string DJName) {
            Config.bot.DJRoleName = DJName;
            Config.SaveConfig();
        }

        [Command("set_prefix")]
        public async Task SetBotPrefix(string prefix) {
            Config.bot.cmdPrefix = prefix;
            Config.SaveConfig();
        }

        [Command("set_lanugage")]
        public async Task SetBotLanguage(string langPrefix) {
            Config.bot.language = langPrefix;
            Config.SaveConfig();
        }

        [Command("clear_team_name")]
        public async Task ClearTeamNames([Remainder] string teams) {
           // Config.bot.teamNames = new List<string>();
            Config.SaveConfig();
        }


        [Command("add_team_name")]
        public async Task AddTeamName([Remainder] string teams) {
            //Config.bot.teamNames.Add(teams);
            Config.SaveConfig();
        }


        [Command("get_config")]
        public async Task GetConfig() {
            string str = $"Prefix: {Config.bot.cmdPrefix}\n" +
                    $"Dj Role Name: {Config.bot.DJRoleName}\n" +
                    $"Language: {Config.bot.language}";
            await Context.Channel.SendMessageAsync(str);
        }
    }
}

