using System;
using System.Collections.Generic;
using System.Text;

namespace Scrabble.Game_Logic {
    class Tile {

        public string Letter {get; set; }
        public int Score {get; set; }

        public Tile(string letter, int score) {
            this.Letter = letter;
            this.Score = score;
        }

        public override string ToString() {
            return Letter;
        }
    }
}
