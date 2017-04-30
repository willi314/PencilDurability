﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PillarPencilDurability;

namespace PillarPencilDurabilityTest
{
    [TestClass]
    public class PencilDurabilityTest
    {
        [TestMethod]
        public void WhenPencilWritesOnPageTextAppearsOnPage()
        {
            PencilDurability pencil = new PencilDurability();
            pencil.write("Test text");
            Assert.AreEqual("Test text", pencil.checkPage());
        }

        [TestMethod]
        public void WhenPencilWritesItsPointLosesDurability()
        {
            PencilDurability pencil = new PencilDurability(10);
            pencil.write("Test text");
            Assert.AreEqual(2, pencil.checkPointDurability());
        }
    }
}
