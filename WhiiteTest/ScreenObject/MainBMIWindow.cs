using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.Utility;

namespace WhiiteTest.ScreenObject
{
    public class MainBMIWindow : AppScreen
    {
        protected Button calculateBtn;
        protected Panel panel;
        protected Panel childPanel;
        protected TextBox heightEdit;
        protected TextBox weightEdit;


        public MainBMIWindow(Window window, ScreenRepository screenRepository): base(window, screenRepository){ }

        public virtual bool SetMetric()
        {
            ToolStrip toolStrip = Window.Get<ToolStrip>("ToolBar1");
            RadioButton metric = toolStrip.Get<RadioButton>(SearchCriteria.ByClassName("TRadioButton").AndIndex(1));
            metric.DoubleClick();
            return metric.Enabled;
        }

        public virtual void Calculate(string heightM, string weightM)
        {
            panel = Window.Get<Panel>(SearchCriteria.ByClassName("TsPanel").AndIndex(0));
            childPanel = panel.Get<Panel>(SearchCriteria.ByClassName("TsPanel").AndIndex(0));
            heightEdit = childPanel.Get<TextBox>(SearchCriteria.ByClassName("TsEdit").AndIndex(1));
            weightEdit = childPanel.Get<TextBox>(SearchCriteria.ByClassName("TsEdit").AndIndex(0));

            heightEdit.SetValue(heightM);
            weightEdit.SetValue(weightM);

            calculateBtn = Window.Get<Button>("Calculate");
            calculateBtn.Click();
        }

        public virtual ModalWindow Calculate(string heightM, string weightM, string error)
        {
            panel = Window.Get<Panel>(SearchCriteria.ByClassName("TsPanel").AndIndex(0));
            childPanel = panel.Get<Panel>(SearchCriteria.ByClassName("TsPanel").AndIndex(0));
            heightEdit = childPanel.Get<TextBox>(SearchCriteria.ByClassName("TsEdit").AndIndex(1));
            weightEdit = childPanel.Get<TextBox>(SearchCriteria.ByClassName("TsEdit").AndIndex(0));

            heightEdit.SetValue(heightM);
            weightEdit.SetValue(weightM);

            calculateBtn = Window.Get<Button>("Calculate");
            calculateBtn.Click();

            return ScreenRepository.Get<ModalWindow>("BMI & BMR Calculator", InitializeOption.NoCache);
        }
    }
}
