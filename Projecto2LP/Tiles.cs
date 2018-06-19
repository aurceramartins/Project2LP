using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    class Tiles : List<Object>
    {
        public bool TileExploration { get; set; }

        public Tiles() : base(10)
        {
            ResetTiles();
        }

        public IEnumerator<Object> GetTiles()
        {
            foreach (Object obj in this)
            {
                yield return obj;
            }
        }

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
