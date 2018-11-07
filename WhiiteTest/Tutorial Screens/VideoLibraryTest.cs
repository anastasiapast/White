using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.WindowItems;

namespace WhiiteTest.Tutorial_Screens
{
    public class VideoLibraryTest
    {
        protected Application application;
        protected Window window;

        [SetUp]
        public void SetUp()
        {
            application = Application.Launch(@"..\..\..\SampleApplication\bin\debug\SampleApplication.exe");
            window = application.GetWindow("Dashboard", InitializeOption.NoCache);
        }

        [TearDown]
        public void CloseApplication()
        {
            if (application != null) application.Kill();
        }
    }
}
