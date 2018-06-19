using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    class Board
    {
        public Tiles[,] BoardTiles { get; }

        public Board()
        {
            BoardTiles = new Tiles[8, 8];
            ResetBoard();
        }
        public void ResetBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    BoardTiles[i, j] = new Tiles();
                }
            }
        }
    }
}
