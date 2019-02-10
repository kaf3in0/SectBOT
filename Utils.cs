using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace SectBot {

    // Used for a lot of static methods
    class Utils {

        private static Dictionary<string, string> alerts;

        static Utils() {
            // Read the alerts
            string json = File.ReadAllText($"SystemLanguages/{Config.bot.language}_alerts.json");
            // Deserialize = Converting json to data 
            // Serialize = Converting data to json 
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            alerts = data.ToObject<Dictionary<string, string>>();
        }

        public static string GetAlert(string key) {
            // If there are alerts with the specified key return it
            if (alerts.ContainsKey(key)) return alerts[key];
            return "";
        }

        public static string GetFormattedAlert(string key, params object[] parameters) {
            // If there are alerts with the specified key return it
            if (alerts.ContainsKey(key)) {
                return String.Format(alerts[key], parameters);
            }
            return "";
        }
    }
}
