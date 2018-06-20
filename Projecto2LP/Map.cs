using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    /// <summary>
    /// Class Map interface IItems
    /// </summary>
    class Map : IItems
    {
        /// <summary>
        /// Propertie float Weight.
        /// </summary>
        public float Weight { get; set; }
        /// <summary>
        /// Propertie Position Pos
        /// </summary>
        public Position Pos { get; private set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public Map()
        {
            Weight = 1.0f;
            RandPos();
        }
        /// <summary>
        /// Method RandPos set the random position to the map.
        /// </summary>
        public void RandPos()
        {
            ///Variables random.
            Random rnd = new Random();
            Random rnd1 = new Random();
            ///Save a random number between 0 and 8.
            int startPos = rnd.Next(0, 8);
            int startPos1 = rnd1.Next(0, 8);
            ///Set the random position of the map in Pos.
            Pos = new Position(startPos, startPos1);
        }
        /// <summary>
        /// Method CheckPickup. Check if its posible pick up an object
        /// </summary>
        /// <param name="b"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public int CheckPickUp(Board b, int row, int col)
        {
            ///Counter
            int count = 0;
            ///check the objects in the tile at position row,col
            foreach (Object ob in b.BoardTiles[row, col])
            {
                ///If the object have type Map
                if (ob is Map) { count++; }
                ///Return 1 if the object is a Map
                if (count == 1) { return 1; }
            }
            return 0;
        }
        /// <summary>
        /// Class PickUpMap. Do the actions when you pick up the map.
        /// </summary>
        /// <param name="board"></param>
        public void PickUpMap(Board board)
        {
            ///Go throw all positions in the board
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ///Set all the positions in the map explored
                    board.BoardTiles[i, j].TileExploration = true;

                    ///if is the cell where stay the map
                    if (i == Pos.Row && j == Pos.Column)
                    {
                        ///Go throw the 10 Tiles
                        for (int k = 0; k < 10; k++)
                        {
                            ///If the object in that tile is a Map
                            if(board.BoardTiles[i, j][k] is Map)
                            {
                                ///Remove the map in it position
                                board.BoardTiles[Pos.Row, Pos.Column].RemoveAt(k);
                                ///In that position put a null.
                                board.BoardTiles[Pos.Row, Pos.Column].Insert(k, null);
                            }
                        }
                    }
                }
            }
        }
    }
}
