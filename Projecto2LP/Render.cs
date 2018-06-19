using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    class Render
    {
        public void RederBoard(Board board, int turn, int hp)
        {
            Console.Clear();
            Console.WriteLine("+++++++++++++++++++++++++++ LP1 Rogue : " +
                "Level " + turn + " +++++++++++++++++++++++++++");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int count = 0;
                    foreach (Object t in board.BoardTiles[i, j])
                    {
                        count++;
                        if (board.BoardTiles[i, j].TileExploration)
                        {
                            if (t == null)
                            {
                                Console.Write(".");
                            }
                            else if (t is Player)
                            {
                                Console.Write("P");
                            }
                            else if (t is Exit)
                            {
                                Console.Write("Exit!");
                            }
                            else if (t is Map)
                            {
                                Console.Write("M");
                            }
                        }
                        else
                        {
                            Console.Write("~");

                        }

                    }
                    count = 0;

                    Console.Write("  ");
                }
                Console.Write("\n");
            }
            Console.WriteLine("\n Player Stats \n" +
                "------------------\n" +
                "HP - " + hp);
        }

        public void ChosePlayerAction(int option)
        {
            switch (option)
            {
                case 1:
                    Console.WriteLine("Select Option");
                    Console.Write("Menu \n" +
    "1- New game \n" +
    "2- High scores\n" +
    "3 - Credits\n" +
    "4- Quit\n");
                    break;
                case 2: Console.WriteLine("Chose one action\n" +
                    "(W)Move North  (A)Move West (S)Move South (D)Move East\n" +
                    "(E)PickUp Object (Q)Quit Game"); break;
                case 3:
                    Console.WriteLine("Made by Alejandro Urcera, " +
                "Joana Marques " + " & Pedro Santos"); break;
                case 4: Console.WriteLine("Bye"); break;
                case 5: Console.WriteLine("You pass the level"); break;
                case 6: Console.WriteLine("YOU DIED"); break;
                case 7: Console.WriteLine("You can´t do this action, choose another one"); break;
                case 0: Console.WriteLine(" "); break;
            }
        }
        public int Menu(int option)
        {

            switch (option)
            {
                case 1: return 1; break;
                case 2: return 2; break;
                case 3: return 3; break;
                case 4: return 4; break;
                default: return 0; break;
            }

        }
    }
}
