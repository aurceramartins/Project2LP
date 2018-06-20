using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    /// <summary>
    /// Class Board
    /// </summary>
    class Board
    {
        /// <summary>
        /// Propertie Tiles[,] BoardTiles
        /// </summary>
        public Tiles[,] BoardTiles { get; }
        /// <summary>
        /// Constructor Board
        /// </summary>
        public Board()
        {
            BoardTiles = new Tiles[8, 8];
            ResetBoard();
        }
        /// <summary>
        /// Method ResetBoard. Set to null all the positions in the board.
        /// </summary>
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
