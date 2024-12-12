using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exo_Monopoly.Models
{
    public abstract class Case : IVisiteur
    {
        private List<Joueur> _visiteurs;

        public Joueur[] Visiteurs
        {
            get { return _visiteurs.ToArray(); }
        }

        public string Nom { get; private set; }

        public Case(string nom)
        {
            Nom = nom;
            _visiteurs = new List<Joueur>();
        }

        public void AjouterVisiteur(Joueur visiteur)
        {
            if (visiteur is null) return;
            if (_visiteurs.Contains(visiteur)) return;
            _visiteurs.Add(visiteur);
        }

        public void RetirerVisiteur(Joueur visiteur)
        {
            if (visiteur is null) return;
            if (!_visiteurs.Contains(visiteur)) return;
            _visiteurs.Remove(visiteur);
        }

        public abstract void Activer(Joueur visiteur);
    }
}
