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

            /* Test class Joueur 
            Joueur j1 = new Joueur("Samuel",Pions.Dino);

            Console.WriteLine($"{j1.Nom} c'est votre tour! Bougez le pion {j1.Pion} de la case {j1.Position}!");
            if (j1.Avancer())
            {
                Console.WriteLine($"Bravo {j1.Nom}! Vous avez fait un double!");
            }
            Console.WriteLine($"{j1.Nom} vous êtes à présent sur la case {j1.Position}!");

            Console.WriteLine($"Votre solde est de {j1.Solde} $Monopoly.");
            Console.WriteLine("Vos propriétés :");
            foreach(CasePropriete prop in j1.Proprietes)
            {
                Console.WriteLine($"\t- {prop.Nom} ({prop.Couleur})");
            }
            */

            /* Test de la class CasePropriete 

            CasePropriete i3Patio = new CasePropriete("Patio Interface 3", Couleurs.Marron, 20);

            Console.WriteLine($"La première case du jeu Monopoly Version I3 est :");
            Console.WriteLine(i3Patio.Nom);
            Console.WriteLine($"De couleur {i3Patio.Couleur}");
            Console.WriteLine($"Coutant {i3Patio.Prix} $Monopoly");
            if(i3Patio.EstHypotequee) Console.WriteLine("Ce terrain est hypotèqué...");
            else Console.WriteLine("Ce terrain n'est pas hypotèqué.");
            if (i3Patio.Proprietaire is null) Console.WriteLine("Ce terrain est en vente!");
            else Console.WriteLine($"Ce terrain appartient à {i3Patio.Proprietaire.Nom}");

            i3Patio.Acheter(j1);

            Console.WriteLine($"La première case du jeu Monopoly Version I3 est :");
            Console.WriteLine(i3Patio.Nom);
            Console.WriteLine($"De couleur {i3Patio.Couleur}");
            Console.WriteLine($"Coutant {i3Patio.Prix} $Monopoly");
            if (i3Patio.EstHypotequee) Console.WriteLine("Ce terrain est hypotèqué...");
            else Console.WriteLine("Ce terrain n'est pas hypotèqué.");
            if (i3Patio.Proprietaire is null) Console.WriteLine("Ce terrain est en vente!");
            else Console.WriteLine($"Ce terrain appartient à {i3Patio.Proprietaire.Nom}");

            Console.WriteLine($"Votre solde est de {j1.Solde} $Monopoly.");
            Console.WriteLine("Vos propriétés :");
            foreach (CasePropriete prop in j1.Proprietes)
            {
                Console.WriteLine($"\t- {prop.Nom} ({prop.Couleur})");
            }
            */

            /* Test de la class Jeu */

            Jeu monopolyI3 = new Jeu(
                [
                    new CasePropriete("Patio", Couleurs.Marron, 20),
                    new CasePropriete("Rez de chaussé Bât. G.", Couleurs.Marron, 20),
                    new CasePropriete("Rez de chaussé Bât. D.", Couleurs.Marron, 22),
                    new CasePropriete("Ascenceur Bât. D.", Couleurs.BleuCiel, 26),
                    new CasePropriete("Ascenceur Bât. G.", Couleurs.BleuCiel, 26),
                    new CasePropriete("Toilette du RdC", Couleurs.BleuCiel, 28),
                    new CasePropriete("Classe Games", Couleurs.Violet, 32),
                    new CasePropriete("Classe WEB", Couleurs.Violet, 32),
                    new CasePropriete("Classe WAD", Couleurs.Violet, 36)
                ]);

            monopolyI3.AjouterJoueur("Marwa", Pions.Dino);
            monopolyI3.AjouterJoueur("Dorothée", Pions.Voiture);
            monopolyI3.AjouterJoueur("Leslie", Pions.Chien);
            monopolyI3.AjouterJoueur("Mélusine", Pions.DeACoudre);
            /* Joueurs non-utilisés
            monopolyI3.AjouterJoueur("Emilie", Pions.Cuirasse);
            monopolyI3.AjouterJoueur("Jessica", Pions.Fer);
            monopolyI3.AjouterJoueur("Charifa", Pions.Chapeau);
            monopolyI3.AjouterJoueur("Anaïs", Pions.Brouette);
            monopolyI3.AjouterJoueur("Jenny", Pions.Chaussure);
            monopolyI3.AjouterJoueur("Amalia", Pions.Chien);
            monopolyI3.AjouterJoueur("Debby", Pions.Dino);*/

            int nbJoueursSolvable = 0;
            foreach (Joueur j in monopolyI3.Joueurs)
            {
                if(j.Solde > 0) nbJoueursSolvable++;
            }

            int indexJoueur = 0;
            while (nbJoueursSolvable > 1)
            {
                Joueur joueurCourant = monopolyI3.Joueurs[indexJoueur % monopolyI3.Joueurs.Length];
                Console.WriteLine($"Au tour de {joueurCourant.Nom}.");
                bool rejoue;
                do
                {
                    Case caseCourante = monopolyI3[joueurCourant.Position];
                    Console.WriteLine($"Il est actuellement sur la case {caseCourante.Nom}.");
                    caseCourante.RetirerVisiteur(joueurCourant);
                    rejoue = joueurCourant.Avancer();
                    caseCourante = monopolyI3[joueurCourant.Position];
                    Console.WriteLine($"Il se déplace sur la case {caseCourante.Nom}.");
                    caseCourante.AjouterVisiteur(joueurCourant);
                    caseCourante.Activer(joueurCourant);
                    Console.WriteLine($"Le nombre de propriété de {joueurCourant.Nom} est de {joueurCourant.Proprietes.Length}.");
                    Console.WriteLine($"Son solde actuel est de {joueurCourant.Solde} $Monopoly."); 
                } while (rejoue);
                nbJoueursSolvable = 0;
                foreach (Joueur j in monopolyI3.Joueurs)
                {
                    if (j.Solde > 0) nbJoueursSolvable++;
                }
                indexJoueur++;
            }

            /* Test Antérieur à la notion abstract
            Joueur joueurCourant = monopolyI3[Pions.Chapeau];
            joueurCourant = joueurCourant + 200;
            Console.WriteLine($"C'est au tour du pion {joueurCourant.Pion} ({joueurCourant.Nom}) :");
            joueurCourant.Avancer();
            Console.WriteLine($"{joueurCourant.Nom}: avancez à la case {joueurCourant.Position}.");
            Case caseJoueur = monopolyI3[joueurCourant.Position];
            Console.WriteLine($"Bienvenue sur la case {caseJoueur.Nom}.");
            //caseJoueur.Acheter(joueurCourant);
            /*
            //if(caseJoueur is CasePropriete)
            //{
            //    CasePropriete propriete = (CasePropriete)caseJoueur;
            //    CasePropriete[] proprietesJoueur = joueurCourant + propriete;
            //    Console.WriteLine($"{joueurCourant.Nom} : votre solde est de {joueurCourant.Solde}!");
            //}

            //if (caseJoueur is CasePropriete propriete)
            //{
            //    CasePropriete[] proprietesJoueur = joueurCourant + propriete;
            //    Console.WriteLine($"{joueurCourant.Nom} : votre solde est de {joueurCourant.Solde}!");
            //}*/

            /*Test Case et Case Propriété

            Case caseDepart = new Case("Case départ");
            CasePropriete propriete1 = new CasePropriete("Propriété 1", Couleurs.Marron, 20);

            caseDepart.AjouterVisiteur(joueurCourant);
            caseDepart.AjouterVisiteur(monopolyI3[Pions.Dino]);
            Console.WriteLine($"Les joueurs présent sur la {caseDepart.Nom} sont :");
            foreach (Joueur visiteur in caseDepart.Visiteurs)
            {
                Console.WriteLine($"\t- {visiteur.Pion} ({visiteur.Nom})");
            }

            caseDepart.RetirerVisiteur(joueurCourant);
            propriete1.AjouterVisiteur(joueurCourant);
            Console.WriteLine($"Les joueurs présent sur la {propriete1.Nom} sont :");
            foreach (Joueur visiteur in propriete1.Visiteurs)
            {
                Console.WriteLine($"\t- {visiteur.Pion} ({visiteur.Nom})");
            }*/
        }
    }
}
