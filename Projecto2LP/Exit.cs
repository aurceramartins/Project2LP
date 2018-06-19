using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    class Exit
    {

        public bool FindExit { get; set; }
        public Position ExitPos { get; set; }
        public Exit()
        {
            FindExit = false;
            ExitPos = ExitRandPos();

        }

        public Position ExitRandPos()
        {
            Random rnd = new Random();
            int startPos = rnd.Next(0, 8);
            ExitPos = new Position(startPos, 7);
            return ExitPos;
        }

        public void CheckExit(Board b, int row, int col)
        {
            int count = 0;
            foreach (Object ob in b.BoardTiles[row,col])
            {
                if(ob is Player) { count++; }
                if(ob is Exit) { count++; }

                if(count == 2) { FindExit = true; count = 0; }
            }
            count = 0;
        }
    }
}
