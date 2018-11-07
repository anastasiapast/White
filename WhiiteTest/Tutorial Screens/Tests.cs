using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.TableItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.ScreenObjects;

namespace WhiiteTest.Tutorial_Screens
{
    [TestFixture]
    public class Tests : VideoLibraryTest
    {
        [Test]
        public void SearchByName()
        {
            DashboardScreen dashboardScreen = new DashboardScreen(window, application);
            SearchCustomerScreen search = dashboardScreen.LaunchSearchCustomer();
            int count = search.Search("Suman", "");
            Assert.AreEqual(1, count);

            /*Window searchWindow = LaunchSearchCustomer();
            searchWindow.Get<TextBox>("nameTextBox").Text = "Suman";
            searchWindow.Get<Button>("search").Click();
            Assert.AreEqual(1, searchWindow.Get<Table>("foundCustomers").Rows.Count);*/


        }

        [Test]
        public void SearchByAge()
        {
            DashboardScreen dashboardScreen = new DashboardScreen(window, application);
            SearchCustomerScreen search = dashboardScreen.LaunchSearchCustomer();
            int count = search.Search("", "20");
            Assert.AreEqual(1, count);

            /*Window searchWindow = LaunchSearchCustomer();
            searchWindow.Get<TextBox>("ageTextBox").Text = "20";
            searchWindow.Get<Button>("search").Click();
            Assert.AreEqual(1, searchWindow.Get<Table>("foundCustomers").Rows.Count);*/
        }

        [Test]
        public void Create()
        {
            ScreenRepository screens = new ScreenRepository(application.ApplicationSession);
            DashboardScreen dashboardScreen = new DashboardScreen(window, application);
            CreateCustomerStep1Screen step1 = dashboardScreen.LaunchCreateCustomer();
            step1.FillAndNext("anna", "25");
            CreateCustomerStep2Screen step2 = new CreateCustomerStep2Screen(window, application);
            step2.FillStep2("12345");
        }

        /*private Window LaunchSearchCustomer()
        {
            Hyperlink searchCustomerLink = window.Get<Hyperlink>("searchCustomer");
            searchCustomerLink.Click();
            return window.ModalWindow("Search Customer", InitializeOption.NoCache);
        }*/
    }
}
