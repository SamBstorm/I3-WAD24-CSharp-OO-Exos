using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Sup_Event_ChatSouris.Models
{
    public delegate void CaptureHandler();
    public class Chat
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public event CaptureHandler Capture;
        public void SeRaprocher(int sourisX, int sourisY)
        {
            if (PositionX > sourisX) PositionX--;
            else if (PositionX < sourisX) PositionX++;
            if (PositionY > sourisY) PositionY--;
            else if (PositionY < sourisY) PositionY++;
            Console.WriteLine($"Le chat se rapproche en {PositionX} - {PositionY}");
            if (PositionX == sourisX && PositionY == sourisY) Capture?.Invoke();
        }
    }
}
