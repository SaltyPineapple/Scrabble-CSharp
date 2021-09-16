
using System;

namespace Scrabble.Game_Logic {
    class Program {
        static void Main(string[] args) {

            Game game = new Game();
            int turn = 0;
            
            while (game.tileSet.getSize() > 0) {
                game.board.printBoard();

                Player currentPlayer;
                if(turn %2 == 0) {
                    currentPlayer = game.player1;
                    Console.Write("Player 1: ");
                }
                else {
                    currentPlayer = game.player2;
                    Console.Write("Player 2: ");
                }

                
                
                Console.Write(currentPlayer.printHand());

                Console.WriteLine();
                Console.WriteLine(game.tileSet.getSize());
                Console.WriteLine();
                Console.WriteLine();


                Console.WriteLine("Choose Action:");
                Console.WriteLine("1: Play Tile");
                if (game.isValidPlay) {
                    Console.WriteLine("2: Complete Turn");
                    Console.WriteLine("3: Return Current Tiles");
                }
                else {
                    Console.WriteLine("3: Return Current Tiles");
                }
                string consoleChoice = Console.ReadLine();

                if(consoleChoice == "1") {
                    string indexStr;
                    Console.Write("Enter Tile Index: ");
                    indexStr = Console.ReadLine();
                    int index = Convert.ToInt32(indexStr);
                    index -= 1;

                    string rowStr;
                    Console.Write("Enter Row: ");
                    rowStr = Console.ReadLine();
                    int row = Convert.ToInt32(rowStr);

                    string colStr;
                    Console.Write("Enter Col: ");
                    colStr = Console.ReadLine();
                    int col = Convert.ToInt32(colStr);

                    /**
                     * LOGIC FLOW
                     * Space picked
                     * Check if it is occupied
                     * place the tile
                     * 
                     * in order to determine if all plays are valid
                     * 3 factors
                     *  1. all tiles in a straight line
                     *  2. are all tiles bordering other tiles,
                     *      and at least one non-current tile
                     *  3. are all words valid
                     *   
                     * 
                     * 
                     */


                    // board.play checks if cell is not occupied
                    if (game.playTile(currentPlayer, index, row, col)) {
                        game.validPlay();

                    }
                }
                else if(consoleChoice == "2") {



                    // this will be different


                    // since words are checked every time if they are valid
                    // this option should only be available if all words are valid
                    // have bool that this checks to see if this option is valid
                    game.board.solidifyPlay(game.mainWord);
                    game.mainWord = new LinkedList();
                    currentPlayer.refillHand(game.tileSet);
                    turn++;
                    
                }
                else if (consoleChoice == "3") {
                    // TODO run return tile algorithm
                    game.board.returnTiles(game.mainWord, currentPlayer);
                    game.mainWord = new LinkedList();
                }
                else {
                    Console.WriteLine("That was not an option");
                }


                /**
                 *  create arraylist of words played
                 *  (will need to create the getAllWords())
                 *  run all words through the word processor
                 *      if any are false, then play is not valid
                 *      do NOT allow play button
                 * 
                 */



               





            }

            




        }
    }
}
