using System;
using NUnit.Framework;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using System.Windows;
using TestStack.White.InputDevices;

using Application = TestStack.White.Application;

namespace WhiiteTest
{
    [TestFixture]
    public class TestPaint
    {

        private Application paint;
        private Window mainPaint;
        private Button info;
        private enum shapesInd{
            Rectangle = 3
        };

        [SetUp]
        public void init()
        {
            paint = Application.Launch("mspaint.exe");
            mainPaint = paint.GetWindow("Untitled - Paint", TestStack.White.Factory.InitializeOption.NoCache);

        }

        [Test]
        public void testPaint()
        {
            //1. Select rectangle
            //сначала находим List - Shapes
            //потом ListItem Rectangle
            //2. Draw the rectangle

            var shapes = mainPaint.Get<TestStack.White.UIItems.ListBoxItems.ListBox>("Shapes");

            //foreach (ListItem item in shapes.Items)
            TestStack.White.UIItems.ListBoxItems.ListItem rectangle = shapes.Items.Item(shapesInd.Rectangle.ToString());

            rectangle.DoubleClick();

            System.Threading.Thread.Sleep(2000);            

            Console.WriteLine("test");

            draw(67, 368);

            info = mainPaint.Get<Button>("Product alert");
            if (info.Visible)
            {
                info.Click();
                var alert = mainPaint.ModalWindow("Product alert");
                alert.Get<Button>("OK").Click();
            }
        }

        public void draw(int x, int y)
        {

            Mouse.Instance.Location = new Point(x, y);

            Mouse.LeftDown();

            Mouse.Instance.Location = new Point(x*3, y*2.5);

            Mouse.LeftUp();
        }


        [TearDown]
        public void close()
        {
            paint.Kill();
        }
    }
}
