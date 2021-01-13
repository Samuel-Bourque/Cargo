using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo_Affaires
{
    public class Cargo
    {
        private string _nom;
        private int _capacite;
        private List<Baril> _barils;
        #region Proprietes
        public string Nom { get { return _nom; } set { _nom = value; } }
        public int Capacite { get { return _capacite; } set { _capacite = value; } }
        public List<Baril> Barils { get { return _barils; } set { _barils = value; } }
        #endregion

        public Cargo(string nom, int capacite)
        {
            _nom = nom;
            _capacite = capacite;
            _barils = new List<Baril>();
        }
        public void ajouter(Baril baril)
        {
            // completer le dernier baril compatible
            // s'il reste toujours une qte dans le baril recu, 
            // ajouter un nouveau baril avec ce contenu, vider le baril recu
            Baril trouve = null;
            foreach (Baril b in _barils)
                if (b.estCompatible(baril))
                    trouve = b;
            if(trouve != null)
                trouve.transvider(baril);
            if(!baril.estVide() && !this.estPlein())
            {
                Baril nouveau = new Baril(0, baril.NomProduit);
                _barils.Add(nouveau);
                nouveau.transvider(baril);
            }
        }
        public int calculerNbUnites(string nomProduit)
        {
            int total = 0;
            foreach (Baril b in _barils)
                if (b.NomProduit.Equals(nomProduit))
                    total += b.Quantite;
            return total;
        }
        public bool estPlein()
        {
            return _capacite == _barils.Count;
        }
        public int denombrerBarils()
        {
            return _barils.Count;
        }
    }
}
