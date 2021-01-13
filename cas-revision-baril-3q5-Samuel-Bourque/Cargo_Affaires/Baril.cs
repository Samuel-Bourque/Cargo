using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo_Affaires
{
    public class Baril
    {
        private int _quantite;
        private string _nomProduit;
        public const int CAPACITE = 50;

        public Baril(int qte, string nomProduit)
        {
            _quantite = qte;
            _nomProduit = nomProduit;
        }
        #region Proprietes
        public int Quantite { get { return _quantite; } set { _quantite = value; } }
        public string NomProduit { get { return _nomProduit; } set { _nomProduit = value; } }
        #endregion

        public bool estPlein() { return _quantite == CAPACITE; }
        public bool estVide() { return _quantite == 0; }
        public bool estCompatible(Baril autreBaril) { return _nomProduit.Equals(autreBaril.NomProduit); }
        public void transvider(Baril autreBaril)
        {
            // verifier si compatible
            if(this.estCompatible(autreBaril))
            {
                int dispo = CAPACITE - _quantite;
                if(autreBaril.Quantite <= dispo)
                {
                    _quantite += autreBaril.Quantite;
                    autreBaril.Quantite = 0;
                }
                else
                {
                    _quantite = CAPACITE;
                    autreBaril.soustraire(dispo);
                }
            }
        }
        public void soustraire(int qte)
        {
            _quantite -= qte;
            if (_quantite < 0)
                _quantite = 0;
        }
    }
}
