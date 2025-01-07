using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Sup_Event_ChatSouris.Models
{
    public delegate void DeplacementHandler(int x, int y);
    public class Souris
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public event DeplacementHandler Deplacement;

        public void Deplacer()
        {
            Random RNG = new Random();
            PositionX += RNG.Next(-1,2);
            PositionY += RNG.Next(-1,2);
            Deplacement?.Invoke(PositionX, PositionY);
        }
    }
}
