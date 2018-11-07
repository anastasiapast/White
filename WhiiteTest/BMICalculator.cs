using System;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using System.Collections;
using System.Linq;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowStripControls;
using System.Xml.Linq;

namespace WhiiteTest
{
    [TestFixture]
    class BMICalculator
    {
        public Application applicationBmi;
        public Window mainWindow;

        [SetUp]
        public void init()
        {
            applicationBmi = Application.Launch("C:\\Program Files (x86)\\BMI & BMR Calculator\\BMI.exe");
            mainWindow = applicationBmi.GetWindow("BMI Calculator");

            ToolStrip toolStrip = mainWindow.Get<ToolStrip>("ToolBar1");

            RadioButton metric = toolStrip.Get<RadioButton>(SearchCriteria.ByClassName("TRadioButton").AndIndex(1));
            metric.DoubleClick();
            Assert.IsTrue(metric.Enabled);
        }

        [TestCaseSource("BmiTestData")]
        public void calculateBMI(string height, string weight)
        {
            Panel panel = mainWindow.Get<Panel>(SearchCriteria.ByClassName("TsPanel").AndIndex(0));

            Panel childPanel = panel.Get<Panel>(SearchCriteria.ByClassName("TsPanel").AndIndex(0));

            TextBox heightEdit = childPanel.Get<TextBox>(SearchCriteria.ByClassName("TsEdit").AndIndex(1));

            TextBox weightEdit = childPanel.Get<TextBox>(SearchCriteria.ByClassName("TsEdit").AndIndex(0));

            heightEdit.SetValue(height);
            weightEdit.SetValue(weight);

            Button calculateBtn = mainWindow.Get<Button>("Calculate");
            calculateBtn.Click();

            Panel childpanelUpd = panel.Get<Panel>(SearchCriteria.ByClassName("TsPanel").AndIndex(0));

            Console.WriteLine(childpanelUpd.Text);

            Assert.IsNotNull(calculateBtn);

        }

        [TearDown]
        public void close()
        {
            applicationBmi.Kill();
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
