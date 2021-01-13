using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cargo_Affaires;

namespace Cargo_Tests
{
    [TestClass]
    public class CargoTests
    {
        private Cargo cargo;
        private Baril baril1, baril2, baril3, baril4, baril5;

        [TestInitialize]
        public void initialiser()
        {
            cargo = new Cargo("Titanic", 3);
            baril1 = new Baril(50, "Biere");
            baril2 = new Baril(30, "Eau");
            baril3 = new Baril(15, "Biere");
            baril4 = new Baril(25, "Biere");
            baril5 = new Baril(23, "Vinaigre");
        }
        [TestMethod]
        public void CargoCreationTests()
        {
            Assert.AreEqual("Titanic", cargo.Nom);
            Assert.AreEqual(3, cargo.Capacite);
            Assert.IsNotNull(cargo.Barils);
            Assert.AreEqual(0, cargo.denombrerBarils());
        }
        [TestMethod]
        public void CargoAjoutsSerie1Tests()
        {
            Assert.AreEqual(0, cargo.calculerNbUnites("Biere"));
            Assert.IsFalse(cargo.estPlein());
            cargo.ajouter(baril1);
            Assert.AreEqual(1, cargo.denombrerBarils());
            Assert.AreEqual(50, cargo.calculerNbUnites("Biere"));
            Assert.AreEqual(0, cargo.calculerNbUnites("Eau"));
            cargo.ajouter(baril2);
            Assert.AreEqual(2, cargo.denombrerBarils());
            Assert.IsFalse(cargo.estPlein());
            Assert.AreEqual(50, cargo.calculerNbUnites("Biere"));
            Assert.AreEqual(30, cargo.calculerNbUnites("Eau"));
            cargo.ajouter(baril3);
            Assert.AreEqual(3, cargo.denombrerBarils());
            Assert.IsTrue(cargo.estPlein());
            Assert.AreEqual(65, cargo.calculerNbUnites("Biere"));
            cargo.ajouter(baril4);
            Assert.AreEqual(3, cargo.denombrerBarils());
            Assert.IsTrue(cargo.estPlein());
            Assert.AreEqual(90, cargo.calculerNbUnites("Biere"));
            // Nouveau produit apres limite de barils
            cargo.ajouter(baril5);
            Assert.AreEqual(3, cargo.denombrerBarils());
            Assert.IsTrue(cargo.estPlein());
            Assert.AreEqual(0, baril1.Quantite);
            Assert.AreEqual(0, baril2.Quantite);
            Assert.AreEqual(0, baril3.Quantite);
            Assert.AreEqual(0, baril4.Quantite);
            Assert.AreEqual(23, baril5.Quantite);
            Assert.AreEqual(90, cargo.calculerNbUnites("Biere"));
            Assert.AreEqual(30, cargo.calculerNbUnites("Eau"));
            Assert.AreEqual(0, cargo.calculerNbUnites("Vinaigre"));
        }
        [TestMethod]
        public void CargoAjoutsSerie2Tests()
        {
            cargo.ajouter(baril2);
            cargo.ajouter(baril3);
            cargo.ajouter(baril5);
            // Transvidage incomplet, capacite atteinte de barils
            cargo.ajouter(baril1);
            Assert.AreEqual(0, baril2.Quantite);
            Assert.AreEqual(0, baril3.Quantite);
            Assert.AreEqual(0, baril5.Quantite);
            Assert.AreEqual(15, baril1.Quantite);
        }
    }
}
