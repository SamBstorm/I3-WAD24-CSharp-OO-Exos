using Exo_Monopoly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Monopoly.Exceptions
{
    public class NotEnoughMoneyException : Exception
    {
        public Joueur Payeur { get; private set; }
        public int Montant { get; private set; }
        public CasePropriete Bien {  get; private set; }

        public NotEnoughMoneyException(Joueur payeur, int montant) : this(payeur, montant, null,$"{payeur.Nom} n'a pas su payer le montant de {montant} $M.")
        {
            //Pas de code à ajouter, tout se fait dans le constructeur à 4 paramètres
        }
        public NotEnoughMoneyException(Joueur payeur, int montant, CasePropriete bien) : this(payeur, montant, bien, $"{payeur.Nom} n'a pas su payer le montant de {montant} $M pour l'achat de {bien.Nom}.")
        {
            //Pas de code à ajouter, tout se fait dans le constructeur à 4 paramètres
        }

        private NotEnoughMoneyException(Joueur payeur, int montant, CasePropriete bien, string message) : base(message) { 
            Payeur = payeur;
            Montant = montant;
            Bien = bien;
        }
    }
}
