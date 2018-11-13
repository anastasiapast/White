using NUnit.Framework;
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
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.WindowStripControls;
using TestStack.White.Utility;

namespace WhiiteTest.BlueZone
{
    public class Elements:AppScreen
    {

        protected ListBox lpars;
        protected Panel panel;
        protected ComboBox combo;
        protected MenuBar menuBar;
        protected Window dialog;
       

        public Elements(Window window, ScreenRepository screenRepository) : base(window, screenRepository) { }

        public virtual bool CheckLpars (List<string> baseline)
        {
            List<string> items = new List<string>();

            lpars = Window.Get<ListBox>(SearchCriteria.ByAutomationId("304"));
            foreach (var item in lpars.Items)
            {
                items.Add(item.Name);
            }
            items.Sort();

            return (items.SequenceEqual(baseline));
        }

        public virtual void ChangeMode (String mode)
        {
            panel = Window.Get<Panel>();
            var f = panel.Get<ComboBox>(SearchCriteria.ByClassName("ComboBox").AndIndex(0));
            combo = panel.Get<ComboBox>(SearchCriteria.ByClassName("ComboBox").AndIndex(1));
            combo.Select(mode);
        }

        public virtual bool ClickAboutMenuBar ()
        {
            bool result = false;

            List<string> baseline = new List<string>() {"BlueZone Session Manager v6.2.3.2424", "© Rocket Software, Inc. or its affiliates 1996 - 2015." , "All rights reserved." };
            List<string> actual = new List<string>();

            menuBar = Window.MenuBar;

            menuBar.MenuItem("Help", "About Session Manager...").Click();

            dialog = Window.ModalWindow("About Session Manager");

            if (dialog.IsModal)
            {
                IUIItem[] labels = dialog.GetMultiple(SearchCriteria.ByControlType(ControlType.Text));
                foreach(var l in labels)
                {
                    actual.Add(l.Name);
                }
                if (actual.SequenceEqual(baseline))
                {
                    dialog.Get<Button>("OK").Click();
                    result = true;
                }                
            }
            return result;
        }

    }
}
