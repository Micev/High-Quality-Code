using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling
{
    class Volume : Diagonal
    {
        public static double CalcVolume()
        {
            double volume = Width * Height * Depth;
            return volume;
        }
    }
}
