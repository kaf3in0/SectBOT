using System;
using System.Collections.Generic;
using System.Text;
using Discord.Commands;
using System.Threading.Tasks;

namespace SectBot.Modules {
    class MusicManager : ModuleBase<SocketCommandContext> {
        // play manele, nightcore, rock, 
        // Create random playlists with only that type of songs
        [Command("play")]
        public async Task Play(string genre) {
            // sa cante manele la intamplare NON-STOP

            // TODO:
            // Make it so you can add a new artist to a genre by
            // !add <genre> <youtube link> <artist name>
            // !add manele https://www.youtube.com/user/HITFlorinSalam/videos Florin Salam

            // TODO: Make it so you can also remove artists from genres by indexes from the list

            // Add that artist to the database/config of genres and pick from it when typing that genre
            // Next time it will pick a random yt channel and start playing a song at random from that (maybe check for #music tag if i get garbage)
        }

        // Loop the current playing song
        [Command("loop")]
        public async Task Loop() {

        }
    }
}
