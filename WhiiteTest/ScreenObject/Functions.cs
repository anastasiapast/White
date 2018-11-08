using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WhiiteTest.ScreenObject
{
    public class Functions
    {
        public static IEnumerable GetBmiTestData(String path)
        {
            var doc = XDocument.Load(path);
            if (path.Contains("Invalid"))
            {
                return
                    from vars in doc.Descendants("vars")
                    let height = vars.Attribute("height").Value
                    let weight = vars.Attribute("weight").Value
                    let error = vars.Attribute("error").Value
                    select new object[] { height, weight, error };
            }
            else
            {
                return
                    from vars in doc.Descendants("vars")
                    let height = vars.Attribute("height").Value
                    let weight = vars.Attribute("weight").Value
                    select new object[] { height, weight };
            }
        }
    }
}
