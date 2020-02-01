using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTricksAndTips
{
    static class StringExtensions
    {
        public static string Shout(this string s)
        {
            return s.ToUpper();
        }
    }

    public class ExtensionMethod
    {
        [Test]
        public void StringExtensionTest()
        {
            var sayHello = "hi";
            var res = sayHello.Shout();
            Assert.AreEqual("Hi", res);
        }
    }
}
