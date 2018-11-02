using System;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListViewItems;
using TestStack.White.UIItems.WindowStripControls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Application = TestStack.White.Application;

namespace WhiiteTest
{
    [TestFixture]
    public class TestPaint
    {
        private Application paint;
        private Window mainPaint;
        private Cursor Cursor;

        [SetUp]
        public void init()
        {
            paint = Application.Launch("mspaint.exe");
            mainPaint = paint.GetWindow("Untitled - Paint");

        }

        [Test]
        public void testPaint()
        {
            //1. Select rectangle
            //сначала находим List - Shapes
            //потом ListItem Rectangle
            //2. Draw the rectangle




            var shapes = mainPaint.Get<TestStack.White.UIItems.ListView>("Shapes");
            //mainPaint.GetElement(SearchCriteria.ByText("Rectangle"));

            Console.WriteLine("test");

            /*Cursor = new Cursor(Cursor.Current.Handle);
            Cursor.Position = new Point(Cursor.Position.X - 150, Cursor.Position.Y - 150);
            Cursor.Show();
            System.Threading.Thread.Sleep(5000);
            //Cursor.Clip = new Rectangle()
            
            Console.WriteLine("test");*/



            /* UICoded
             * 
             * WinListItem uIRectangleListItem = this.UIUntitledPaintWindow.UIItemWindow.UIShapesClient.UIRectangleListItem;
            WinClient uIUntitledPaintClient = this.UIUntitledPaintWindow.UIItemWindow1.UIUntitledPaintClient;
            #endregion

            // Last mouse action was not recorded.

            // Click 'Rectangle' list item
            Mouse.Click(uIRectangleListItem, new Point(10, 14));

            // Move 'Untitled - Paint' client
            Mouse.StartDragging(uIUntitledPaintClient, new Point(112, 67));
            Mouse.StopDragging(uIUntitledPaintClient, 500, 289);
            */
        }

        [TearDown]
        public void close()
        {
            paint.Kill();
        }
    }
}
