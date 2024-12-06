using Exo_Monopoly.Enums;
using Exo_Monopoly.Models;

namespace Exo_Monopoly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Test class De
            int[] result = De.Lancer(2);
            Console.WriteLine( $"Premier dé : {result[0]}\nSecond dé : {result[1]}");
            */
            
            /* Test class Joueur */
            Joueur j1 = new Joueur() {
                Nom = "Samuel",
                Pion = Pions.Dino
            };

            Console.WriteLine($"{j1.Nom} c'est votre tour! Bougez le pion {j1.Pion} de la case {j1.Position}!");
            if (j1.Avancer())
            {
                Console.WriteLine($"Bravo {j1.Nom}! Vous avez fait un double!");
            }
            Console.WriteLine($"{j1.Nom} vous êtes à présent sur la case {j1.Position}!");

            /* Test de la class CasePropriete */

            CasePropriete i3Patio = new CasePropriete("Patio Interface 3", Couleurs.Marron, 20);

            Console.WriteLine($"La première case du jeu Monopoly Version I3 est :");
            Console.WriteLine(i3Patio.Nom);
            Console.WriteLine($"De couleur {i3Patio.Couleur}");
            Console.WriteLine($"Coutant {i3Patio.Prix} $Monopoly");
            if(i3Patio.EstHypotequee) Console.WriteLine("Ce terrain est hypotèqué...");
            else Console.WriteLine("Ce terrain n'est pas hypotèqué.");
            if (i3Patio.Proprietaire is null) Console.WriteLine("Ce terrain est en vente!");
            else Console.WriteLine($"Ce terrain appartient à {i3Patio.Proprietaire.Nom}");
        }
    }
}
