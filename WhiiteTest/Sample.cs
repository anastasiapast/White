using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.IO;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using Assert = NUnit.Framework.Assert;
using System.Collections;

namespace WhiiteTest
{
    [TestFixture]
    public class Sample
    {
        [TestCaseSource("SumTest")]
        public void summ(int a, int b, int result)
        {
            Assert.AreEqual(a + b, result);
        }


        static object[] SumTest =
        {
            new object[] { 12, 3, 11 },
            new object[] { 12, 2, 14 },
            new object[] { 12, 4, 16 }
        };
    }
}
