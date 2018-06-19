using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    class GameLoop
    {
        public void Play()
        {
            Board board = new Board();

            Player p = new Player();

            Exit e = new Exit();

            Render r = new Render();
            bool enableMov;
            bool quit = false;
            int turn = 0;
            int level = 1;
            bool end = false;

            do
            {
                Console.Clear();
                r.ChosePlayerAction(1);
                int option = Convert.ToInt32(Console.ReadLine());
                option = r.Menu(option);

                if (option == 1)
                {
                    while (p.HP != 0 && quit == false)
                    {
                        p.PlayerActions(board);
                        board.BoardTiles[e.ExitPos.Row, e.ExitPos.Column].Insert(2, e);
                        board.BoardTiles[e.ExitPos.Row, e.ExitPos.Column].RemoveAt(5);

                        r.RederBoard(board, level, p.HP);

                        while (e.FindExit == false && p.HP != 0 && quit == false)
                        {
                            enableMov = true;

                            board.BoardTiles[p.PlayerPos.Row, p.PlayerPos.Column].RemoveAt(0);
                            board.BoardTiles[p.PlayerPos.Row, p.PlayerPos.Column].Insert(0, null);
                            r.ChosePlayerAction(2);
                            do
                            {
                                int action = p.ChoseAction();
                                p.DoPlayerAction(action, out enableMov, out quit);
                                if(enableMov == false)
                                {
                                    r.ChosePlayerAction(7);
                                }
                            } while (enableMov != true);

                            p.PlayerActions(board);
                            turn++;
                            p.HP -= 1;
                            r.RederBoard(board, level, p.HP);
                            e.CheckExit(board, p.PlayerPos.Row, p.PlayerPos.Column);
                            if (e.FindExit == true)
                            {
                                r.ChosePlayerAction(5);
                            }
                            if (p.HP == 0)
                            {
                                r.ChosePlayerAction(6);
                                Console.ReadKey();
                            }
                        }
                        e.FindExit = false;
                        board.ResetBoard();
                        p.PlayerRandPos();
                        e.ExitRandPos();
                        level++;
                    }
                    quit = false;
                    p.HP = 100;
                }
                else if (option == 3)
                {
                    Console.Clear();
                    r.ChosePlayerAction(3);
                    Console.ReadKey();
                }
                else if (option == 4)
                {
                    r.ChosePlayerAction(4);
                    end = true;
                }
            } while (end != true);
        }
    }
}
