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



namespace WhiiteTest
{
    [TestFixture]
    public class CalcTest
    {
        private Application application;
        private Window main;
        private Button[] btnDigits;

        [SetUp]
        public void init()
        {
            application = Application.Launch("Калькулятор");

            main = application.GetWindow("Калькулятор");

            //массив цифровых кнопок
            btnDigits = new Button[10];
            for (int i = 0; i < 10; i++)
            {
                //num4Button
                btnDigits[i] = main.Get<Button>(SearchCriteria.ByAutomationId("num" + i.ToString() + "Button"));
            }
        }

        [TearDown]
        public void close()
        {
            main.Close();
        }

        [Test]
        public void testAddition()
        {
            int a = 10, b = 59;

            //получаем кнопки + и = по их надписям
            var btnAdd = main.Get<Button>("+");
            var btnExec = main.Get<Button>("=");

            //получаем окно ввода по его AutomationID, которое определил UIVerify
            var tbResult = main.Get<TextBox>(SearchCriteria.ByAutomationId("CalculatorResults"));

            //вводим 10
            btnDigits[1].Click();
            btnDigits[0].Click();

            btnAdd.Click();

            //вводим 59
            btnDigits[5].Click();
            btnDigits[9].Click();

            btnExec.Click();

            var result = tbResult.Text;
            int ires = int.Parse(result, System.Globalization.NumberStyles.Float);

            Assert.AreEqual(a + b, result);
        }
    }
}
