using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    class Exit
    {
        /// <summary>
        /// propertie bool FindExit
        /// </summary>
        public bool FindExit { get; set; }
        /// <summary>
        /// Propertie Position ExitPos
        /// </summary>
        public Position ExitPos { get; set; }
        /// <summary>
        /// Constructor Exit
        /// </summary>
        public Exit()
        {
            FindExit = false;
            ExitPos = ExitRandPos();

        }
        /// <summary>
        /// Method ExitRandPos. Set the random position to exit in the board
        /// </summary>
        /// <returns></returns>
        public Position ExitRandPos()
        {
            ///Instanciate class Random
            Random rnd = new Random();
            ///Save random position between 0 and 8.
            int startPos = rnd.Next(0, 8);
            ///Set the random position to the ExitPos
            ExitPos = new Position(startPos, 7);
            return ExitPos;
        }
        /// <summary>
        /// Method CheckExit. Check if the player arrive at the end of level.
        /// </summary>
        /// <param name="b"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        public void CheckExit(Board b, int row, int col)
        {
            ///Counter
            int count = 0;
            ///Check the board in the player position.
            foreach (Object ob in b.BoardTiles[row,col])
            {
                ///Increment counter If the player and exit are in the same Tile
                if(ob is Player) { count++; }
                if(ob is Exit) { count++; }
                ///If the 2 objects are in the same Tile Findexit = true
                if(count == 2) { FindExit = true; count = 0; }
            }
            count = 0;
        }
    }
}
