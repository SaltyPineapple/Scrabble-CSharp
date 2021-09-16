using System;
using System.Collections.Generic;
using System.Text;

namespace Scrabble.Game_Logic {
    
    // Bag ADT
    class TileSet {
        // size is not size of arr
        // it is number of current tiles in bag
        private int SIZE;

        // tiles is bag
        private Tile[] tiles;

        Random rand = new Random();


        public TileSet() {
            SIZE = 0;
            tiles = new Tile[100];

            add(new Tile("A", 1));
            add(new Tile("A", 1));
            add(new Tile("A", 1));
            add(new Tile("A", 1));
            add(new Tile("A", 1));
            add(new Tile("A", 1));
            add(new Tile("A", 1));
            add(new Tile("A", 1));
            add(new Tile("A", 1));
            add(new Tile("B", 3));
            add(new Tile("B", 3));
            add(new Tile("C", 3));
            add(new Tile("C", 3));
            add(new Tile("D", 2));
            add(new Tile("D", 2));
            add(new Tile("D", 2));
            add(new Tile("D", 2));
            add(new Tile("E", 1));
            add(new Tile("E", 1));
            add(new Tile("E", 1));
            add(new Tile("E", 1));
            add(new Tile("E", 1));
            add(new Tile("E", 1));
            add(new Tile("E", 1));
            add(new Tile("E", 1));
            add(new Tile("E", 1));
            add(new Tile("E", 1));
            add(new Tile("E", 1));
            add(new Tile("E", 1));
            add(new Tile("F", 4));
            add(new Tile("F", 4));
            add(new Tile("G", 2));
            add(new Tile("G", 2));
            add(new Tile("G", 2));
            add(new Tile("H", 4));
            add(new Tile("H", 4));
            add(new Tile("I", 1));
            add(new Tile("I", 1));
            add(new Tile("I", 1));
            add(new Tile("I", 1));
            add(new Tile("I", 1));
            add(new Tile("I", 1));
            add(new Tile("I", 1));
            add(new Tile("I", 1));
            add(new Tile("I", 1));
            add(new Tile("J", 8));
            add(new Tile("K", 5));
            add(new Tile("L", 2));
            add(new Tile("L", 2));
            add(new Tile("L", 2));
            add(new Tile("L", 2));
            add(new Tile("M", 3));
            add(new Tile("M", 3));
            add(new Tile("N", 2));
            add(new Tile("N", 2));
            add(new Tile("N", 2));
            add(new Tile("N", 2));
            add(new Tile("N", 2));
            add(new Tile("N", 2));
            add(new Tile("O", 1));
            add(new Tile("O", 1));
            add(new Tile("O", 1));
            add(new Tile("O", 1));
            add(new Tile("O", 1));
            add(new Tile("O", 1));
            add(new Tile("O", 1));
            add(new Tile("O", 1));
            add(new Tile("P", 3));
            add(new Tile("P", 3));
            add(new Tile("Q", 10));
            add(new Tile("R", 1));
            add(new Tile("R", 1));
            add(new Tile("R", 1));
            add(new Tile("R", 1));
            add(new Tile("R", 1));
            add(new Tile("R", 1));
            add(new Tile("S", 1));
            add(new Tile("S", 1));
            add(new Tile("S", 1));
            add(new Tile("S", 1));
            add(new Tile("T", 1));
            add(new Tile("T", 1));
            add(new Tile("T", 1));
            add(new Tile("T", 1));
            add(new Tile("T", 1));
            add(new Tile("T", 1));
            add(new Tile("U", 1));
            add(new Tile("U", 1));
            add(new Tile("U", 1));
            add(new Tile("U", 1));
            add(new Tile("V", 4));
            add(new Tile("V", 4));
            add(new Tile("W", 4));
            add(new Tile("W", 4));
            add(new Tile("X", 8));
            add(new Tile("Y", 4));
            add(new Tile("Y", 4));
            add(new Tile("Z", 10));
            add(new Tile("?", 0));
            add(new Tile("?", 0));
        }

        // methods we need
        // add: adds a new item to the tileset bag
        // remove: removes specified item from the bag
        // grab: removes and returns item from bag, like drawing from a pile
        // isEmpty: returns true if SIZE == 0


        // add
        
        // finds first null index and puts tile there.
        // can be used when initializing and when user switches out tiles
        public bool add(Tile tile) {
            
            for(int x=0; x<SIZE+1; x++) {
                if(tiles[x] == null) {
                    tiles[x] = tile;
                    SIZE++;
                    return true;
                }
            }
            
            
            return false;
        }

        
        // grab

        // like drawing from a pile
        // goes to random index in arr
        // removes and returns that tile

        public Tile grab() {
            int index = rand.Next(SIZE);
            Tile temp = tiles[index];
            shift(index);
            SIZE--;
            return temp;
        }


        // shift

        // shifts all items in array down so that no null values in between
        public void shift(int index) {
            if(index != 99) {
                tiles[index] = tiles[index + 1];
                shift(index + 1);
            }
        }



        public Tile[] GetTiles() {
            return tiles;
        }

        public int getSize() {
            return SIZE;
        }

    }
}
