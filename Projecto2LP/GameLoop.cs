using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    /// <summary>
    /// class gameLoop.
    /// </summary>
    class GameLoop
    {
        /// <summary>
        /// Method Play.
        /// </summary>
        public void Play()
        {
            ///Instanciate board.
            Board board = new Board();
            ///Instanciate player.
            Player p = new Player();
            ///Instanciate exit.
            Exit e = new Exit();
            ///Instanciate render.
            Render r = new Render();
            ///variable to enable movement of the player.
            bool enableMov;
            ///variable to quit from the game to the menu.
            bool quit = false;
            ///variable to count each turn.
            int turn = 0;
            ///variable to count each level.
            int level = 1;
            ///variable to end the game.
            bool end = false;

            ///Show the menu until the Player choose the quit option.
            do
            {
                ///Clear the window terminal.
                Console.Clear();
                ///Show the menu and a message to the Player.
                r.ChosePlayerAction(1);
                ///Get the input option chosed by the player.
                int option = Convert.ToInt32(Console.ReadLine());
                option = r.Menu(option);

                ///Option 1 = New Game. Start the game.
                if (option == 1)
                {
                    ///The games run until the HP isn´t 0 or quit is false.
                    while (p.HP != 0 && quit == false)
                    {
                        ///insert the player in the board in random position.
                        p.PlayerActions(board);
                        ///insert the exit in the board in randon position.
                        board.BoardTiles[e.ExitPos.Row, e.ExitPos.Column].Insert(2, e);
                        ///remove the last tile of the grid.
                        board.BoardTiles[e.ExitPos.Row, e.ExitPos.Column].RemoveAt(5);

                        ///Show the board render and the player stats.
                        r.RederBoard(board, level, p.HP);

                        ///Run the game until hp==0, exit=true and quit=true.
                        while (e.FindExit == false && p.HP != 0 && quit == false)
                        {
                            ///Let the player move.
                            enableMov = true;
                            ///remove the player position in the board
                            board.BoardTiles[p.PlayerPos.Row, p.PlayerPos.Column].RemoveAt(0);
                            ///insert in the last remove player position a null.
                            board.BoardTiles[p.PlayerPos.Row, p.PlayerPos.Column].Insert(0, null);
                            ///Show the posible actions of the player.
                            r.ChosePlayerAction(2);
                            ///Do this until the player chose a correct action.
                            do
                            {
                                ///get the action chosed by the player.
                                int action = p.ChoseAction();
                                ///set the action to do the player movement
                                p.DoPlayerAction(action, out enableMov, out quit);
                                ///if the move isn´t posible
                                if(enableMov == false)
                                {
                                    ///Show the alert message
                                    r.ChosePlayerAction(7);
                                }
                                ///if the movement is correct end the loop.
                            } while (enableMov != true);

                            ///insert the player in the new position.
                            p.PlayerActions(board);
                            ///increment the player turn.
                            turn++;
                            ///decrement player life by one.
                            p.HP -= 1;
                            ///Show the board with the new positions.
                            r.RederBoard(board, level, p.HP);
                            ///Check if the player find the exit tile.
                            e.CheckExit(board, p.PlayerPos.Row, p.PlayerPos.Column);
                            ///If the player find the exit tile show a message.
                            if (e.FindExit == true)
                            {
                                r.ChosePlayerAction(5);
                                Console.ReadKey();
                            }
                            ///If the player life its 0 show a message.
                            if (p.HP == 0)
                            {
                                r.ChosePlayerAction(6);
                                Console.ReadKey();
                            }
                        }
                        ///Reset the exit variable.
                        e.FindExit = false;
                        ///Reset the board.
                        board.ResetBoard();
                        ///Set the new random player position in the new level.
                        p.PlayerRandPos();
                        ///Set the new random exit position in the new level.
                        e.ExitRandPos();
                        ///Increment the level.
                        level++;
                    }
                    ///reset the quit variable
                    quit = false;
                    ///Reset the player life.
                    p.HP = 100;
                }
                ///Option 3 = credits. Show the game credits.
                else if (option == 3)
                {
                    Console.Clear();
                    r.ChosePlayerAction(3);
                    Console.ReadKey();
                }
                ///Option 4 = quit. Ends the game.
                else if (option == 4)
                {
                    r.ChosePlayerAction(4);
                    end = true;
                }
            } while (end != true);
        }
    }
}
