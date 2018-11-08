using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems.WindowItems;

namespace WhiiteTest.ScreenObject
{
    [TestFixture]
    public class BMITestSuite : TestBase
    {
        static string valid = @"C:\Users\apastukhova\Source\Repos\WhiiteTest\WhiiteTest\data.xml";
        static string invalid = @"C:\Users\apastukhova\Source\Repos\WhiiteTest\WhiiteTest\dataInvalid.xml";

        [Category("BMI")]
        [TestCaseSource("BmiTestData")]
        public void ScreenBmiTest(string height, string weight)
        {
            ScreenRepository screens = new ScreenRepository(application.ApplicationSession);
            var main = screens.Get<MainBMIWindow>("BMI Calculator", InitializeOption.NoCache);

            Assert.IsTrue(main.SetMetric());

            main.Calculate(height, weight);
        }

        [Category("BMI")]
        [TestCaseSource("BmiTestDataInvalid")]
        public void InvalidBmiCases(string height, string weight, string error)
        {
            ScreenRepository screens = new ScreenRepository(application.ApplicationSession);
            var main = screens.Get<MainBMIWindow>("BMI Calculator", InitializeOption.NoCache);
            Assert.IsTrue(main.SetMetric());

            var newModalWindow  = main.Calculate(height, weight, error);

            Assert.AreEqual("BMI & BMR Calculator", newModalWindow.Title);

            newModalWindow.clickOK();
        }

        private static IEnumerable BmiTestData
        {
            get {
                return Functions.GetBmiTestData(valid);
    }
        }

        private static IEnumerable BmiTestDataInvalid
        {
            get
            {
                return Functions.GetBmiTestData(invalid);
            }
        }

    }
}
