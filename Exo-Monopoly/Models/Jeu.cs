using Exo_Monopoly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Monopoly.Models
{
    public class Jeu
    {
        private List<Joueur> _joueurs;
        private List<CasePropriete> _plateau;

        public Joueur[] Joueurs
        {
            get { return _joueurs.ToArray(); }
        }

        public CasePropriete[] Plateau
        {
            get { return _plateau.ToArray(); }
        }

        public CasePropriete this[int numero] {
            get
            {
                numero = numero % _plateau.Count;
                return _plateau[numero];
            }
        }

        public Joueur this[Pions pion]
        {
            get 
            {
                foreach (Joueur j in _joueurs)
                {
                    if(j.Pion == pion) return j;
                }
                return null;
            }
        }

        public Jeu(CasePropriete[] cases)
        {
            if (cases is null) return;           //Gérer à l'aide d'Exception
            if (cases.Length <= 0) return;       //Gérer à l'aide d'Exception
            _joueurs = new List<Joueur>();
            _plateau = new List<CasePropriete>(cases);
        }

        public void AjouterJoueur(string nom, Pions pion)
        {
            if (nom is null) return;                    //Gérer à l'aide d'Exception
            if (this[pion] is not null) return;         //Gérer à l'aide d'Exception
            _joueurs.Add(new Joueur(nom, pion));
        }
    }
}
