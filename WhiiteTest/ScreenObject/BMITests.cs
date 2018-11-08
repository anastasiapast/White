using NUnit.Framework;
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
    public class BMITests : TestBase
    {
        static string valid = @"C:\Users\apastukhova\Source\Repos\WhiiteTest\WhiiteTest\data.xml";
        static string invalid = @"C:\Users\apastukhova\Source\Repos\WhiiteTest\WhiiteTest\dataInvalid.xml";

        [TestCaseSource("BmiTestData")]
        public void ScreenBmiTest(string height, string weight)
        {
            ScreenRepository screens = new ScreenRepository(application.ApplicationSession);
            var main = screens.Get<MainBMIWindow>("BMI Calculator", InitializeOption.NoCache);

            Assert.IsTrue(main.SetMetric());

            main.Calculate(height, weight);
        }

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
                return GetBmiTestData(valid);
    }
        }

        private static IEnumerable BmiTestDataInvalid
        {
            get
            {
                return GetBmiTestData(invalid);
            }
        }

        private static IEnumerable GetBmiTestData(String path)
        {
            var doc = XDocument.Load(path);
            if (path.Contains("Invalid"))
            {
                return
                    from vars in doc.Descendants("vars")
                    let height = vars.Attribute("height").Value
                    let weight = vars.Attribute("weight").Value
                    let error = vars.Attribute("error").Value
                    select new object[] { height, weight, error };
            }
            else
            {
                return
                    from vars in doc.Descendants("vars")
                    let height = vars.Attribute("height").Value
                    let weight = vars.Attribute("weight").Value
                    select new object[] { height, weight };
            }
        }
    }
}
