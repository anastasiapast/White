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
        [TestCaseSource("BmiTestData")]
        public void ScreenBmiTest(string height, string weight)
        {
            ScreenRepository screens = new ScreenRepository(application.ApplicationSession);
            var main = screens.Get<MainBMIWindow>("BMI Calculator", InitializeOption.NoCache);

            Assert.IsTrue(main.SetMetric());

            main.Calculate(height, weight);
        }

        private static IEnumerable BmiTestData
        {
            get { return GetBmiTestData(); }
        }

        private static IEnumerable GetBmiTestData()
        {
            var doc = XDocument.Load(@"C:\Users\apastukhova\Source\Repos\WhiiteTest\WhiiteTest\data.xml");
            return
                from vars in doc.Descendants("vars")
                let height = vars.Attribute("height").Value
                let weight = vars.Attribute("weight").Value

                select new object[] { height, weight };
        }

    }
}
