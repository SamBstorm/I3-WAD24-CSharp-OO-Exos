using Exo_Monopoly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Monopoly.Models
{
    public class Joueur
    {
        public string nom;
        public Pions pion;
        public int position;

        public bool Avancer()
        {
            int[] result = De.Lancer(2);
            position += result[0] + result[1];
            return result[0] == result[1];
        }
    }
}
