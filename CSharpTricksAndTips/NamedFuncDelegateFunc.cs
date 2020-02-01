using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpTricksAndTips
{
    public class NamedFuncDelegateFunc
    {
        internal class Country
        {
            public string Name { get; set; }
            public string Continent { get; set; }
        }

   

    [Test]
        public void ComparisionTest()
        {
            var countries = new List<Country>();
            countries.Add(new Country { Name = "Spain", Continent = "Europe" });
            countries.Add(new Country { Name = "Japan", Continent = "Asia" });
            countries.Add(new Country { Name = "Italy", Continent = "Europe" });

            IEnumerable<Country> result = countries.Where(delegate (Country c) {
                return c.Continent == "Europe";
                });

            IEnumerable<Country> result2 = countries.Where(d => d.Continent == "Europe");

            Assert.AreEqual(result.Count(), result2.Count());
        }
    }
}
