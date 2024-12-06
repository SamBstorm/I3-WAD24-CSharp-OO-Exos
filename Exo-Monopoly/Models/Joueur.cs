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
        private int _position;
        public string Nom {  get; set; }
        public Pions Pion { get; set; }
        public int Position { 
            get
            {
                return _position;
            }
            private set { 
                _position = value;
            }
        }

        public int Solde { get; private set; }

        public bool Avancer()
        {
            int[] result = De.Lancer(2);
            Position += result[0] + result[1];
            return result[0] == result[1];
        }
    }
}
