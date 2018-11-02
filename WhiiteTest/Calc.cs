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
            application = Application.Launch("C:\\Program Files (x86)\\Microsoft Калькулятор Плюс\\CalcPlus.exe");

            main = application.GetWindow("Калькулятор Плюс");

            //массив цифровых кнопок
            btnDigits = new Button[10];
            for (int i = 0; i < 10; i++)
            {
                btnDigits[i] = main.Get<Button>(i.ToString());
            }
        }

        [Test]
        public void testAddition()
        {
            int a = 10, b = 59;

            //получаем кнопки + и = по их надписям
            var btnAdd = main.Get<Button>("+");
            var btnExec = main.Get<Button>("=");

            //получаем окно ввода по его AutomationID, которое определил UIVerify
            var tbResult = main.Get<TextBox>(SearchCriteria.ByAutomationId("403"));

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

            Assert.AreEqual(a + b, ires);
        }

        [TearDown]
        public void close()
        {
            main.Close();
        }
    }
}
