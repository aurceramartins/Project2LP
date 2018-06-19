using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    class Position
    {
        public int Row { get; }
        public int Column { get; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
