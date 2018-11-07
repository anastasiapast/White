using TestStack.White;
using TestStack.White.UIItems.WindowItems;
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
    public class CreateCustomerStep2Screen
    {
        private Window window;
        private Application application;

        public CreateCustomerStep2Screen(Window window, Application application)
        {
            this.window = window;
            this.application = application;
        }

        public virtual void FillStep2(string phone)
        {
            window.Get<TextBox>("phoneNumberTextBox").BulkText = phone;
            window.Get<Button>("submitButton").Click();
        }
    }
}