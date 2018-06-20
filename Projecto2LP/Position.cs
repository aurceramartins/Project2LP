using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    /// <summary>
    /// Class Position. The positions that contais the board.
    /// </summary>
    class Position
    {
        /// <summary>
        /// propertie Row
        /// </summary>
        public int Row { get; }
        /// <summary>
        /// Porpertie Column
        /// </summary>
        public int Column { get; }
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
