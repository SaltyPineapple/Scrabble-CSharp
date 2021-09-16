using System;
using System.Collections.Generic;
using System.Text;

namespace Scrabble.Game_Logic {
    class Cell {

        public int Row { get; set; }
        public int Col { get; set; }
        public Tile Tile { get; set; }
        public bool IsOccupied { get; set; }
        public int Multiplier { get; set; }

        // 1 for letter, 2 for word
        public int MultType { get; set; }

        public bool IsCurrent { get; set; }


        public Cell(int row, int col) {
            this.Row = row;
            this.Col = col;
            Tile = null;
            IsOccupied = false;
            IsCurrent = false;
        }
    }
}
