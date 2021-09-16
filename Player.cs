using System;
using System.Collections.Generic;
using System.Text;

namespace Scrabble.Game_Logic {
    class Player {

        private int Score { get; set; }
        private Tile[] Hand { get; set; }


        public Player() {
            Score = 0;
            Hand = new Tile[7];
        }

        public bool draw(Tile tile) {
            for(int x=0; x<Hand.Length; x++) {
                if(Hand[x] == null) {
                    Hand[x] = tile;
                    return true;
                }
            }
            return false;
        }

        // this is what was called after player ended turn to re draw all tiles
        public void refillHand(TileSet set) {
            if (draw(set.grab())) {
                refillHand(set);
            }
        }


        // finds spot in hand of selected tile
        // removes from hand
        public void play(int index) {
            Hand[index] = null;
        }


        // console testing purposes

        public Tile getTile(int index) {
            return Hand[index];
        }


        public override string ToString() {
            return printHand();
        }


        public string printHand() {
            string s = "";

            for(int x=0; x< Hand.Length; x++){
                s += $"{Hand[x]}, ";
            }

            return s;
        }




    }
}
