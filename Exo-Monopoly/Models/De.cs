using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Monopoly.Models
{
    public static class De
    {
        public static int valeurMin = 1;
        public static int valeurMax = 6;
        public static Random rng;

        public static int[] Lancer(int nbDes)
        {
            rng ??= new Random();
            int[] result = new int[nbDes];
            for (int i = 0; i < nbDes; i++)
            {
                result[i] = rng.Next(valeurMin, valeurMax + 1);
            }
            return result;
        }
    }
}
