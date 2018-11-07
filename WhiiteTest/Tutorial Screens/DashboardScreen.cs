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
    class DashboardScreen
    {
        private readonly Window window;
        private readonly Application application;

        public DashboardScreen(Window window, Application application)
        {
            this.window = window;
            this.application = application;
        }

        public virtual SearchCustomerScreen LaunchSearchCustomer()
        {
            Hyperlink searchCustomerLink = window.Get<Hyperlink>("searchCustomer");
            searchCustomerLink.Click();
            Window searchCustomerWindow = window.ModalWindow("Search Customer", InitializeOption.NoCache);
            return new SearchCustomerScreen(searchCustomerWindow, application);
        }

        public virtual CreateCustomerStep1Screen LaunchCreateCustomer()
        {
            Hyperlink createCustomerLink = window.Get<Hyperlink>("createCustomer");
            createCustomerLink.Click();
            Window step1Window = application.GetWindow("Create Customer Step1", InitializeOption.NoCache);
            return new CreateCustomerStep1Screen(step1Window, application);
        }
    }
}
