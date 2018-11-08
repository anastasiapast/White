using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.Utility;

namespace WhiiteTest.ScreenObject
{
    public class ModalWindow : AppScreen
    {
        protected Button okBtn;

        public ModalWindow(Window window, ScreenRepository screenRepository) : base(window, screenRepository) { }

        public virtual string Title
        {
            get { return Window.Name; }
        }

        public virtual void clickOK()
        {
            okBtn = Window.Get<Button>("OK");
            okBtn.Click();
        }
    }
}
