using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PillarPencilDurability;

namespace PillarPencilDurabilityTest
{
    [TestClass]
    public class PencilDurabilityTest
    {
        PencilDurability pencil;

        [TestInitialize()]
        public void Initialize()
        {
            pencil = new PencilDurability(10);
        }

        [TestMethod]
        public void WhenPencilWritesOnPageTextAppearsOnPage()
        {
            pencil.write("Test text");
            Assert.AreEqual("Test text", pencil.checkPage());
        }

        [TestMethod]
        public void WhenPencilWritesItsPointLosesDurability()
        {
            pencil.write("test text");
            Assert.AreEqual(2, pencil.checkPointDurability());
        }

        [TestMethod]
        public void CapitolLettersDecreasePointDurabilityByTwoPoints()
        {
            pencil.write("TEST");
            Assert.AreEqual(2, pencil.checkPointDurability());
        }

        [TestMethod]
        public void WhenPointDegradesFullySpacesAreAppendedInsteadOfCharachters()
        {
            pencil.write("Test Message");
            Assert.AreEqual("Test Mess   ", pencil.checkPage());
        }

        [TestMethod]
        public void WhenPencilIsSharpenedItRegainsItsInitialPointDurability()
        {
            pencil.write("TEST");
            Assert.AreEqual(2, pencil.checkPointDurability());
            pencil.sharpen();
            Assert.AreEqual(10, pencil.checkPointDurability());
        }

        [TestMethod]
        public void WhenPencilLengthReachesZeroSharpeningItNoLongerRestoresItsPointDurability()
        {
            pencil = new PencilDurability(10, 1);
            pencil.sharpen();
            pencil.write("TEST");
            pencil.sharpen();
            Assert.AreEqual(2, pencil.checkPointDurability());
        }

        [TestMethod]
        public void PencilErasesTheLastOccuranceOfInputTextFromPaper()
        {
            pencil.write("test test");
            pencil.erase("test");
            Assert.AreEqual("test     ", pencil.checkPage());
        }
    }
}
