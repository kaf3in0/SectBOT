using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using System.Threading.Tasks;

namespace SectBot.Modules {
    class TeamManager : ModuleBase<SocketCommandContext> {

        // Create teams for competitive games
        [Command("team")]
        public async Task Team(int size, int teamNumber = 2) {
            // Get the voice channel that the user who made the command is currently in 
            // (?) Check for permission
            // Get all the users in that channel
            // Shuffle them 
            // Split them into teams
            // Get the team names from config, if not set: use defaults (team1, team2, team3)
            // Check if the channels already exist, if not: create them
            // Print "prepare" message
            // Move users to their team-channels


            // xd Using lol api save mathces to DB and make stats, also check when game is over and move all players back to the previous voice chat
        }
    }
}
