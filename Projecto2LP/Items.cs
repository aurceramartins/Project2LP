using System;
using System.Collections.Generic;
using System.Text;

namespace Projecto2LP
{
    /// <summary>
    /// Interface IItems.
    /// </summary>
    public interface IItems
    {
        /// <summary>
        /// Propertie float IItems.Weight.
        /// </summary>
        float Weight { get; set; }
        /// <summary>
        /// Method IItems.RandPos
        /// </summary>
        void RandPos();
    }
}
