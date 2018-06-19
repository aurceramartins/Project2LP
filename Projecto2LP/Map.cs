using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    class Map : IItems
    {
        public float Weight { get; set; }
        public Position Pos { get; private set; }

        public Map()
        {
            Weight = 1.0f;
            RandPos();
        }

        public void RandPos()
        {
            Random rnd = new Random();
            Random rnd1 = new Random();
            int startPos = rnd.Next(0, 8);
            int startPos1 = rnd1.Next(0, 8);
            Pos = new Position(startPos, startPos1);
        }

        public int CheckPickUp(Board b, int row, int col)
        {
            int count = 0;
            foreach (Object ob in b.BoardTiles[row, col])
            {
                if (ob is Map) { count++; }
                if (count == 1) { return 1; }
            }
            return 0;
        }

        public void PickUpMap(Board board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board.BoardTiles[i, j].TileExploration = true;


                    if (i == Pos.Row && j == Pos.Column)
                    {
                        for (int k = 0; k < 10; k++)
                        {
                            if(board.BoardTiles[i, j][k] is Map)
                            {
                                board.BoardTiles[Pos.Row, Pos.Column].RemoveAt(k);
                                board.BoardTiles[Pos.Row, Pos.Column].Insert(k, null);
                            }

                        }
                    }
                }
            }
        }
    }
}
