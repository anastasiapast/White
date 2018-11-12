using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using System.Collections;
using TestStack.White.ScreenObjects;
using TestStack.White.Factory;
using System.Xml;
using System.Xml.Linq;

namespace WhiiteTest.BlueZone
{
    [TestFixture]
    public class BlueZoneTests : Base
    {

        public static IEnumerable ReadXml()
        {
            XDocument xdoc = XDocument.Load(@"C:\Users\apastukhova\Source\Repos\WhiiteTest\WhiiteTest\BlueZone\items.xml");

            List<EntityLpar> lpr = new List<EntityLpar>();

            //XmlNodeList xList = doc.SelectNodes("modes/mode");

            List<string> list = new List<string>();

            var mode = xdoc.Element("modes").Element("mode");

            string name = mode.Attribute("name").Value;
            foreach (XElement xe in xdoc.Descendants("mode"))
            {
                list.Add(xe.Element("lpar").Value);
            }
            //object[] a = new object[] { name, list };
            lpr.Add(new EntityLpar { Name = name, Lpars = list });

            yield return lpr;

            
            //new object[] { , weight };
            /*foreach (XmlNode xn in xList)
            {
                EntityLpar entity = new EntityLpar();
                entity.Name = xn["name"].InnerText;
                entity.Lpars = new List<string>();
                XmlNodeList lparList = xn.SelectNodes("./lpar");
                foreach (XmlNode l in lparList.Cast<XmlNode>())
                {
                    entity.Lpars.Add(l.InnerText);
                }
                //list.Add(entity);
            }*/
            //return list;
        }

        [TestCaseSource("LparTestData")]
        public void modernTest(EntityLpar l)
        {
            Console.WriteLine(l.Name);
            foreach (var _l in l.Lpars)
            {
                Console.WriteLine(_l);
            }
        }

        private static IEnumerable LparTestData
        {
            get
            {
                return ReadXml();
            }
        }



        [Test]
        public void checkItems()
        {
            ScreenRepository screens = new ScreenRepository(application.ApplicationSession);

            List<string> baseline = new List<string>(new string[] { "rs14", "rs22", "rs25", "rs27", "rs28", "rs50" });

            var main = screens.Get<Elements>("BlueZone Session Manager", InitializeOption.NoCache);

            main.changeMode("Mainframe Sessions");

            Assert.IsTrue(main.checkLpars(baseline));
        }

        [Test]
        public void checkCombo()
        {
            ScreenRepository screens = new ScreenRepository(application.ApplicationSession);

            var main = screens.Get<Elements>("BlueZone Session Manager", InitializeOption.NoCache);

            main.changeMode("FTP Sessions");

            List<string> baseline = new List<string>(new string[] { "Connection 1", "Connection 1" });

            Assert.IsTrue(main.checkLpars(baseline));

            //main.changeMode("Show All Sessions");

            //baseline = new List<string>(new string[] { "rs14", "rs22", "rs25", "rs27", "rs28", "rs50", "Connection 1", "Connection 1" });

            //Assert.IsTrue(main.checkLpars(baseline));

        }


    }
}
