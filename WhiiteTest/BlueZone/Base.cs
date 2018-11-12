using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;

namespace WhiiteTest.BlueZone
{
    public class Base
    {
        public Application application;
        public Window window;

        [SetUp]
        public void init()
        {
            application = Application.Launch("C:\\Program Files (x86)\\BlueZone\\6.2\\bzsm.exe");
            window = application.GetWindow("BlueZone Session Manager");
        }

        [TearDown]
        public void close()
        {
            if (application != null) application.Kill();
        }
    }
}
