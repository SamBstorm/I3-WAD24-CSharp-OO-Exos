using Exo_Sup_Event_ChatSouris.Models;

namespace Exo_Sup_Event_ChatSouris
{
    internal class Program
    {
        public static bool FinDeJeu { get; private set; } = false;
        static void Main(string[] args)
        {
            Souris s = new Souris();
            s.PositionX = 5;
            s.PositionY = 5;
            Chat c = new Chat();
            c.PositionX = 0;
            c.PositionY = 0;

            s.Deplacement += delegate (int x, int y)
            {
                Console.WriteLine($"La souris se déplace en {x} - {y}.");
            };
            s.Deplacement += c.SeRaprocher;
            c.Capture += CaptureAction;

            //c.Capture += delegate ()
            //{
            //    Console.WriteLine("Le chat a capturé la souris!\nMiam Miam!");
            //    FinDeJeu = true;
            //};

            do
            {
                s.Deplacer();
            } while(!FinDeJeu);
        }

        static void CaptureAction()
        {
            Console.WriteLine("Le chat a capturé la souris!\nMiam Miam!");
            FinDeJeu = true;
        }
    }
}
