using Exo_Monopoly.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Monopoly.Models
{
    public class CasePropriete
    {
        /* Version complète (seulement si vérification en entrée et sortie)
        private string _nom;

        public string Nom
        {
            get { return _nom; }
            private set { _nom = value; }
        }*/
        /*Auto-proprétée (Seulement si aucune vérification)*/
        public string Nom { get; }
        public Couleurs Couleur { get; }
        public int Prix { get; }
        public bool EstHypotequee { get; }
        public Joueur Proprietaire { get; }

        public CasePropriete(string nom, Couleurs couleur, int prix)
        {
            Nom = nom;
            Couleur = couleur;
            Prix = prix;
            /* Pas nécessaire de les affecter, les variables auront les bonnes valeurs car valeur par défaut de leur type
            
            EstHypotequee = false;
            Proprietaire = null;
            */
        }
    }
}
