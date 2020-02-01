using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTricksAndTips
{
    public class FunctionDelegate
    {
        [Test]
        public void SimpleTest()
        {
            Func<int, int, int> add = (a, b) =>  a + b;
            Func<int, int, int> subtract = (a, b) =>   a - b;

            Assert.AreEqual(30, add(20, 10));
        }
    }
}
