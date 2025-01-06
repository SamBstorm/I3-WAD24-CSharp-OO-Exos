using Exo_Monopoly.Enums;
using Exo_Monopoly.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Monopoly.Models
{
    public delegate void JoueurAvanceDelegate(Joueur joueur);
    public class Joueur
    {
        public event JoueurAvanceDelegate JoueurAvanceEvent;
        private int _position;
        private List<CasePropriete> _proprietes;
        public string Nom {  get; set; }
        public Pions Pion { get; set; }
        public int Position { 
            get
            {
                return _position;
            }
            private set {
                if (_position != value)
                {
                    _position = value;
                    JoueurAvanceEvent?.Invoke(this);
                }
            }
        }
        public CasePropriete[] Proprietes { 
            get{
                return _proprietes.ToArray();
            } 
        }

        public int Solde { get; private set; }
        public Joueur(string nom, Pions pion)
        {
            Nom = nom;
            Pion = pion;
            Solde = 1500;
            _proprietes = new List<CasePropriete>();
            //_position = 0;
        }
        public bool Avancer()
        {
            int[] result = De.Lancer(2);
            Position += result[0] + result[1];
            return result[0] == result[1];
        }

        public void EtrePaye(int montant)
        {
            if (montant <= 0) return;   //Gérer avec une Exception
            Solde += montant;
        }

        public void Payer(int montant)
        {
            if (montant <= 0) return;   //Gérer avec une Exception
            if (Solde < montant) throw new NotEnoughMoneyException(this, montant);
            Solde -= montant;
        }

        public void AjouterPropriete(CasePropriete propriete)
        {
            if (propriete is null) return;                  //Gérer avec une Exception
            if (Proprietes.Contains(propriete)) return;     //Gérer avec une Exception
            if (propriete.Proprietaire == this) _proprietes.Add(propriete);
        }

        public static Joueur operator +(Joueur left, int right)
        {
            left.EtrePaye(right);
            return left;
        }
                /* Surcharge opérateur devenu obsolète par le niveau de protection de la méthode CasePropriete.Acheter()
        public static CasePropriete[] operator +(Joueur left, CasePropriete right) {
            right.Acheter(left);
            return left.Proprietes;
        }*/
    }
}
