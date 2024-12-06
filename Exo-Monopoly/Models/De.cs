using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Monopoly.Models
{
    public static class De
    {
        private static int _valeurMin = 1;
        private static int _valeurMax = 6;
        private static Random _rng;

        public static int ValeurMin
        {
            get { 
                return _valeurMin;
            }
            set {
                if (value <= 0) return; //Gérer à l'aide d'Exception
                _valeurMin = value;
                if(value >= _valeurMax) _valeurMax = value + 1;
            }
        }
        public static int ValeurMax
        {
            get {  return _valeurMax; }
            set
            {
                if (value <= 1) return; //Gérer à l'aide d'Exception
                _valeurMax = value;
                if (value <= _valeurMin) _valeurMin = value - 1;
            }
        }
        public static int[] Lancer(int nbDes)
        {
            _rng ??= new Random();
            int[] result = new int[nbDes];
            for (int i = 0; i < nbDes; i++)
            {
                result[i] = _rng.Next(_valeurMin, _valeurMax + 1);
            }
            return result;
        }
    }
}
