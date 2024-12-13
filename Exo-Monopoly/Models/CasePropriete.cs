using Exo_Monopoly.Enums;
using Exo_Monopoly.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Monopoly.Models
{
    public class CasePropriete : Case, IProprietaire
    {
        /* Version complète (seulement si vérification en entrée et sortie)
        private string _nom;

        public string Nom
        {
            get { return _nom; }
            private set { _nom = value; }
        }*/
        /*Auto-proprétée (Seulement si aucune vérification)*/
        public Couleurs Couleur { get; }
        public int Prix { get; }
        public bool EstHypotequee { get; private set; }
        public Joueur Proprietaire { get; private set; }

        public CasePropriete(string nom, Couleurs couleur, int prix) : base(nom)
        {
            Couleur = couleur;
            Prix = prix;
            /* Pas nécessaire de les affecter, les variables auront les bonnes valeurs car valeur par défaut de leur type
            
            EstHypotequee = false;
            Proprietaire = null;
            */
        }

        private void Acheter(Joueur acheteur)
        {
            if (acheteur is null) return;           //Gérer avec une Exception
            if (Proprietaire == acheteur) return;   //Gérer avec une Exception
            /*Puisque une exception peut-être relevée par la méthode Joueur.Payer(int montant), il n'est plus nécessaire de contrôller le Solde
            if (acheteur.Solde < Prix) return;
            */
            try
            {
                acheteur.Payer(Prix);
            }
            catch (NotEnoughMoneyException ex)
            {
                throw new NotEnoughMoneyException(ex.Payeur,ex.Montant,this);
            }
            Proprietaire = acheteur;
            acheteur.AjouterPropriete(this);
        }

        private void Sejourner(Joueur visiteur)
        {
            if (visiteur is null) return;          //Gérer avec une Exception
            if (Proprietaire is null) return;      //Gérer avec une Exception
            if (Proprietaire == visiteur) return;  //Gérer avec une Exception
            int montant = Prix / 4;
            visiteur.Payer(montant);
            Proprietaire.EtrePaye(montant);
        }

        public override void Activer(Joueur visiteur)
        {
            if (visiteur is null) return;          //Gérer avec une Exception
            if (Proprietaire is null)
            {
                try
                {
                    Acheter(visiteur);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (Proprietaire != visiteur) Sejourner(visiteur);
        }

        public void Hypothequer()
        {
            if (EstHypotequee) return;             //Gérer avec une Exception      
            EstHypotequee = true;
            Proprietaire.EtrePaye(Prix / 2);
        }

        public void Deshypothequer()
        {
            if(!EstHypotequee) return;          //Gérer avec une Exception
            int currentSolde = Proprietaire.Solde;
            Proprietaire.Payer((int)(Prix*0.6));
            if (currentSolde != Proprietaire.Solde)
            {
                EstHypotequee = false;
            }
        }
    }
}
