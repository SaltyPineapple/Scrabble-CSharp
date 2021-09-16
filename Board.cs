using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Scrabble.Game_Logic {
    class Board {

        private Cell[,] grid;
        private int SIZE;
        int direction;

        public Board(int size) {
            SIZE = size;
            grid = new Cell[SIZE,SIZE];
            
            for(int row=0; row<SIZE; row++) {
                for(int col=0; col<SIZE; col++) {
                    grid[row, col] = new Cell(row, col);
                }
            }

        }



        // CHANGE

        // maybe set to current until move is solidified,
        // just set to current for now
        // create new method to solidify move
        
        public bool playTile(Tile tile, int row, int col) {
            if(!grid[row,col].IsOccupied && !grid[row, col].IsCurrent) {
                grid[row, col].Tile = tile;
                grid[row, col].IsCurrent = true;
                return true;
            }
            return false;
        }

        public void solidifyPlay(LinkedList mainWord) {
            LinkedList.Node head = new LinkedList.Node();
            head = mainWord.Head;

            while(head.next != null) {
                grid[head.next.row, head.next.col].IsOccupied = true;
                head = head.next;
            }

        }

        // this needs to run every single time a tile is played to check for all valid words
        public List<string> getWords(LinkedList mainWord, int direction) {
            List<string> allWords = new List<string>();
            LinkedList.Node head = mainWord.Head;
            if(direction <= 2) {
                // direction: 1 if vertical
                // if vertical, run vertWord once and horizWord for as many letters
                if (direction == 1) {
                    allWords.Add(vertWord(head.next.row, head.next.col));
                    while(head.next != null) {
                        allWords.Add(horizWord(head.next.row, head.next.col));
                        head = head.next;
                    }
                }
                // not vertical means horizontal
                // run horizontal once and vertical for as many letters
                else {
                    allWords.Add(horizWord(head.next.row, head.next.col));
                    while(head.next != null) {
                        allWords.Add(vertWord(head.next.row, head.next.col));
                        head = head.next;
                    }

                }

            }

            return allWords;
        }

        // go all the way north until it hits a blank space or out of range
        // then go all the way south and create a word out of it
        public string vertWord(int row, int col) {
            
            
            for(int x=row; x>-1; x--) {
                if (!grid[x, col].IsOccupied && !grid[x,col].IsCurrent) {
                    row = x+1;
                    break;
                }
                if(x == 0) {
                    row = 0;
                    break;
                }
            }
            LinkedList word = new LinkedList();
            while (grid[row, col].IsOccupied || grid[row,col].IsCurrent) {
                word.insertOrder(grid[row, col].Tile, row, col);
                row++;
            }

            return word.toWord();
            
        }

        // go all the way west until it hits a blank space or out of range
        // then go all the way east until it hits blank and create word
        public string horizWord(int row, int col) {
            for(int y = col; y>-1; y--) {
                if(!grid[row, y].IsOccupied && !grid[row, y].IsCurrent) {
                    col = y + 1;
                    break;
                }
                if (y == 0) {
                    col = 0;
                    break;
                }
            }

            LinkedList word = new LinkedList();
            while (grid[row, col].IsOccupied || grid[row, col].IsCurrent) {
                word.insertOrder(grid[row, col].Tile, row, col);
                col++;
            }

            return word.toWord();


        }

        public int getDirection(LinkedList mainWord) {
            if (mainWord.Head.next.next == null) {
                direction = 1;
            }
            else {
                LinkedList.Node head = mainWord.Head;

                if(head.next.row == head.next.next.row && head.next.col != head.next.next.col) {
                    direction = 2;
                }
                else if(head.next.col == head.next.next.col && head.next.row != head.next.next.row) {
                    direction = 1;
                }
                else {
                    direction = 3;
                }
            }


            return direction;
        }

        // have to run for each tile
        public bool borders(int row, int col) {
            if (grid[row - 1, col].IsOccupied || grid[row - 1, col].IsCurrent) {
                return true;
            }
            else if (grid[row + 1, col].IsOccupied || grid[row + 1, col].IsCurrent) {
                return true;
            }
            else if (grid[row, col - 1].IsOccupied || grid[row, col - 1].IsCurrent) {
                return true;
            }
            else if (grid[row, col+1].IsOccupied || grid[row, col + 1].IsCurrent) {
                return true;
            }


            return false;
        }


        public void returnTiles(LinkedList mainWord, Player player) {

            LinkedList.Node head = mainWord.Head;
            while (head.next != null) {
                player.draw(head.next.data);
                grid[head.next.row, head.next.col].IsOccupied = false;
                grid[head.next.row, head.next.col].IsCurrent = false;
                head = head.next;
            }

            // todo
        }

        // This is used for TESTING
        public void printBoard() {
            for(int row=0; row<SIZE; row++) {
                for(int col=0; col<SIZE; col++) {
                    if (grid[row, col].IsOccupied || grid[row,col].IsCurrent) {
                        Console.Write($" {grid[row, col].Tile} ");
                    }
                    else {
                        Console.Write(" - ");
                    }
                    
                }
                Console.WriteLine();
            }
        }









    }
}
