using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cargo_Affaires;

namespace Cargo_Tests
{
    [TestClass]
    public class BarilTests
    {
        private Baril baril1, baril2, baril3, baril4, baril5;

        [TestInitialize]
        public void initialiser()
        {
            baril1 = new Baril(50, "Biere");
            baril2 = new Baril(15, "Biere");
            baril3 = new Baril(25, "Biere");
            baril4 = new Baril(35, "Biere");
            baril5 = new Baril(25, "Biere");
        }
        [TestMethod]
        public void BarilCreationTests()
        {
            Assert.AreEqual("Biere", baril2.NomProduit);
            Assert.AreEqual(15, baril2.Quantite);
            Assert.IsTrue(baril1.estPlein());
            Assert.IsFalse(baril2.estPlein());
            Assert.IsFalse(baril1.estVide());
            Assert.IsFalse(baril2.estVide());
        }
        [TestMethod]
        public void BarilTransviderTests()
        {
            // Cas 1 -- baril plein au depart
            // baril1(50) <- baril2(15) : aucun changement
            baril1.transvider(baril2);
            Assert.AreEqual(50, baril1.Quantite);
            Assert.AreEqual(15, baril2.Quantite);
            // Cas 2 -- tout transvider entre deux barils
            // baril2(15) <- baril3(25) : baril2(40), baril3(0)
            baril2.transvider(baril3);
            Assert.AreEqual(40, baril2.Quantite);
            Assert.IsTrue(baril3.estVide());
            // Cas 3 -- transvider partiellement le contenu
            // baril2(40) <- baril4(35) : baril2(50), baril4(25)
            baril2.transvider(baril4);
            Assert.IsTrue(baril2.estPlein());
            Assert.AreEqual(25, baril4.Quantite);
            // Cas 4 -- transvider completement le contenu, baril plein
            // baril4(25) <- baril5(25) : baril4(50), baril5(0)
            baril4.transvider(baril5);
            Assert.IsTrue(baril4.estPlein());
            Assert.IsTrue(baril5.estVide());
        }
        [TestMethod]
        public void BarilRetraitsTests()
        {
            // Cas 1
            baril1.soustraire(5);
            Assert.AreEqual(45, baril1.Quantite);
            Assert.IsFalse(baril1.estVide());
            // Cas 2
            baril1.soustraire(45);
            Assert.IsTrue(baril1.estVide());
        }
        [TestMethod]
        public void BarilCompatibiliteTests()
        {
            Assert.IsTrue(baril1.estCompatible(baril2));
            Assert.IsFalse(baril1.estCompatible(new Baril(45, "Vin")));
        }
    }
}
