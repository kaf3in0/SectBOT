using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace SectBot {
    class Config {

        private const string CONFIG_FILE_PATH = "config.json";
        private const string CONFIG_FOLDER_PATH = "Resources";

        public static BotConfig bot;

        static Config() {

            // Create the folder if it doesn't exist
            if (!Directory.Exists(CONFIG_FOLDER_PATH)) {
                Directory.CreateDirectory(CONFIG_FOLDER_PATH);
            }

            // Create the file in the folder if the file doesn't exist in the folder
            if (!File.Exists(CONFIG_FOLDER_PATH + "/" + CONFIG_FILE_PATH)) {
                bot = GetDefaultBotConfig();
                SaveConfig();
            } else {
                // Read the json
                var json = File.ReadAllText(CONFIG_FOLDER_PATH + "/" + CONFIG_FILE_PATH);
                var data = JsonConvert.DeserializeObject<BotConfig>(json);
                // Set the config for the bot
                bot = data;
            }
        }

        public static void MakeNewConfigForServer(int serverId) {
            bot = GetDefaultBotConfig();
            bot.serverId = serverId;
        }

        private static BotConfig GetDefaultBotConfig() {
            // Make a new config 
            BotConfig bot = new BotConfig();
            // Set defaults
            bot.cmdPrefix = "!";
            bot.language = "en";
            bot.DJRoleName = "SECT DJ";
            //bot.teamNames.AddRange(new string[] { "team1", "team2", "team3", "team4" });
            return bot;
        }

        public static void SaveConfig() {
            // Serialize it to json
            string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
            // Write the file to the path
            File.WriteAllText(CONFIG_FOLDER_PATH + "/" + CONFIG_FILE_PATH, json);
        }
    }
    
    // TODO: Make AddTeamName() function
    public struct BotConfig {
        public int serverId;
        public string token;
        public string cmdPrefix;
        public string DJRoleName;
        public string language;
        public string[] teamNames;
    }

}
