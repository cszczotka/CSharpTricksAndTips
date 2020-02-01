using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTricksAndTips
{
    public class GCUtils
    {
       [Test]
       public void GCGeneration()
        {
            Console.WriteLine("The number of generations are: " + System.GC.MaxGeneration);
            Demo obj = new Demo();
            Console.WriteLine("The generation number of object obj is: "
                                              + System.GC.GetGeneration(obj));
        }

        [Test]
        public void Memory()
        {
            Console.WriteLine("Total Memory:" + GC.GetTotalMemory(false));
            Demo obj = new Demo();
            Console.WriteLine("The generation number of object obj is: " + GC.GetGeneration(obj));

            Console.WriteLine("Total Memory:" + GC.GetTotalMemory(false));
        }
    }

    class Demo { }
}
