using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    /// <summary>
    /// class Tiles
    /// </summary>
    class Tiles : List<Object>
    {
        /// <summary>
        /// Propertie bool TileExploration
        /// </summary>
        public bool TileExploration { get; set; }
        /// <summary>
        /// Constructor Tiles
        /// </summary>
        public Tiles() : base(10)
        {
            ResetTiles();
        }
        /// <summary>
        /// Method GetTiles. Return al the tiles in each boar cell.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Object> GetTiles()
        {
            foreach (Object obj in this)
            {
                yield return obj;
            }
        }
        /// <summary>
        /// Method ResetTiles. Reset all the tiles to null.
        /// </summary>
        public void ResetTiles()
        {
            for (int i = 0; i < 10; i++)
            {
                Add(null);
                TileExploration = false;
            }
        }
    }
}
