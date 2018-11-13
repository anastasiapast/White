using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using TestStack.White.ScreenObjects;
using TestStack.White.Factory;
using TestStack.White.UIItems.WindowItems;

namespace WhiiteTest.BlueZone
{
    [TestFixture]
    public class BlueZoneTests : Base
    {


        [TestCaseSource(typeof(LparTestData))]
        public void ShouldReturnListOfLpars(Dictionary <string, List<string>> pairs)
        {
            KeyValuePair<string, List<string>> keyValue =  pairs.First();

            ScreenRepository screens = new ScreenRepository(application.ApplicationSession);

            var main = screens.Get<Elements>("BlueZone Session Manager", InitializeOption.NoCache);

            main.ChangeMode(keyValue.Key);

            Assert.IsTrue(main.CheckLpars(keyValue.Value));
        }

        [Test]
        public void ShouldDisplayAbout()
        {
            ScreenRepository screens = new ScreenRepository(application.ApplicationSession);

            var main = screens.Get<Elements>("BlueZone Session Manager", InitializeOption.NoCache);

            Assert.That(main.ClickAboutMenuBar(), Is.True);
        }
    }

    public class LparTestData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new Dictionary<string, List<string>> { ["Mainframe Sessions"] = new List<string> { "rs14", "rs22", "rs25", "rs27", "rs28", "rs50" } };
            yield return new Dictionary<string, List<string>> { ["FTP Sessions"] = new List<string> { "Connection 1", "Connection 1"} };
            yield return new Dictionary<string, List<string>> { ["Show All Sessions"] = new List<string> { "Connection 1", "Connection 1", "rs14", "rs22", "rs25", "rs27", "rs28", "rs50" } };
        }
    }
}
