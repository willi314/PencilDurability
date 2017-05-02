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
            pencil = new PencilDurability(10, 10, 5);
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

        [TestMethod]
        public void ErasingTextReducesTheDurabilityOfTheEraser()
        {
            pencil.write("TestTest");
            pencil.erase("Test");
            Assert.AreEqual(1, pencil.checkEraserDurability());
        }

        [TestMethod]
        public void EraserErasesCharachtersInTheOppositeOrderInWhichTheyAreWritten()
        {
            pencil.write("TestTest");
            pencil.erase("TestTest");
            Assert.AreEqual("Tes     ", pencil.checkPage());
        }

        [TestMethod]
        public void PencilCanWriteNewTextInWhiteSpace()
        {
            pencil.write("te      st");
            pencil.writeAtIndex(3, "test");
            Assert.AreEqual("te test st", pencil.checkPage());
        }
        
        [TestMethod]
        public void PencilCanWriteNewTextInWhiteSpacePastEndOfTextOnPage()
        {
            pencil.write("test    ");
            pencil.writeAtIndex(6, "test");
            Assert.AreEqual("test  test", pencil.checkPage());
        }

        [TestMethod]
        public void WhenInsertingCharachtersOverDifferentCharachtersAnAtSignIsWrittenInstead()
        {
            pencil.write("test");
            pencil.writeAtIndex(0, "toss");
            Assert.AreEqual("t@s@", pencil.checkPage());
        }

        [TestMethod]
        public void PencilPointCanFullyDegradeWhileEditingText()
        {
            pencil.write("testtest");
            pencil.writeAtIndex(3, "test");
            Assert.AreEqual("test@est", pencil.checkPage());
        }

        [TestMethod]
        public void NewLineCharactersDontDegradePencilPoint()
        {
            pencil.write("test\ntest");
            Assert.AreEqual(2, pencil.checkPointDurability());
        }
    }
}
