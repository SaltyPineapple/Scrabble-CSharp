using System;
using System.Collections.Generic;
using System.Text;

namespace Scrabble.Game_Logic {
    class Game {
        public TileSet tileSet;
        public Player player1;
        public Player player2;
        public Board board;
        public WordProcessor wp;
        public LinkedList mainWord;


        public bool isValidPlay = false;

        public Game() {
            tileSet = new TileSet();
            player1 = new Player();
            player1.refillHand(tileSet);
            player2 = new Player();
            player2.refillHand(tileSet);
            board = new Board(15);
            wp = new WordProcessor();
            mainWord = new LinkedList();
        }


        public bool playTile(Player player, int index, int row, int col) {
            // checks if cell is unoccupied
            if(board.playTile(player.getTile(index), row, col)) {
                // inserts into the main word
                mainWord.insertOrder(player.getTile(index), row, col);
                // removes from players hand
                player.play(index);
                return true;
            }
            return false;
        }

        public void validPlay() {
            isValidPlay = true;

            // this section checks for valid words played
            foreach (string word in board.getWords(mainWord, board.getDirection(mainWord))) {
                if (word.Length > 1) {
                    if (!wp.isWordAsync(word)) {
                        Console.WriteLine("Invalid: " + word);
                        isValidPlay = false;
                    }

                }
            }

            // this section checks for valid borders on tiles
            LinkedList.Node head = new LinkedList.Node();
            head = mainWord.Head;
            while (head.next != null) {
                if (!board.borders(head.next.row, head.next.col)) {
                    isValidPlay = false;
                }
                head = head.next;
            }
        }




    }
}
