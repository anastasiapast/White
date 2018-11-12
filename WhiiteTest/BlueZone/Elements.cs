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

        public Elements(Window window, ScreenRepository screenRepository) : base(window, screenRepository) { }

        public virtual bool checkLpars (List<string> baseline)
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

        public virtual void changeMode (String mode)
        {
            panel = Window.Get<Panel>();
            var f = panel.Get<ComboBox>(SearchCriteria.ByClassName("ComboBox").AndIndex(0));
            combo = panel.Get<ComboBox>(SearchCriteria.ByClassName("ComboBox").AndIndex(1));
            combo.Select(mode);
        }

    }
}
