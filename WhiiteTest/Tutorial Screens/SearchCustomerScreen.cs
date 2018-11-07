using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.WindowItems;

namespace WhiiteTest.Tutorial_Screens
{
    class SearchCustomerScreen
    {
        private readonly Window window;
        private readonly Application application;

        public SearchCustomerScreen(Window window, Application application)
        {
            this.window = window;
            this.application = application;
        }

        public virtual int Search(string name, string age)
        {
            window.Get<TextBox>("nameTextBox").Text = name;
            window.Get<TextBox>("ageTextBox").Text = age;
            window.Get<Button>("search").Click();
            return window.Get<Table>("foundCustomers").Rows.Count;
        }
    }
}
