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
using TestStack.White.ScreenObjects;
using TestStack.White.UIItems.Finders;

namespace WhiiteTest.Tutorial_Screens
{
    public partial class CreateCustomerStep1Screen : AppScreen
    {
        //private readonly Window window;
        //private readonly Application application;

        
        protected TextBox NameTextBox;
        protected TextBox AgeTextBox;
        protected Button NextButton;
        protected Button CancelButton;
        private Window step1Window;
        private Application application;

        //public CreateCustomerStep1Screen(Window window, Application application)
        /*{
            this.window = window;
            this.application = application;
        }*/

        public CreateCustomerStep1Screen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) { }


        public virtual void FillAndNext(string name, string age)
        {
            NameTextBox.BulkText = name;
            AgeTextBox.BulkText = age;
            NextButton.Click();

        }
        /*public virtual CreateCustomerStep2Screen FillAndNext(string name, string age)
         {
             window.Get<TextBox>("nameTextBox").BulkText = name;
             window.Get<TextBox>("ageTextBox").BulkText = age;
             window.Get<Button>("nextButton").Click();
             Window step2 = application.GetWindow("Create Customer Step2", InitializeOption.NoCache);
             return new CreateCustomerStep2Screen(step2, application);
         }*/

    }
}